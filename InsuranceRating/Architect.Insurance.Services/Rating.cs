using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Architect.Utilities.Extensions;

namespace Architect.Insurance.Services
{
    public class Rating
    {


        static List<Contracts.Policy.Module> CalculateInsuredAmount(Contracts.Policy.Risk risk)
        {
            foreach (Contracts.Policy.Module riskMod in risk.Modules)
            {
                foreach (Contracts.Policy.Coverage riskCov in riskMod.Coverages)
                {

                    //Validaciones previas

                    //Edad
                    Contracts.Policy.Role roleInfo = (from r in risk.Roles where r.ClientRole == riskCov.ClientRole select r).FirstOrDefault();
                    if (roleInfo.IsNotEmpty())
                    {
                        int age = roleInfo.BirthDate.Age();

                        Rule_BirthDateRequired(risk, riskCov, roleInfo, age);
                        Rule_MinimumAge(risk, riskCov, roleInfo, age);
                        Rule_MaximumAge(risk, riskCov, roleInfo, age);
                    }

                    switch (riskCov.CoverageDefinition.InsuredAmountCalculationType)
                    {
                        case 0:
                            riskCov.InsuredAmount = 0;
                            break;
                        case 2:
                            riskCov.InsuredAmount = riskCov.CoverageDefinition.FixedInsuredAmount;
                            break;
                        case 3:
                            riskCov.InsuredAmount = (riskCov.CoverageDefinition.PercentageOnOtherCoverage / 100) * (from c in riskMod.Coverages where c.CoverageCode == riskCov.CoverageDefinition.BaseCoverageForInsuredAmount select c.InsuredAmount).FirstOrDefault();
                            break;
                        case 10:
                            riskCov.InsuredAmount = risk.ParticularData.Data.InsuredAmount + risk.ParticularData.Data.InsuredAmountComplement;
                            break;
                        default:
                            throw new NotImplementedException(string.Format("InsuredAmountCalculationType {0} not implement", riskCov.CoverageDefinition.InsuredAmountCalculationType));
                    }

                    Rule_MinimumInsuredAmount(risk, riskCov);
                    Rule_MaximumInsuredAmount(risk, riskCov);

                    //Se verifica la prima mínima
                    if (riskCov.InsuredAmount < riskCov.CoverageDefinition.MinimumInsuredAmount)
                        riskCov.InsuredAmount = riskCov.CoverageDefinition.MinimumInsuredAmount;
                }
            }
            return risk.Modules;
        }

        static List<Contracts.Policy.Module> CalculatePremium(Contracts.Policy.Risk risk, Contracts.Product.ProductMaster product)
        {
            decimal rate = 0;
            decimal premium = 0;
            foreach (Contracts.Policy.Module riskMod in risk.Modules)
            {
                foreach (Contracts.Policy.Coverage riskCov in riskMod.Coverages)
                {
                    switch (riskCov.CoverageDefinition.PremiumCalculationType)
                    {
                        case 0:
                        case 1:
                            riskCov.Rate = 0;
                            riskCov.Premium = 0;
                            break;
                        case 2:
                            riskCov.Rate = 0;
                            riskCov.Premium = 0;
                            break;
                        case 3:
                            riskCov.Rate = riskCov.CoverageDefinition.FixedRate;
                            riskCov.Premium = (riskCov.CoverageDefinition.FixedRate / 1000) * riskCov.InsuredAmount;
                            break;
                        case 4:
                            riskCov.Rate = riskCov.CoverageDefinition.FixedRate;
                            riskCov.Premium = riskCov.CoverageDefinition.FixedPremium;
                            break;
                        case 11:
                            rate = 0;
                            premium = 0;
                            //TODO: Proceso de busqueda para entidades inteligentes
                            ProcessSmartEntity(risk, product, riskMod, riskCov, ref rate, ref premium);
                            riskCov.Rate = rate;
                            riskCov.Premium = ((rate / 1000) * riskCov.InsuredAmount) + premium;
                            break;
                        default:
                            throw new NotImplementedException(string.Format("PremiumCalculationType {0} not implement", riskCov.CoverageDefinition.PremiumCalculationType));
                    }
                    //Se verifica la prima mínima
                    if (riskCov.Premium < riskCov.CoverageDefinition.MinimumPremium)
                        riskCov.Premium = riskCov.CoverageDefinition.MinimumPremium;
                }
            }
            return risk.Modules;
        }

