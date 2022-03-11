using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// ProcessCase
     /// </summary>
    public sealed partial class ProcessCase
    {

        public static int Update(int caseId, int activityId, int status, string label, int substatus, string sublabel, int currentStepId, IDbConnection currentConnection = null)
        {
            return Database.Update("UPDATE ProcessCase " +
                                      "SET InstanceId=:InstanceId, Status=:Status, Label=:Label, SubStatus=:SubStatus, SubLabel=:SubLabel, CurrentStepId=:CurrentStepId " +
                                    "WHERE Id=:Id")
                                .AddParameter("InstanceId", DbType.Decimal, 9, activityId)
                                .AddParameter("Status", DbType.Decimal, 3, status)
                                .AddParameter("Label", DbType.AnsiString, 80, label)
                                .AddParameter("SubStatus", DbType.Decimal, 3, substatus)
                                .AddParameter("SubLabel", DbType.AnsiString, 80, sublabel)
                                .AddParameter("CurrentStepId", DbType.Decimal, 9, currentStepId)
                                .AddParameter("Id", DbType.Decimal, 9, caseId)
                                .Execute(currentConnection, "Research");
        }

    }

}

