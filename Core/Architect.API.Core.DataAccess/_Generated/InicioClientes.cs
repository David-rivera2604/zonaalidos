using Architect.API.Core.Contracts.General;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    public sealed partial class InicioUpdate
    {
        public static int Update(Architect.API.Core.Contracts.Security.ClientesInicioResponse InicioClientesItem, IDbConnection connection = null)
        {

            return Database.Update("UPDATE TENANTSPERSONALIZATION " +
                                   "SET COMPANYID=:CompanyId, TITULO1=:Titulo1, TITULO2=:Titulo2, TITULO3=:Titulo3, TITULO4=:Titulo4, DESCRIPCION1=:Descripcion1, DESCRIPCION2=:Descripcion2, DESCRIPCION3=:Descripcion3, DESCRIPCION4=:Descripcion4, " +
                                        "FRASE1=:Frase1, FRASE2=:Frase2, FRASE3=:Frase3, FRASE4=:Frase4, LINK1=:Link1, LINK2=:Link2, LINK3=:Link3, LINK4=:Link4, IMAGEN1=:Imagen1, IMAGEN2=:Imagen2, IMAGEN3=:Imagen3, IMAGEN4=:Imagen4 " +
                                   "WHERE COMPANYID=:CompanyId ")
                .AddParameter("COMPANYID", DbType.Decimal, 5, InicioClientesItem.CompanyId)
                .AddParameter("TITULO1", DbType.String, 100, InicioClientesItem.Titulo1)
                .AddParameter("TITULO2", DbType.String, 100, InicioClientesItem.Titulo2)
                .AddParameter("TITULO3", DbType.String, 100, InicioClientesItem.Titulo3)
                .AddParameter("TITULO4", DbType.String, 100, InicioClientesItem.Titulo4)
                .AddParameter("DESCRIPCION1", DbType.String, 400, InicioClientesItem.Descripcion1)
                .AddParameter("DESCRIPCION2", DbType.String, 400, InicioClientesItem.Descripcion2)
                .AddParameter("DESCRIPCION3", DbType.String, 400, InicioClientesItem.Descripcion3)
                .AddParameter("DESCRIPCION4", DbType.String, 400, InicioClientesItem.Descripcion4)
                .AddParameter("FRASE1", DbType.String, 100, InicioClientesItem.Frase1)
                .AddParameter("FRASE2", DbType.String, 100, InicioClientesItem.Frase2)
                .AddParameter("FRASE3", DbType.String, 100, InicioClientesItem.Frase3)
                .AddParameter("FRASE4", DbType.String, 100, InicioClientesItem.Frase4)
                .AddParameter("LINK1", DbType.String, 300, InicioClientesItem.Link1)
                .AddParameter("LINK2", DbType.String, 300, InicioClientesItem.Link2)
                .AddParameter("LINK3", DbType.String, 300, InicioClientesItem.Link3)
                .AddParameter("LINK4", DbType.String, 300, InicioClientesItem.Link4)
                .AddParameter("IMAGEN1", DbType.Binary, 0, Encoding.UTF8.GetBytes(InicioClientesItem.Imagen1))
                .AddParameter("IMAGEN2", DbType.Binary, 0, Encoding.UTF8.GetBytes(InicioClientesItem.Imagen2))
                .AddParameter("IMAGEN3", DbType.Binary, 0, Encoding.UTF8.GetBytes(InicioClientesItem.Imagen3))
                .AddParameter("IMAGEN4", DbType.Binary, 0, Encoding.UTF8.GetBytes(InicioClientesItem.Imagen4))
                .Execute(connection, "Research");
        }
    }

}