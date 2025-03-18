using Architect.API.Tron.Contracts.SINPEMovil.Request;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Pagos
{
    /// <summary>
    /// .
    /// </summary>
    public static partial class SINPEMovil
    {
        public static int Create(Architect.API.Tron.Contracts.SINPEMovil.Request.AplicarPago aplicarPagoItem, string datosAdicionales, DataFactory.Session session)
        {

            List<DataFactory.Contracts.Parameter> parameters = Database.ParameterList()
                .AddParameter("IdentificacionCliente", DbType.AnsiString, 12, aplicarPagoItem.IdentificacionCliente)
                .AddParameter("NombreCliente", DbType.AnsiString, 40, aplicarPagoItem.NombreCliente)
                .AddParameter("Moneda", DbType.Decimal, 1, aplicarPagoItem.Moneda)
                .AddParameter("Monto", DbType.Decimal, 18, aplicarPagoItem.Monto)
                .AddParameter("Fecha", DbType.DateTime, 9, aplicarPagoItem.Fecha)
                .AddParameter("CodReferencia", DbType.AnsiString, 25, aplicarPagoItem.CodReferencia)
                .AddParameter("CodReferenciaBanco", DbType.AnsiString, 10, aplicarPagoItem.CodReferenciaBanco)
                .AddParameter("Descripcion", DbType.AnsiString, 20, aplicarPagoItem.Descripcion)
                .AddParameter("TelefonoDestino", DbType.AnsiString, 15, aplicarPagoItem.TelefonoDestino)
                .AddParameter("DatosAdicionales", DbType.AnsiString, 4000, datosAdicionales)
                .AddParameter("Estado", DbType.Decimal, 5, aplicarPagoItem.Estado)
                .AddParameter("ID", DbType.Decimal, 9, 0, ParameterDirection.Output).Parameters;

            Database.Insert(
@"INSERT INTO SINPEMOVIL (IdentificacionCliente, NombreCliente, Moneda, Monto, Fecha, CodReferencia, CodReferenciaBanco, Descripcion, TelefonoDestino, DatosAdicionales, Estado)
	VALUES (:IdentificacionCliente, :NombreCliente, :Moneda, :Monto, :Fecha, :CodReferencia, :CodReferenciaBanco, :Descripcion, :TelefonoDestino, :DatosAdicionales, :Estado)
    RETURNING ID INTO :ID")
                        .AddParameter(parameters)
                        .Execute(session);
            int id = Convert.ToInt32(parameters.Find(r => r.Name == "ID").Value.ToString());

            return id;
        }
        
        public static Architect.API.Tron.Contracts.SINPEMovil.Request.AplicarPago RetrieveByCodReferencia(string codReferencia, DataFactory.Session session)
        {
            Architect.API.Tron.Contracts.SINPEMovil.Request.AplicarPago result = new AplicarPago();
            Database.Select(
@"SELECT NVL(MAX(Id),0) Id, Estado
  FROM SINPEMOVIL
 WHERE CodReferencia=:CodReferencia GROUP BY Id, Estado")
            .AddParameter("CodReferencia", DbType.AnsiString, 25, codReferencia)
                        .Query(session, new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Id = reader.IntegerValue("Id");
                            result.Estado = reader.IntegerValue("Estado");
                        }));
            return result;
        }

        public static int Update(int id, Architect.API.Tron.Contracts.SINPEMovil.Request.AplicarPago aplicarPagoItem, string datosAdicionales, DataFactory.Session session)
        {
            return Database.Update(
@"UPDATE SINPEMOVIL
    SET IdentificacionCliente=:IdentificacionCliente, NombreCliente=:NombreCliente, Moneda=:Moneda, Monto=:Monto, Fecha=:Fecha, CodReferencia=:CodReferencia, CodReferenciaBanco=:CodReferenciaBanco, Descripcion=:Descripcion, TelefonoDestino=:TelefonoDestino, DatosAdicionales=:DatosAdicionales, Estado=:Estado
  WHERE ID=:ID")
                .AddParameter("IdentificacionCliente", DbType.AnsiString, 12, aplicarPagoItem.IdentificacionCliente)
                .AddParameter("NombreCliente", DbType.AnsiString, 40, aplicarPagoItem.NombreCliente)
                .AddParameter("Moneda", DbType.Decimal, 1, aplicarPagoItem.Moneda)
                .AddParameter("Monto", DbType.Decimal, 18, aplicarPagoItem.Monto)
                .AddParameter("Fecha", DbType.DateTime, 9, aplicarPagoItem.Fecha)
                .AddParameter("CodReferencia", DbType.AnsiString, 25, aplicarPagoItem.CodReferencia)
                .AddParameter("CodReferenciaBanco", DbType.AnsiString, 10, aplicarPagoItem.CodReferenciaBanco)
                .AddParameter("Descripcion", DbType.AnsiString, 20, aplicarPagoItem.Descripcion)
                .AddParameter("TelefonoDestino", DbType.AnsiString, 15, aplicarPagoItem.TelefonoDestino)
                .AddParameter("DatosAdicionales", DbType.AnsiString, 4000, datosAdicionales)
                .AddParameter("Estado", DbType.Decimal, 5, 1)
                .AddParameter("ID", DbType.Decimal, 9, id)
                .Execute(session);
        }

        public static int UpdateEstado(int id, int estado, string razon, DataFactory.Session session)
        {
            return Database.Update(
@"UPDATE SINPEMOVIL
    SET Estado=:Estado, Razon=:Razon
  WHERE ID=:ID")
                .AddParameter("Estado", DbType.Decimal, 5, estado)
                .AddParameter("Razon", DbType.AnsiString, 100, razon)
                .AddParameter("ID", DbType.Decimal, 9, id)
                .Execute(session);
        }

    }

}