        static List<Contracts.Policy.Module> ProcessModuleAndCoverages(Contracts.Policy.Risk risk, Contracts.Product.ProductMaster product)
        {
            List<Contracts.Policy.Module> result = new List<Contracts.Policy.Module>();
            Contracts.Policy.Role roleItem = null;
            Contracts.Policy.Module riskModule = null;
            Contracts.Product.Module prodModule = null;
            Contracts.Policy.Coverage riskCoverage = null;
            Contracts.Product.Coverage prodCoverage = null;

            ///Se procesan los default del producto
            foreach (Contracts.Product.Module item in from r in product.Modules where r.Selected select r)
            {
                result.Add(new Contracts.Policy.Module()
                {
                    ModuleCode = item.ModuleCode,
                    Description = item.Description
                });
            }
            if (risk.Modules != null)
            {
                /// Se verifica si exixten module seleccionados y no prefedinidos por producto para incorporarlos
                foreach (Contracts.Policy.Module item in from r in risk.Modules select r)
                {
                    riskModule = (from r in result where r.ModuleCode == item.ModuleCode select r).FirstOrDefault();
                    if (riskModule == null)
                    {
                        prodModule = (from r in product.Modules where r.ModuleCode == item.ModuleCode select r).FirstOrDefault();
                        result.Add(new Contracts.Policy.Module()
                        {
                            ModuleCode = prodModule.ModuleCode,
                            Description = prodModule.Description
                        });
                    }
                }
            }


            foreach (Contracts.Policy.Module riskMod in result)
            {
                if (risk.Modules != null)
                    riskModule = (from r in risk.Modules where r.ModuleCode == riskMod.ModuleCode select r).FirstOrDefault();
                riskMod.Coverages = new List<Contracts.Policy.Coverage>();
                foreach (Contracts.Product.Module prodMod in from r in product.Modules where r.ModuleCode == riskMod.ModuleCode select r)
                {
                    foreach (Contracts.Product.Coverage prodCov in prodMod.Coverages)
                    {
                        roleItem = (from r in risk.Roles where r.ClientRole == prodCov.ClientRole select r).FirstOrDefault();
                        if (roleItem != null)
                            riskMod.Coverages.Add(new Contracts.Policy.Coverage()
                            {
                                CoverageCode = prodCov.CoverageCode,
                                ClientRole = prodCov.ClientRole,
                                Description = prodCov.Description,
                                Selected = prodCov.Selected,
                                CurrencyCode = prodCov.CurrencyCode,
                                InsuredAmount = 0,
                                Rate = 0,
                                Premium = 0,
                                CoverageDefinition = prodCov
                            });
                    }

                    if (riskModule != null && riskModule.Coverages != null)
                    {
                        /// Se verifica si exixten coberturas seleccionados y no prefedinidos por producto para incorporarlos
                        foreach (Contracts.Policy.Coverage item in from r in riskModule.Coverages where r.Selected select r)
                        {
                            riskCoverage = (from r in riskMod.Coverages where r.CoverageCode == item.CoverageCode select r).FirstOrDefault();
                            if (riskCoverage == null)
                            {
                                prodCoverage = (from r in prodMod.Coverages where r.CoverageCode == item.CoverageCode select r).FirstOrDefault();
                                roleItem = (from r in risk.Roles where r.ClientRole == prodCoverage.ClientRole select r).FirstOrDefault();
                                if (roleItem != null)
                                    riskMod.Coverages.Add(new Contracts.Policy.Coverage()
                                    {
                                        CoverageCode = prodCoverage.CoverageCode,
                                        ClientRole = prodCoverage.ClientRole,
                                        Description = prodCoverage.Description,
                                        Selected = prodCoverage.Selected,
                                        CurrencyCode = prodCoverage.CurrencyCode,
                                        InsuredAmount = 0,
                                        Rate = 0,
                                        Premium = 0,
                                        CoverageDefinition = prodCoverage
                                    });
                            }
                            else
                                riskCoverage.Selected = item.Selected;
                        }

                        //En caso de que el rol llegue vacio se asume que la cobertura afecta al asegurado principal
                        foreach (Contracts.Policy.Coverage item in riskModule.Coverages)
                        {
                            if (item.ClientRole == 0)
                                item.ClientRole = 2;
                        }
                    }



                }
            }
            return result;
        }

