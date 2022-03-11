using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.Others
{
    /// <summary>
    /// .
    /// </summary>
    public sealed partial class Inclusiones
    {
        /// <summary>
        /// Devuelve una lista inclusiones para un rango de identificaciones.
        /// </summary>
        public static List<Contracts.Bayer.InclusionView> RetrieveInclusionViewById(int companyid, int idFrom, int idTo, IDbConnection connection = null)
        {
            var result = new List<Contracts.Bayer.InclusionView>();
            string filter = string.Format(" AND P.Id >= :idFrom ");
            if (idTo > 0)
            {
                filter += string.Format(" AND P.Id <= :idTo ");
            }

            {
                List<Architect.DataFactory.Contracts.Parameter> parameters = new List<Architect.DataFactory.Contracts.Parameter>();
                parameters.Add(new DataFactory.Contracts.Parameter { Name = "CompanyId", Type = DbType.Decimal, Size = 5, Value = companyid });
                parameters.Add(new DataFactory.Contracts.Parameter { Name = "idFrom", Type = DbType.Decimal, Size = 9, Value = idFrom });

                if (idTo > 0)
                {
                    parameters.Add(new DataFactory.Contracts.Parameter { Name = "idTo", Type = DbType.Decimal, Size = 9, Value = idTo });
                }

                Database.Select(Properties.Resources.Inclusiones_View.Replace("@FILTER@", filter))
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Contracts.Bayer.InclusionView()
                            {
                                Id = (int)Math.Round(reader.NumericValue("Id")),
                                IssueDate = reader.DateTimeValue("IssueDate"),
                                DocumentNumber = reader.StringValue("DocumentNumber"),
                                InsuredFullName = reader.StringValue("InsuredFullName"),
                                BirthDate = reader.DateTimeValue("BirthDate"),
                                PhoneNumber = reader.StringValue("PhoneNumber"),
                                PrimaryEmailAddress = reader.StringValue("PrimaryEmailAddress"),
                                Status = (int)Math.Round(reader.NumericValue("Status")),
                                StatusDesc = reader.StringValue("StatusDesc"),
                                UpdateDate = reader.DateTimeValue("UpdateDate")
                            });
                        }));
            }

            return result;
        }

        /// <summary>
        /// Devuelve una lista inclusiones para un rango de fecha de ingreso.
        /// </summary>
        public static List<Contracts.Bayer.InclusionView> RetrieveInclusionViewByIssueDate(int companyid, DateTime issueDateFrom, DateTime issueDateTo, IDbConnection connection = null)
        {
            var result = new List<Contracts.Bayer.InclusionView>();
            string filter = string.Format(" AND P.IssueDate >= :issueDateFrom ");
            if (issueDateTo != DateTime.MinValue)
            {
                filter += string.Format(" AND P.IssueDate <= :issueDateTo ");
            }

            {
                List<Architect.DataFactory.Contracts.Parameter> parameters = new List<Architect.DataFactory.Contracts.Parameter>();
                parameters.Add(new DataFactory.Contracts.Parameter { Name = "CompanyId", Type = DbType.Decimal, Size = 5, Value = companyid });
                parameters.Add(new DataFactory.Contracts.Parameter { Name = "issueDateFrom", Type = DbType.DateTime, Size = 9, Value = issueDateFrom });
                if (issueDateTo != DateTime.MinValue)
                {
                    parameters.Add(new DataFactory.Contracts.Parameter { Name = "issueDateFrom", Type = DbType.DateTime, Size = 9, Value = issueDateTo });
                }

                Database.Select(Properties.Resources.Inclusiones_View.Replace("@FILTER@", filter))
                      .AddParameter(parameters)
                      .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                      {
                          result.Add(new Contracts.Bayer.InclusionView()
                          {
                              Id = (int)Math.Round(reader.NumericValue("Id")),
                              IssueDate = reader.DateTimeValue("IssueDate"),
                              DocumentNumber = reader.StringValue("DocumentNumber"),
                              InsuredFullName = reader.StringValue("InsuredFullName"),
                              BirthDate = reader.DateTimeValue("BirthDate"),
                              PhoneNumber = reader.StringValue("PhoneNumber"),
                              PrimaryEmailAddress = reader.StringValue("PrimaryEmailAddress"),
                              Status = (int)Math.Round(reader.NumericValue("Status")),
                              StatusDesc = reader.StringValue("StatusDesc"),
                              UpdateDate = reader.DateTimeValue("UpdateDate")
                          });
                      }));
            }

            return result;
        }

        public static int Create(Contracts.Others.Inclusiones inclusionesItem, int userId, IDbConnection connection = null)
        {
            int result = 1;
            if (inclusionesItem.Id.IsEmpty())
            {
                inclusionesItem.Id = RetrieveLastKey(connection) + 1;
            }

            if (Create(inclusionesItem, connection) > 0)
            {
                if (inclusionesItem.Extras.IsNotEmpty() && inclusionesItem.Extras.Count > 0)
                {
                    int index = 1;
                    foreach (Contracts.Others.InclusionesExtra item in inclusionesItem.Extras)
                    {
                        item.Id = inclusionesItem.Id;
                        item.Consecutivo = index;
                        Create(item);
                        index += 1;
                    }
                }

                result = inclusionesItem.Id;
            }

            return result;
        }

        /// <summary>
        /// Crea un registro en la tabla Inclusiones.
        /// </summary>
        /// <param name="inclusionesItem">Instancia de Inclusiones</param>
        /// <returns>Cantidad de registros creados.</returns>
        private static int Create(Contracts.Others.Inclusiones inclusionesItem, IDbConnection connection = null)
        {
            return Database.Insert(@"INSERT INTO Inclusiones
                                                     (Id, Empresa, TieneDependientes, CantidadDeDependientes, Finalizado, CodigoDeImpresion, CantidadDeCanets, CantidadDeCertificados, FechaDeRecibido, FechaDeEnvioAPanama, FechaDeEnvioACorredor, Tramite, FechaEfectiva, Clase, Nombre, Apellido, Cedula, Observacines, FechaDeEnvioDeLaObservacion, FechaNacimiento, Sexo, Estatus, TipoDeIdentificacion, CorreoElectronico, NroCuenta, Plan, Certificado, DeducibleConsumido, DeducibleMaximoVitalicio, StopLost, NumeroEmpleado)
                                               VALUES(:Id, :Empresa, :TieneDependientes, :CantidadDeDependientes, :Finalizado, :CodigoDeImpresion, :CantidadDeCanets, :CantidadDeCertificados, :FechaDeRecibido, :FechaDeEnvioAPanama, :FechaDeEnvioACorredor, :Tramite, :FechaEfectiva, :Clase, :Nombre, :Apellido, :Cedula, :Observacines, :FechaDeEnvioDeLaObservacion, :FechaNacimiento, :Sexo, :Estatus, :TipoDeIdentificacion, :CorreoElectronico, :NroCuenta, :Plan, :Certificado, :DeducibleConsumido, :DeducibleMaximoVitalicio, :StopLost, :NumeroEmpleado)")
                        .AddParameter("Id", DbType.Decimal, 9, inclusionesItem.Id)
                        .AddParameter("Empresa", DbType.Decimal, 9, inclusionesItem.Empresa)
                        .AddParameter("TieneDependientes", DbType.Decimal, 1, inclusionesItem.TieneDependientes ? 1 : 0)
                        .AddParameter("CantidadDeDependientes", DbType.Decimal, 3, inclusionesItem.CantidadDeDependientes)
                        .AddParameter("Finalizado", DbType.Decimal, 1, inclusionesItem.Finalizado ? 1 : 0)
                        .AddParameter("CodigoDeImpresion", DbType.AnsiString, 255, inclusionesItem.CodigoDeImpresion)
                        .AddParameter("CantidadDeCanets", DbType.AnsiString, 255, inclusionesItem.CantidadDeCanets)
                        .AddParameter("CantidadDeCertificados", DbType.AnsiString, 255, inclusionesItem.CantidadDeCertificados)
                        .AddParameter("FechaDeRecibido", DbType.DateTime, 9, inclusionesItem.FechaDeRecibido)
                        .AddParameter("FechaDeEnvioAPanama", DbType.DateTime, 9, inclusionesItem.FechaDeEnvioAPanama)
                        .AddParameter("FechaDeEnvioACorredor", DbType.DateTime, 9, inclusionesItem.FechaDeEnvioACorredor)
                        .AddParameter("Tramite", DbType.AnsiString, 255, inclusionesItem.Tramite)
                        .AddParameter("FechaEfectiva", DbType.DateTime, 9, inclusionesItem.FechaEfectiva)
                        .AddParameter("Clase", DbType.AnsiString, 255, inclusionesItem.Clase)
                        .AddParameter("Nombre", DbType.AnsiString, 255, inclusionesItem.Nombre)
                        .AddParameter("Apellido", DbType.AnsiString, 255, inclusionesItem.Apellido)
                        .AddParameter("Cedula", DbType.AnsiString, 255, inclusionesItem.Cedula)
                        .AddParameter("Observacines", DbType.AnsiString, 255, inclusionesItem.Observacines)
                        .AddParameter("FechaDeEnvioDeLaObservacion", DbType.DateTime, 9, inclusionesItem.FechaDeEnvioDeLaObservacion)
                        .AddParameter("FechaNacimiento", DbType.DateTime, 9, inclusionesItem.FechaNacimiento)
                        .AddParameter("Sexo", DbType.AnsiString, 10, inclusionesItem.Sexo)
                        .AddParameter("Estatus", DbType.AnsiString, 30, inclusionesItem.Estatus)
                        .AddParameter("TipoDeIdentificacion", DbType.AnsiString, 40, inclusionesItem.TipoDeIdentificacion)
                        .AddParameter("CorreoElectronico", DbType.AnsiString, 80, inclusionesItem.CorreoElectronico)
                        .AddParameter("NroCuenta", DbType.AnsiString, 22, inclusionesItem.NroCuenta)
                        .AddParameter("Plan", DbType.Decimal, 5, inclusionesItem.Plan)
                        .AddParameter("Certificado", DbType.Decimal, 9, inclusionesItem.Certificado)
                        .AddParameter("DeducibleConsumido", DbType.Decimal, 18, inclusionesItem.DeducibleConsumido)
                        .AddParameter("DeducibleMaximoVitalicio", DbType.Decimal, 18, inclusionesItem.DeducibleMaximoVitalicio)
                        .AddParameter("StopLost", DbType.Decimal, 18, inclusionesItem.StopLost)
                        .AddParameter("NumeroEmpleado", DbType.AnsiString, 30, inclusionesItem.EmployeeNumber)
                       .Execute(connection, "Tron");
        }

        /// <summary>
        /// Último valor asignado a clave unica de la tabla Inclusiones.
        /// </summary>
        /// <returns>Último valor asignado.</returns>
        private static int RetrieveLastKey(IDbConnection connection = null)
        {
            return (int)Database.Select(@"SELECT NVL(MAX(Id),0)
                                           FROM Inclusiones")
                               .QueryScalar<Decimal>(connection, "Tron");
        }

        /// <summary>
        /// Crea un registro en la tabla InclusionesExtra.
        /// </summary>
        /// <param name="inclusionesextraItem">Instancia de InclusionesExtra</param>
        /// <returns>Cantidad de registros creados.</returns>
        private static int Create(Contracts.Others.InclusionesExtra inclusionesextraItem, IDbConnection connection = null)
        {
            return Database.Insert(@"INSERT INTO InclusionesExtra
                                                 (Id, Consecutivo, TipoExtra, IdentificacionExtra, NombreExtra, ApellidoExtra, EdadExtra, ParentescoExtra, FechaInclusionExtra, FechaExclusionExtra, ParticipacionExtra, TipoDeIdentificacionExtra, PlanEx, DeducibleConsumidoEx, DeducibleMaximoVitalicioEx, StopLossEx, FechaNacimientoEx)
                                           VALUES(:Id, :Consecutivo, :TipoExtra, :IdentificacionExtra, :NombreExtra, :ApellidoExtra, :EdadExtra, :ParentescoExtra, :FechaInclusionExtra, :FechaExclusionExtra, :ParticipacionExtra, :TipoDeIdentificacionExtra, :PlanEx, :DeducibleConsumidoEx, :DeducibleMaximoVitalicioEx, :StopLossEx, :FechaNacimientoEx)")
                        .AddParameter("Id", DbType.Decimal, 9, inclusionesextraItem.Id)
                        .AddParameter("Consecutivo", DbType.Decimal, 9, inclusionesextraItem.Consecutivo)
                        .AddParameter("TipoExtra", DbType.AnsiString, 20, inclusionesextraItem.TipoExtra)
                        .AddParameter("IdentificacionExtra", DbType.AnsiString, 60, inclusionesextraItem.IdentificacionExtra)
                        .AddParameter("NombreExtra", DbType.AnsiString, 80, inclusionesextraItem.NombreExtra)
                        .AddParameter("ApellidoExtra", DbType.AnsiString, 35, inclusionesextraItem.ApellidoExtra)
                        .AddParameter("EdadExtra", DbType.Decimal, 3, inclusionesextraItem.EdadExtra)
                        .AddParameter("ParentescoExtra", DbType.AnsiString, 35, inclusionesextraItem.ParentescoExtra)
                        .AddParameter("FechaInclusionExtra", DbType.DateTime, 9, inclusionesextraItem.FechaInclusionExtra)
                        .AddParameter("FechaExclusionExtra", DbType.DateTime, 9, inclusionesextraItem.FechaExclusionExtra)
                        .AddParameter("ParticipacionExtra", DbType.Decimal, 3, inclusionesextraItem.ParticipacionExtra)
                        .AddParameter("TipoDeIdentificacionExtra", DbType.AnsiString, 40, inclusionesextraItem.TipoDeIdentificacionExtra)
                        .AddParameter("PlanEx", DbType.Decimal, 5, inclusionesextraItem.PlanEx)
                        .AddParameter("DeducibleConsumidoEx", DbType.Decimal, 18, inclusionesextraItem.DeducibleConsumidoEx)
                        .AddParameter("DeducibleMaximoVitalicioEx", DbType.Decimal, 18, inclusionesextraItem.DeducibleMaximoVitalicioEx)
                        .AddParameter("StopLossEx", DbType.Decimal, 18, inclusionesextraItem.StopLossEx)
                        .AddParameter("FechaNacimientoEx", DbType.DateTime, 9, inclusionesextraItem.FechaNacimientoEx)
                      .Execute(connection, "Tron");
        }

        public static int RetrieveContratante(string poliza, IDbConnection connection = null)
        {
            return (int)Database.Select(@"SELECT NVL(MAX(Id),0)
                                            FROM CONTRATANTES WHERE POLIZATRON=:POLIZATRON")
                             .AddParameter("POLIZATRON", DbType.AnsiString, 14, poliza)
                             .QueryScalar<Decimal>(connection, "Tron");
        }
    }
}