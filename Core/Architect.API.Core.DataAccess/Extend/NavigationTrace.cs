using Architect.DataFactory;
using Architect.DataFactory.Contracts;
using Architect.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Architect.API.Core.DataAccess.Extend
{
    public partial class NavigationTrace
    {
        #region CRUD Methods

        public static void Track(string action)
        {
            Database.Select("INSERT INTO NavigationTrace (TraceId, EffectDate, UserId, Action)" + " VALUES ( :TraceId, :EffectDate, :UserId, :Action)")
                      .AddParameter("TraceId", Architect.DataFactory.Enumerations.DbType.Decimal, 9, HttpContext.Current.Session["TraceId"])
                      .AddParameter("EffectDate", Architect.DataFactory.Enumerations.DbType.Date, 9, DateTime.Now)
                      .AddParameter("UserId", Architect.DataFactory.Enumerations.DbType.Decimal, 9, HttpContext.Current.Session["UserId"])
                      .AddParameter("Action", Architect.DataFactory.Enumerations.DbType.String, 512, action)
                            .Execute("Architect.Core");
        }

        #endregion CRUD Methods
    }
}