        static void ProcessSmartEntity(Contracts.Policy.Risk risk, Contracts.Product.ProductMaster product, Contracts.Policy.Module module, Contracts.Policy.Coverage cover, ref decimal rate, ref decimal fixPremium)
        {
            string sqlStatement = string.Empty;
            Contracts.Product.SmartEntity define = (from r in product.SmartEntities where r.Id == cover.CoverageDefinition.RoutineForCalculationOfPremium select r).FirstOrDefault();
            bool tryDbSearch = false;

            if (define.Extracted)
            {
                DataTable localTable = new DataTable(define.Entity);
                localTable.ReadXml(string.Format(@"C:\_research_laboratory\Architect.Insurance\ProductMaster_{0}_{1}_TAR_AUTO.xml", product.LineOfBusiness, product.ProductCode));

                sqlStatement = string.Format("SELECT {0},{1} FROM {2} WHERE {3}", define.Rate, define.FixPremium, define.Entity, define.Filter);

                sqlStatement = define.Filter;

                sqlStatement = sqlStatement.Replace("nBranch = @LineOfBusiness AND ", string.Empty);
                sqlStatement = sqlStatement.Replace("nProduct = @ProductCode AND ", string.Empty);

                sqlStatement = sqlStatement.Replace("@ModuleCode", module.ModuleCode.ToString());
                sqlStatement = sqlStatement.Replace("@CoverageCode", cover.CoverageCode.ToString());
                sqlStatement = sqlStatement.Replace("@Currency", cover.CurrencyCode.ToString());

                sqlStatement = sqlStatement.Replace("@InsuredAmount", risk.ParticularData.Data.InsuredAmount.ToString());
                sqlStatement = sqlStatement.Replace("@InsuredAmountComplement", risk.ParticularData.Data.InsuredAmountComplement.ToString());

                if (risk.ParticularData != null)
                    if (risk.ParticularData.Auto != null)
                    {
                        sqlStatement = sqlStatement.Replace("@Auto.VehicleCode", string.Format("'{0}'", risk.ParticularData.Auto.VehicleCode));
                    }
                    else if (risk.ParticularData.Life != null)
                    {
                        sqlStatement = sqlStatement.Replace("@Life.InsuredAmount", string.Format("'{0}'", risk.ParticularData.Life.InsuredAmount.ToString()));
                    }

                DataRow[] rows = localTable.Select(sqlStatement.ToUpper());

                if (rows != null && rows.Count() > 0)
                {
                    rate = rows[0].NumericValue(define.Rate);
                    fixPremium = rows[0].NumericValue(define.FixPremium);

                }
                else
                {
                    risk.Notify.Add(new Contracts.General.Notify()
                    {
                        Severity = Contracts.General.Notify.EnumSeverity.Warning,
                        Message = string.Format("No existe tarifa para la cobertura {0} (:{1}/{2}:)", cover.CoverageCode, cover.CoverageDefinition.RoutineForCalculationOfPremium, define.Entity)
                    });
                    tryDbSearch = true;
                }
            }

            if (!define.Extracted || tryDbSearch)
            {

                sqlStatement = string.Format("SELECT {0},{1} FROM {2} WHERE {3}", define.Rate, define.FixPremium, define.Entity, define.Filter);

                sqlStatement = sqlStatement.Replace("@LineOfBusiness", product.LineOfBusiness.ToString());
                sqlStatement = sqlStatement.Replace("@ProductCode", product.ProductCode.ToString());
                sqlStatement = sqlStatement.Replace("@ModuleCode", module.ModuleCode.ToString());
                sqlStatement = sqlStatement.Replace("@CoverageCode", cover.CoverageCode.ToString());
                sqlStatement = sqlStatement.Replace("@Currency", cover.CurrencyCode.ToString());

                sqlStatement = sqlStatement.Replace("@InsuredAmount", risk.ParticularData.Data.InsuredAmount.ToString());
                sqlStatement = sqlStatement.Replace("@InsuredAmountComplement", risk.ParticularData.Data.InsuredAmountComplement.ToString());

                if (risk.ParticularData != null)
                    if (risk.ParticularData.Auto != null)
                    {
                        sqlStatement = sqlStatement.Replace("@Auto.VehicleCode", string.Format("'{0}'", risk.ParticularData.Auto.VehicleCode));
                    }
                    else if (risk.ParticularData.Life != null)
                    {
                        sqlStatement = sqlStatement.Replace("@Life.InsuredAmount", string.Format("'{0}'", risk.ParticularData.Life.InsuredAmount.ToString()));
                    }

                if (define.IsHistorical)
                    sqlStatement += "AND DEFFECDATE <= TRUNC(SYSDATE) AND(DNULLDATE IS NULL OR  DNULLDATE > TRUNC(SYSDATE))";
                //TODO: Ajustar a Datafactory
                //using (Common.Proxy.DataManagerFactory data = new Common.Proxy.DataManagerFactory(sqlStatement, define.Entity, "EntityServices"))
                //{
                //    data.Cache = Common.Enumerations.EnumCache.CacheWithFullParameters;
                //    DataTable result = data.QueryExecuteToTable(true);
                //    if (result.IsNotEmpty())
                //    {
                //        rate = result.FirstRow().NumericValue(define.Rate);
                //        fixPremium = result.FirstRow().NumericValue(define.FixPremium);
                //    }
                //    else
                //        risk.Notify.Add(new Contracts.General.Notify()
                //        {
                //            Severity = Contracts.General.Notify.EnumSeverity.Warning,
                //            Message = string.Format("No existe tarifa para la cobertura {0} (:{1}/{2}:)", cover.CoverageCode, cover.CoverageDefinition.RoutineForCalculationOfPremium, define.Entity)
                //        });
                //}
            }
        }

