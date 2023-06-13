using Architect.API.Core.Contracts.General;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Procesamiento de data para la personalización de inicio clientes
    /// </summary>
    public sealed partial class ProcessData
    {

        public static Architect.API.Core.Contracts.Security.ClientesInicioResponse RetrieveInicio(int companyId , IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.Security.ClientesInicioResponse resultado = new Architect.API.Core.Contracts.Security.ClientesInicioResponse();
            Database.Select("SELECT COMPANYID, TITULO1 , DESCRIPCION1 , FRASE1 , LINK1 , IMAGEN1 , TITULO2 , DESCRIPCION2 , FRASE2 , LINK2 , IMAGEN2 , " +
                            "TITULO3 , DESCRIPCION3 , FRASE3 , LINK3 , IMAGEN3 , TITULO4 , DESCRIPCION4 , FRASE4 , LINK4 , IMAGEN4 " +
                              "FROM TENANTSPERSONALIZATION " +
                              "WHERE CompanyId=:CompanyId")
                         .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            resultado = DataReaderToInicioData(reader);
                        }));
            return resultado;
        }


        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>

        public static Architect.API.Core.Contracts.Security.ClientesInicioResponse DataReaderToInicioData(System.Data.IDataReader reader, Architect.API.Core.Contracts.Security.ClientesInicioResponse item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.Security.ClientesInicioResponse();
            }

            item.CompanyId = reader.IntegerValue("COMPANYID");

            item.Titulo1 = reader.StringValue("TITULO1");
            item.Descripcion1 = reader.StringValue("DESCRIPCION1");
            item.Frase1 = reader.StringValue("FRASE1");
            item.Link1 = reader.StringValue("LINK1");
            //item.Imagen1 = reader.ByteArrayValue("IMAGEN1");
            //string imagen1String = Encoding.UTF8.GetString(item.Imagen1);
            //item.imagen1String = imagen1String;
            byte[] imagen1Bytes = reader.ByteArrayValue("IMAGEN1");
            item.Imagen1 = imagen1Bytes?.Length > 0 ? Encoding.UTF8.GetString(imagen1Bytes) : null;
            
            
            item.Titulo2 = reader.StringValue("TITULO2");
            item.Descripcion2 = reader.StringValue("DESCRIPCION2");
            item.Frase2 = reader.StringValue("FRASE2");
            item.Link2 = reader.StringValue("LINK2");
            byte[] imagen2Bytes = reader.ByteArrayValue("IMAGEN2");
            item.Imagen2 = imagen2Bytes?.Length > 0 ? Encoding.UTF8.GetString(imagen2Bytes) : null;


            item.Titulo3 = reader.StringValue("TITULO3");
            item.Descripcion3 = reader.StringValue("DESCRIPCION3");
            item.Frase3 = reader.StringValue("FRASE3");
            item.Link3 = reader.StringValue("LINK3");
            byte[] imagen3Bytes = reader.ByteArrayValue("IMAGEN3");
            item.Imagen3 = imagen3Bytes?.Length > 0 ? Encoding.UTF8.GetString(imagen3Bytes) : null;

            item.Titulo4 = reader.StringValue("TITULO4");
            item.Descripcion4 = reader.StringValue("DESCRIPCION4");
            item.Frase4 = reader.StringValue("FRASE4");
            item.Link4 = reader.StringValue("LINK4");
            byte[] imagen4Bytes = reader.ByteArrayValue("IMAGEN4");
            item.Imagen4 = imagen4Bytes?.Length > 0 ? Encoding.UTF8.GetString(imagen4Bytes) : null;

            return item;
        }




    }
}
