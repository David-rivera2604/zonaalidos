using System;
using System.Collections.Generic;
using Architect.Utilities.Extensions;

namespace Architect.API.Core.Business.General
{
    public static partial class Rules
    {

        public static Architect.API.Core.Contracts.General.Rules Create(int companyId, int userId, Architect.API.Core.Contracts.General.Rules item)
        {
            Architect.API.Core.Contracts.General.Rules result = item;
            int affectedRows = 0;

            if (result.Id.IsEmpty())
                result.Id = Architect.API.Core.DataAccess.General.Rules.RetrieveLastKey() + 1;

            result.CompanyId = companyId;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            affectedRows = Architect.API.Core.DataAccess.General.Rules.Create(result);
            if (affectedRows > 0)
            {
                Core.Business.General.ChangeSet.Create(1002, result.Id, companyId, "Creación", string.Format("Se creó un registro con la identificación '{0}'", result.Id), userId, result);
                MapLookups(result, companyId);
            }
            return result;
        }

        public static List<Architect.API.Core.Contracts.General.Rules> Retrieve(int companyId, string filter)
        {
            List<Architect.API.Core.Contracts.General.Rules> result = Architect.API.Core.DataAccess.General.Rules.RetrieveAll(companyId, filter);

            foreach (Architect.API.Core.Contracts.General.Rules item in result)
            {
                MapLookups(item, companyId);
            }

            return result;
        }

        public static Architect.API.Core.Contracts.General.Rules RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.Rules result = Architect.API.Core.DataAccess.General.Rules.Retrieve(id, companyId);

            MapLookups(result, companyId);

            return result;
        }

        public static Architect.API.Core.Contracts.General.Rules Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.Rules item)
        {
            Architect.API.Core.Contracts.General.Rules result = item;
            int affectedRows = 0;

            result.Id = id;
            result.CompanyId = companyId;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            affectedRows = Architect.API.Core.DataAccess.General.Rules.Update(result);
            if (affectedRows > 0)
            {
                Core.Business.General.ChangeSet.Create(1002, item.Id, companyId, "Modificación", string.Format("Se modificó el registro con la identificación '{0}'", result.Id), userId, result);
                MapLookups(result, companyId);
			}
            return result;
        }

        public static bool Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.Rules result = Architect.API.Core.DataAccess.General.Rules.Retrieve(id, companyId);
            int affectedRows = 0;
            if (result.IsNotEmpty())
            {
                affectedRows = Architect.API.Core.DataAccess.General.Rules.Delete(id, companyId);
                if (affectedRows > 0)
                {
                    Core.Business.General.ChangeSet.Create(1002, id, companyId, "Eliminar", string.Format("Se eliminó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return affectedRows > 0;
        }

        public static List<Contracts.General.Error> Validate(Architect.API.Core.Contracts.General.Rules source, bool isnew)
        {
            string group = "Rules";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if (!isnew && source.Id.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el identificación" });

            //EntityType:

            //Action:
            if (source.Action.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "Action", Message = "Debe indicar el action" });

            //Sequence:
            if (!isnew && source.Sequence.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "Sequence", Message = "Debe indicar el secuencia" });

            //Description:

            //Statement:

            //RecordStatus:
            if (source.RecordStatus.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "RecordStatus", Message = "Debe indicar el estado del registro" });

            return result;
        }

        private static void MapLookups(Architect.API.Core.Contracts.General.Rules item, int companyId)
        {
            if (item.IsNotEmpty())
            {
                if (item.RecordStatus.IsNotEmpty())
                    item.RecordStatusDesc = Common.Lkp("EstadoRegistro", companyId).Find(x => x.Code == item.RecordStatus.ToString()).Description;

            }
        }

    }
}