        static List<Contracts.Policy.Currency> ProductCurrencyDefault(Contracts.Product.ProductMaster product)
        {
            List<Contracts.Policy.Currency> result = new List<Contracts.Policy.Currency>();
            if (product.CurrenciesAllowed != null && product.CurrenciesAllowed.Count == 1)
            {
                result.Add(new Contracts.Policy.Currency()
                {
                    CurrencyCode = product.CurrenciesAllowed[0].CurrencyCode
                });
            }
            else
                foreach (Contracts.Product.CurrencyAllowed item in from r in product.CurrenciesAllowed where r.Selected select r)
                {
                    result.Add(new Contracts.Policy.Currency()
                    {
                        CurrencyCode = item.CurrencyCode
                    });
                }
            return result;
        }


        static void Rule_BirthDateRequired(Contracts.Policy.Risk risk, Contracts.Policy.Coverage riskCov, Contracts.Policy.Role roleInfo, int age)
        {
            if ((riskCov.CoverageDefinition.MinimumAge > 0 || riskCov.CoverageDefinition.MaximumAge > 0) && roleInfo.BirthDate.IsEmpty())
            {
                risk.Notify.Add(new Contracts.General.Notify()
                {
                    Severity = Contracts.General.Notify.EnumSeverity.Error,
                    Message = string.Format("Debe indicar la fecha de nacimiento del asegurado")
                });

            }
        }

        static void Rule_MinimumAge(Contracts.Policy.Risk risk, Contracts.Policy.Coverage riskCov, Contracts.Policy.Role roleInfo, int age)
        {
            if (riskCov.CoverageDefinition.MinimumAge > 0 && roleInfo.BirthDate.IsNotEmpty() && riskCov.CoverageDefinition.MinimumAge > age)
            {

                risk.Notify.Add(new Contracts.General.Notify()
                {
                    Severity = Contracts.General.Notify.EnumSeverity.Error,
                    Message = string.Format("La edad del asegurado es menor que {0}, la cual es la edad mínima permitida", riskCov.CoverageDefinition.MinimumAge)
                });

            }
        }

