using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using Scriban.Functions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Architect.API.Core.Business.Security
{
    /// <summary>
    /// Manejo de los usuarios registrados.
    /// </summary>
    public static partial class UserMember
    {

        public static Architect.API.Core.Contracts.Security.UserMember Create(int companyId, int userId, Architect.API.Core.Contracts.Security.UserMember item, int cod_agt = 0)
        {
            Architect.API.Core.Contracts.Security.UserMember result = item;
            string originalPassword = item.Password;
            if (result.UserId.IsEmpty())
                result.UserId = Architect.API.Core.DataAccess.Security.UserMember.RetrieveLastKeyCustom() + 1;

            if (item.Password.IsNotEmpty())
            {
                result.Password = Architect.Utilities.Helpers.CryptSupport.EncryptString(item.Password);
            }

            result.CompanyId = companyId;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;
            result.PasswordChangedDate = DateTime.Today;
            result.responseTronSubAgent = "";

            int affectedRows = DataAccess.Security.UserMember.Create(result);

            //Se crea subagente en TRON
            string[] tenantList = ConfigurationManager.AppSettings["Mapfre.Tron.CreaSubAgentes"].Split(new char[] {';'});
            bool affectedRowsSubAgent = true;
            string tip_docum = null;
            string cod_docum = null;
            int cod_agt_ = 0;
            foreach (string tenant in tenantList)
            {

                if (tenant == Convert.ToString(companyId))
                {
                    if (cod_agt == 0)
                    {
                        cod_agt_ = item.cod_agt;
                    }
                    else
                    {
                        cod_agt_ = cod_agt;
                    }

                    switch (item.IdentificationType)
                    {
                        case 1:
                            tip_docum = "CNA";
                            cod_docum = item.Identification.Remove(0, 1).Replace("-", "");
                            break;
                        case 2:
                            tip_docum = "CRE";
                            cod_docum = item.Identification.Replace("-", "");
                            break;
                        case 3:
                            tip_docum = "PAS";
                            break;
                        case 4:
                            tip_docum = "CJU"; 
                            break;
                    }

                    var subAgent = new Contracts.Security.SubAgent
                    {
                        cod_cia = 1,
                        tip_docum =  tip_docum,
                        cod_docum = cod_docum,
                        nom1_tercero = item.FirstName,
                        ape1_tercero = item.LastName,
                        ape2_tercero = "",
                        email_com = item.EMail,
                        cod_agt = cod_agt_,
                        cod_emp_agt = 0,
                        mca_inh = "N"

                    };
                    
                    affectedRowsSubAgent = DataAccess.Security.Tron.Create_subAgent(subAgent);
                    if (affectedRowsSubAgent)
                    {
                        result.responseTronSubAgent = "El Sub Agente fue Creado Correctamente en Sistema";
                    }
                    else
                    {
                        result.responseTronSubAgent = "El Sub Agente no se pudo crear en Sistema, intente nuevamente";

                    }
                }

            }

            //Se sincroniza el usuario con Okta para los tenants habilitados
            if (Architect.API.Core.Business.Security.OktaUserManagement.IsTenantEnabled(companyId))
            {
                var oktaItem = new Architect.API.Core.Contracts.Security.UserMember
                {
                    EMail = item.EMail,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    PhoneNumber = item.PhoneNumber,
                    Password = originalPassword
                };

                string oktaMsg = Architect.API.Core.Business.Security.OktaUserManagement.Create(oktaItem);
                if (string.IsNullOrEmpty(result.responseTronSubAgent))
                    result.responseTronSubAgent = oktaMsg;
                else
                    result.responseTronSubAgent = result.responseTronSubAgent + " | " + oktaMsg;
            }

            //Se sincroniza el usuario con Invitados B2B Cloud para los tenants habilitados
            if (Architect.API.Core.Business.Security.EntraIdUserManagement.IsTenantEnabled(companyId))
            {
                string entraMsg = Architect.API.Core.Business.Security.EntraIdUserManagement.Create(item);
                if (string.IsNullOrEmpty(result.responseTronSubAgent))
                    result.responseTronSubAgent = entraMsg;
                else
                    result.responseTronSubAgent = result.responseTronSubAgent + " | " + entraMsg;
            }

            if (affectedRows > 0 )
            {
                SynchronizeUserRoleMember(companyId, userId, result.UserId, item.Roles);
                MapLookups(companyId, result);
                Core.Business.General.ChangeSet.Create(1002, result.UserId, companyId, "Creación", string.Format("Se creó el usuario '{0}'", result.UserName), userId, result);

                Architect.Utilities.Cache.RemoveStartWith("SpecFlow");
            }
            return result;
        }

        public static List<Architect.API.Core.Contracts.Security.UserMember> Retrieve(int companyId, int securityLevel, string filter, string recordStatus)
        {
            List<Architect.API.Core.Contracts.Security.UserMember> result = Architect.API.Core.DataAccess.Security.UserMember.RetrieveAll(companyId, securityLevel, DataAccess.Security.UserMember.FilterBuilder(filter, false));

            foreach (Architect.API.Core.Contracts.Security.UserMember item in result)
            {
                MapLookups(companyId, item);
            }

            return result;
        }

        public static Architect.API.Core.Contracts.Security.UserMember RetrieveById(int companyId, int id, bool includeRoleInformation = false)
        {
            Architect.API.Core.Contracts.Security.UserMember result = Architect.API.Core.DataAccess.Security.UserMember.Retrieve(id, companyId);

            MapLookups(companyId, result);
            if (includeRoleInformation && result.IsNotEmpty())
            {
                List<Architect.API.Core.Contracts.Security.RoleMember> rols = DataAccess.Security.UserRoleMember.RetrieveLookByUserId(id, companyId);
                result.Roles = (from r in rols
                                select new Architect.Utilities.Contracts.LookUpValue() { Code = r.RoleId.ToString(), Description = r.Description }).ToList();
            }

            if (result.IsNotEmpty())
            {
                if (result.CustomData.IsNotEmpty())
                {
                    result.Extent = Newtonsoft.Json.Linq.JObject.Parse(result.CustomData);
                    result.CustomData = string.Empty;
                }
                result.Password = "XXXXXXXX";
            }
            return result;
        }

        public static Architect.API.Core.Contracts.Security.UserMember Update(int companyId, int userId, int id, Architect.API.Core.Contracts.Security.UserMember item, int cod_agt = 0)
        {

            Architect.API.Core.Contracts.Security.UserMember result = Architect.API.Core.DataAccess.Security.UserMember.Retrieve(id, companyId);
            string originalPassword = item.Password;
            result.UserName = item.UserName;
            result.EMail = item.EMail;
            if (item.Password != "XXXX")
            {
                result.OldPassword = result.Password;
                result.Password = PasswordHasher.HashPassword(item.Password);
            }
            result.FirstName = item.FirstName;
            result.LastName = item.LastName;
            //result.FailedPasswordCount = item.FailedPasswordCount;
            result.SecurityLevel = item.SecurityLevel;
            result.IsLockedOut = item.IsLockedOut;

            if (result.IsLockedOut && result.LockedOutDate.IsEmpty())
            {
                result.LockedOutDate = DateTime.Now;
            }
            else if (!result.IsLockedOut && result.LockedOutDate.IsNotEmpty())
            {
                result.LockedOutDate = DateTime.MinValue;
            }
            //result.PasswordChangedDate = item.PasswordChangedDate;
            //result.OneTimePassword = item.OneTimePassword;
            //result.LoginDate = item.LoginDate;
            //result.ManagerId = item.ManagerId;
            result.AccessKey = item.AccessKey;

            result.IsService = item.IsService;
            result.Is2FAEnabled = item.Is2FAEnabled;
            
            result.BranchOffice = item.BranchOffice;
            result.Reference = item.Reference;
            result.Position = item.Position;
            result.PhoneNumber = item.PhoneNumber;
            result.SalesChannel = item.SalesChannel;

            result.IdentificationType = item.IdentificationType;
            result.Identification = item.Identification;
            result.BirthDate = item.BirthDate;

            if (item.Extent.IsNotEmpty())
            {
                result.CustomData = Newtonsoft.Json.JsonConvert.SerializeObject(item.Extent);
            }

            //result.CustomData = item.CustomData;
            result.RecordStatus = item.RecordStatus;

            result.UserId = id;
            result.CompanyId = companyId;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;
            result.responseTronSubAgent = "";

            int affectedRows = Architect.API.Core.DataAccess.Security.UserMember.Update(result);
            //Se crea subagente en TRON
            string[] tenantList = ConfigurationManager.AppSettings["Mapfre.Tron.CreaSubAgentes"].Split(new char[] { ';' });
            bool affectedRowsSubAgent = true;
            string tip_docum = null;
            string cod_docum = null;
            int cod_agt_ = 0;

            foreach (string tenant in tenantList)
            {

                if (tenant == Convert.ToString(companyId))
                {
                   
                        if (cod_agt == 0)
                        {
                            cod_agt_ = item.cod_agt;
                        }
                        else
                        {
                            cod_agt_ = cod_agt;
                        }

                        switch (item.IdentificationType)
                        {
                            case 1:
                                tip_docum = "CNA";
                                cod_docum = item.Identification.Remove(0, 1).Replace("-", "");
                                break;
                            case 2:
                                tip_docum = "CRE";
                                cod_docum = item.Identification.Replace("-", "");
                                break;
                            case 3:
                                tip_docum = "PAS";
                                break;
                            case 4:
                                tip_docum = "CJU";
                                break;
                        }

                        var subAgent = new Contracts.Security.SubAgent
                    {
                        cod_cia = 1,
                        tip_docum = tip_docum,
                        cod_docum = cod_docum,
                        nom1_tercero = item.FirstName,
                        ape1_tercero = item.LastName,
                        ape2_tercero = "",
                        email_com = item.EMail,
                        cod_agt = cod_agt_,
                        cod_emp_agt = 0,
                        mca_inh = "N"

                    };
                    //string json_tercero = JsonSerializer.Serialize(subAgent);
                    affectedRowsSubAgent = DataAccess.Security.Tron.Create_subAgent(subAgent);

                    if (affectedRowsSubAgent)
                    {
                        result.responseTronSubAgent = "El Sub Agente fue Actualizado Correctamente en Sistema";
                    }
                    else
                    {
                        result.responseTronSubAgent = "El Sub Agente no se pudo actualizar en Sistema, intente nuevamente";

                    }
                }

            }
            //Se sincroniza el usuario con Okta para los tenants habilitados
            if (Architect.API.Core.Business.Security.OktaUserManagement.IsTenantEnabled(companyId))
            {
                var oktaItem = new Architect.API.Core.Contracts.Security.UserMember
                {
                    EMail = item.EMail,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    PhoneNumber = item.PhoneNumber,
                    Password = originalPassword
                };

                string oktaMsg = Architect.API.Core.Business.Security.OktaUserManagement.Update(oktaItem);
                if (string.IsNullOrEmpty(result.responseTronSubAgent))
                    result.responseTronSubAgent = oktaMsg;
                else
                    result.responseTronSubAgent = result.responseTronSubAgent + " | " + oktaMsg;
            }

            //Se sincroniza el usuario con Invitados B2B Cloud para los tenants habilitados
            if (Architect.API.Core.Business.Security.EntraIdUserManagement.IsTenantEnabled(companyId))
            {
                string entraMsg = Architect.API.Core.Business.Security.EntraIdUserManagement.Update(item);
                if (string.IsNullOrEmpty(result.responseTronSubAgent))
                    result.responseTronSubAgent = entraMsg;
                else
                    result.responseTronSubAgent = result.responseTronSubAgent + " | " + entraMsg;
            }

            if (affectedRows > 0 )
            {
                SynchronizeUserRoleMember(companyId, userId, id, item.Roles);

                MapLookups(companyId, result);
                Core.Business.General.ChangeSet.Create(1002, item.UserId, companyId, "Modificación", string.Format("Se modificó el usuario '{0}'", result.UserName), userId, result);

                Architect.Utilities.Cache.RemoveStartWith("SpecFlow");
            }
            return result;
        }

        private static void SynchronizeUserRoleMember(int companyId, int userId, int id, List<Architect.Utilities.Contracts.LookUpValue> currentRoles)
        {
            List<Architect.API.Core.Contracts.Security.UserRoleMember> roles = DataAccess.Security.UserRoleMember.RetrieveByUserId(id, companyId);
            if (roles.IsEmpty())
            {
                roles = new List<Contracts.Security.UserRoleMember>();
            }
            if (currentRoles.IsNotEmpty())
            {
                //Agrega un nuevo registro o se cambia uno existente                
                Architect.API.Core.Contracts.Security.UserRoleMember toAdd = null;
                foreach (Architect.Utilities.Contracts.LookUpValue newItem in currentRoles)
                {
                    toAdd = roles.Find(r => r.RoleId.ToString() == newItem.Code);

                    if (toAdd.IsEmpty())
                    {
                        toAdd = new Architect.API.Core.Contracts.Security.UserRoleMember();
                        roles.Add(toAdd);
                        toAdd.UserId = id;
                        toAdd.RoleId = Convert.ToInt32(newItem.Code);

                        toAdd.CompanyId = companyId;
                        toAdd.UpdateUserCode = userId;
                        toAdd.UpdateDate = DateTime.Now;
                        toAdd.Id = DataAccess.Security.UserRoleMember.RetrieveLastKey() + 1;

                        //toAdd.RoleId = DataAccess.Security.UserRoleMember.RetrieveLastKey() + 1;
                        DataAccess.Security.UserRoleMember.CreateCustom(toAdd);
                    }
                    else
                    {
                        toAdd.CompanyId = companyId;
                        toAdd.UpdateUserCode = userId;
                        toAdd.UpdateDate = DateTime.Now;
                        //Esta tabla o posee datos adicional por lo tanto solo se agregar
                        DataAccess.Security.UserRoleMember.UpdateCustom(toAdd);
                    }
                }
            }

            //Elimina los registros que no venga en la lista nueva
            if (roles?.Count > 0)
            {
                foreach (Architect.API.Core.Contracts.Security.UserRoleMember currentRole in roles)
                {
                    if (currentRoles.Find(r => r.Code == currentRole.RoleId.ToString()).IsEmpty())
                    {
                        DataAccess.Security.UserRoleMember.DeleteByKey(currentRole.UserId, currentRole.RoleId);
                    }
                }
            }
        }

        public static bool Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.Security.UserMember result = Architect.API.Core.DataAccess.Security.UserMember.Retrieve(id, companyId);
            int affectedRows = 0;
            if (result.IsNotEmpty())
            {
                DataAccess.Security.UserRoleMember.DeleteByKey(id);

                affectedRows = Architect.API.Core.DataAccess.Security.UserMember.Delete(id, companyId);
                if (affectedRows > 0)
                {
                    //Se sincroniza la eliminación del usuario con Okta para los tenants habilitados
                    if (Architect.API.Core.Business.Security.OktaUserManagement.IsTenantEnabled(companyId))
                    {
                        Architect.API.Core.Business.Security.OktaUserManagement.Delete(result.EMail);
                    }

                    //Se sincroniza la eliminación del usuario con Invitados B2B Cloud para los tenants habilitados
                    if (Architect.API.Core.Business.Security.EntraIdUserManagement.IsTenantEnabled(companyId))
                    {
                        Architect.API.Core.Business.Security.EntraIdUserManagement.Delete(result);
                    }

                    Core.Business.General.ChangeSet.Create(1002, id, companyId, "Eliminar", string.Format("Se eliminó el usuario '{0}'", result.UserName), userId, result);
                    Architect.Utilities.Cache.RemoveStartWith("SpecFlow");
                }
            }
            return affectedRows > 0;
        }

        public static void SendCredentials(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.Security.UserMember result = Architect.API.Core.DataAccess.Security.UserMember.Retrieve(id, companyId);

            result.Password = Architect.Utilities.Helpers.CryptSupport.EncryptString("6329");
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            int affectedRows = Architect.API.Core.DataAccess.Security.UserMember.Update(result);
            if (affectedRows > 0)
            {
                Core.Business.General.ChangeSet.Create(1002, result.UserId, companyId, "Modificación", string.Format("Se modificó el usuario '{0}'", result.UserName), userId, result);
                MapLookups(companyId, result);
            }
            result.Password = "6329";
            API.Core.Business.General.Mail.SendByTemplate("Notify_UserCredentials", companyId, userId, result.UserId, result);
        }

        public static List<Contracts.General.Error> Validate(Architect.API.Core.Contracts.Security.UserMember source, bool isnew)
        {
            const string group = "UserMember";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //UserId:
            if (!isnew && source.UserId.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "UserId", Message = "Debe indicar el identificación" });

            //UserName:
            if (source.UserName.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "UserName", Message = "Debe indicar el usuario" });

            //EMail:
            if (source.EMail.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "EMail", Message = "Debe indicar el correo" });

            //Password:
            if (source.Password.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "Password", Message = "Debe indicar la clave" });

            //OldPassword:

            //FirstName:
            if (source.FirstName.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "FirstName", Message = "Debe indicar el nombre" });

            //LastName:
            if (source.LastName.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "LastName", Message = "Debe indicar el apellidos" });

            //FailedPasswordCount:

            //SecurityLevel:

            //LockedOutDate:

            //PasswordChangedDate:

            //OneTimePassword:

            //LoginDate:

            //ManagerId:

            //AccessKey:

            //CustomData:

            //RecordStatus:
            if (source.RecordStatus.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "RecordStatus", Message = "Debe indicar el estado del registro" });

            return result;
        }

        private static void MapLookups(int companyId, Architect.API.Core.Contracts.Security.UserMember item)
        {
            if (item.IsNotEmpty())
            {
                if (item.IdentificationType.IsNotEmpty())
                    item.IdentificationTypeDesc = Common.Lkp("DocumentType", companyId).Find(x => x.Code == item.IdentificationType.ToString()).Description;
                if (item.BranchOffice.IsNotEmpty())
                    item.BranchOfficeDesc = Common.Lkp("BranchOffice", companyId).Find(x => x.Code == item.BranchOffice.ToString()).Description;
                if (item.Position.IsNotEmpty())
                    item.PositionDesc = Common.Lkp("Position", companyId).Find(x => x.Code == item.Position.ToString()).Description;
                if (item.SalesChannel.IsNotEmpty())
                    item.SalesChannelDesc = Common.Lkp("SalesChannel", companyId).Find(x => x.Code == item.SalesChannel.ToString()).Description;
                if (item.RecordStatus.IsNotEmpty())
                    item.RecordStatusDesc = Common.Lkp("EstadoRegistro", companyId).Find(x => x.Code == item.RecordStatus.ToString()).Description;

            }
        }
    }
}