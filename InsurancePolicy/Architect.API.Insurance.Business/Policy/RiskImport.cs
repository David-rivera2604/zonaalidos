using Architect.Utilities.Extensions;
using ClosedXML.Excel;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Insurance.Business.Policy
{
    public static partial class RiskImport
    {
        public static Core.Contracts.General.GenericResponse Import(string binPath, string excelFilename, string originalFileName, string specificactionFilename, Core.Contracts.Security.Token tokenInfo)
        {
            Int64 processId = Core.Business.General.ChangeSet.Create(2007, tokenInfo.CompanyId, "Inicio",
            string.Format("Inicio del proceso #%ProcessId% de carga masiva de pólizas para el archivo '{0}'.", originalFileName), tokenInfo.UserId, new { FileName = originalFileName });


            Core.Contracts.General.GenericResponse result = new Core.Contracts.General.GenericResponse()
            {
                Successful = true,
                Reason = string.Format("El proceso de carga #{1}, continua en ejecución en el servidor, para poder ver el progreso de este, pude hacer uso de la opción 'Historial...' '{0}'.", originalFileName, processId)
            };

            BackgroundJob.Enqueue(() => BatchImport(processId, binPath, excelFilename, originalFileName, specificactionFilename, tokenInfo));

            return result;
        }

        public static void BatchImport(Int64 processId, string binPath, string excelFilename, string originalFileName, string specificactionFilename, Core.Contracts.Security.Token tokenInfo)
        {
            try
            {
                Core.Contracts.General.GenericResponse result = new Core.Contracts.General.GenericResponse();

                int riskSuccessful = 0;
                int riskWithError = 0;
                List<Contracts.Policy.Risk> risks = Domain.Excel.Import.Handlers.DTLHandler.Builder(binPath, specificactionFilename, excelFilename, null).Data;

                Contracts.Product.ProductDefinition product = null;
                Architect.Insurance.Contracts.Policy.Risk rating = null;
                System.Data.DataTable reportResult = DataTableSpecification();
                foreach (Contracts.Policy.Risk riskItem in risks)
                {
                    //Seguridad
                    riskItem.BranchOffice = tokenInfo.BranchOffice;
                    riskItem.ExecutiveUserCode = tokenInfo.UserId;

                    //Producto
                    if (product == null)
                    {
                        product = Products.Specification.DefinitionByAlias(riskItem.ProductAlias);
                    }
                    if (product != null)
                    {
                        riskItem.EffectiveDate = riskItem.EffectiveDate == DateTime.MinValue ? product.Effective : riskItem.EffectiveDate;
                        riskItem.EndingDate = riskItem.EndingDate == DateTime.MinValue ? product.Ending : riskItem.EndingDate;
                        if (riskItem.ModuleCode.IsEmpty())
                        {
                            riskItem.ModuleCode = product.Modules.First().Code;
                        }
                        if (riskItem.Currency.IsEmpty())
                        {
                            riskItem.Currency = product.Currencies.First().Code;
                        }
                        if (riskItem.PaymentFrequency.IsEmpty())
                        {
                            riskItem.PaymentFrequency = product.PaymentFrequencies.First().Code;
                        }
                    }

                    riskItem.InsuredAmountBase = riskItem.InsuredAmountBase == 0 ? riskItem.InsuredAmount : riskItem.InsuredAmountBase;

                    //Rating
                    rating = Business.Policy.Rating.Asegurado(riskItem.ProductAlias, riskItem.Currency, riskItem.ModuleCode, riskItem.PaymentFrequency, riskItem.InsuredAmount, riskItem.PrimaryInsured.BirthDate);

                    riskItem.AnnualPremium = (double)rating.Premium.AnnualPremium;
                    riskItem.MonthlyPremium = (double)rating.Premium.BillPremium;

                    //Elimina Beneficiarios vacíos
                    Contracts.Policy.RiskRoles beneficiary = null;
                    do
                    {
                        beneficiary = riskItem.Beneficiaries.Where(r => r.DocumentType == 0).FirstOrDefault();
                        if (beneficiary != null)
                            riskItem.Beneficiaries.Remove(beneficiary);
                    } while (beneficiary != null);


                    if (riskItem.PrimaryInsured.IsNotEmpty())
                    {
                        riskItem.PrimaryInsured.DocumentNumber = riskItem.PrimaryInsured.DocumentNumber.DocumentNumberFormat(riskItem.PrimaryInsured.DocumentType);
                        riskItem.PrimaryInsured.PhoneNumber = riskItem.PrimaryInsured.PhoneNumber.PhoneNumberFormat();
                    }
                    foreach (Contracts.Policy.RiskRoles ben in riskItem.Beneficiaries)
                    {
                        ben.DocumentNumber = ben.DocumentNumber.DocumentNumberFormat(ben.DocumentType);
                        ben.PhoneNumber = ben.PhoneNumber.PhoneNumberFormat();
                    }

                    Contracts.Structure.IssuePolicyResult issue = Risk.IssuePolicy(tokenInfo, riskItem, "Post");

                    if (issue.Errors.Count > 0)
                    {
                        riskWithError++;
                        foreach (var error in issue.Errors)
                        {
                            System.Data.DataRow row = reportResult.NewRow();
                            row["Fila"] = riskItem.RowNumber;
                            row["Mensaje"] = "Falla por validaciones";
                            row["Error"] = error.Message;
                            reportResult.Rows.Add(row);
                        }
                    }
                    else
                    {
                        System.Data.DataRow row = reportResult.NewRow();
                        row["Fila"] = riskItem.RowNumber;
                        row["Mensaje"] = string.Format("Póliza emitida bajo el número {0}", issue.Risk.PolicyId);
                        reportResult.Rows.Add(row);
                        riskSuccessful++;
                    }
                }

                Core.Business.General.ChangeSet.Create(2007, processId, tokenInfo.CompanyId, "Inicio",
                    string.Format("El proceso #{3} termino de forma exitosa, se cargaron {2} asegurados de {1}. <a href='../files/{4}' download='{5}'>Descargar el archivo original con comentarios y errores</a>.", originalFileName, riskSuccessful + riskWithError, riskSuccessful, processId, System.IO.Path.GetFileName( excelFilename), originalFileName), tokenInfo.UserId, new { FileName = originalFileName, Rows = riskSuccessful + riskWithError });

                ExcelUpdateResult(excelFilename, reportResult);
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Insurance.Risk.Import", "BatchImport", ex);
                throw ex;
            }
        }

        private static System.Data.DataTable DataTableSpecification()
        {
            System.Data.DataTable result = new System.Data.DataTable("Resultado");

            result.Columns.Add(new System.Data.DataColumn("Fila", typeof(Decimal)));
            result.Columns.Add(new System.Data.DataColumn("Mensaje", typeof(string)));
            result.Columns.Add(new System.Data.DataColumn("Error", typeof(string)));

            return result;
        }

        public static void ExcelUpdateResult(string excelFilename, System.Data.DataTable data)
        {
            XLWorkbook workbook = new XLWorkbook(excelFilename, XLEventTracking.Disabled);
            IXLWorksheet sheet = null;
            try
            {
                sheet = workbook.Worksheet("Resultado");
            }
            catch (Exception ex)
            {
                sheet = null;
            }


            if (sheet.IsNotEmpty())
                workbook.Worksheet("Resultado").Delete();
            if (data.Rows.Count > 0)
                workbook.Worksheets.Add(data);
            workbook.Save();
        }
    }
}