        static void Rule_MaximumAge(Contracts.Policy.Risk risk, Contracts.Policy.Coverage riskCov, Contracts.Policy.Role roleInfo, int age)
        {
            if (riskCov.CoverageDefinition.MaximumAge > 0 && roleInfo.BirthDate.IsNotEmpty() && riskCov.CoverageDefinition.MaximumAge < age)
            {


                risk.Notify.Add(new Contracts.General.Notify()
                {
                    Severity = Contracts.General.Notify.EnumSeverity.Error,
                    Message = string.Format("La edad del asegurado es mayor que {0}, la cual es la edad máxima permitida", riskCov.CoverageDefinition.MaximumAge)
                });

            }
        }

        static void Rule_MinimumInsuredAmount(Contracts.Policy.Risk risk, Contracts.Policy.Coverage riskCov)
        {
            if (riskCov.CoverageDefinition.MinimumInsuredAmount > 0 && riskCov.InsuredAmount < riskCov.CoverageDefinition.MinimumInsuredAmount)
            {
                Contracts.General.Notify notify = new Contracts.General.Notify()
                {
                    Severity = Contracts.General.Notify.EnumSeverity.Message,
                    Message = string.Format("La suma asegurada es menor que {0}, el cual monto mínimo permitido", riskCov.CoverageDefinition.MinimumInsuredAmount)
                };
                if (riskCov.CoverageDefinition.InsuredAmountCalculationType == 10)
                    notify.Severity = Contracts.General.Notify.EnumSeverity.Error;
                risk.Notify.Add(notify);
            }
        }
        static void Rule_MaximumInsuredAmount(Contracts.Policy.Risk risk, Contracts.Policy.Coverage riskCov)
        {
            if (riskCov.CoverageDefinition.MaximumInsuredAmount > 0 && riskCov.InsuredAmount > riskCov.CoverageDefinition.MaximumInsuredAmount)
            {
                Contracts.General.Notify notify = new Contracts.General.Notify()
                {
                    Severity = Contracts.General.Notify.EnumSeverity.Message,
                    Message = string.Format("La suma asegurada es mayor que {0}, el cual monto máximo permitido", riskCov.CoverageDefinition.MaximumInsuredAmount)
                };
                if (riskCov.CoverageDefinition.InsuredAmountCalculationType == 10)
                    notify.Severity = Contracts.General.Notify.EnumSeverity.Error;
                risk.Notify.Add(notify);
            }
        }

        public static void Calculate(Contracts.Policy.Risk risk, Contracts.Product.ProductMaster product)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            if (risk.Notify == null)
                risk.Notify = new List<Contracts.General.Notify>();

            if (risk == null)
                risk = new Contracts.Policy.Risk();

            //Se asigna el rol asegurado en caso de no existir
            if (risk.Roles == null || risk.Roles.Count == 0)
            {
                risk.Roles = new List<Contracts.Policy.Role>() { new Contracts.Policy.Role() { ClientRole = 2 } };
            }

            //Se asigna la moneda por default
            if (risk.Currencies == null || risk.Currencies.Count == 0)
            {
                risk.Currencies = ProductCurrencyDefault(product);
                //TODO: EN caso de reorna vacio quiere decir que no existe una moneda por default
            }
            //TODO: Verificar que la moneda este entre las permitidas

            risk.Modules = ProcessModuleAndCoverages(risk, product);
            //TODO: Verificar que se seleccione un modulo 

            //Se procesa el calculo del capital
            if (risk.Modules != null && risk.Modules.Count > 0)
            {
                risk.Modules = CalculateInsuredAmount(risk);
            }

            //Se procesa el calculo de tasa y prima
            if (risk.Modules != null && risk.Modules.Count > 0)
            {
                risk.Modules = CalculatePremium(risk, product);
            }


            if (risk.Notify.Count == 0)
                risk.Notify = null;

            watch.Stop();
            risk.RatingTiming = watch.ElapsedMilliseconds;
        }

        public static Contracts.Product.Coverage FixedCoverage(Contracts.Product.Module prodMod)
        {
            Contracts.Product.Coverage result = null;

            List<Contracts.Product.Coverage> coverages = (from r in prodMod.Coverages where r.CoverageCodeContainsPremium == 0 select r).ToList();

            if (coverages.Count == 1)
                result = coverages.First();

            return result;
        }

    }
}
