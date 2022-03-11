using System.Collections.Generic;

namespace Architect.API.Core.Business.Security
{
    /// <summary>
    /// Manejo de los usuarios registrados.
    /// </summary>
    public static partial class UserMember
    {
        /// <summary>
        /// Recupera una lista con la información de correo electrónico de los usuario asociados a un rol.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="roleName">Nombre del rol usando para filtrar la lista</param>
        /// <returns>Lista de correos electrónico</returns>
        public static Dictionary<string, string> EmailListByRolename(int companyId, string roleName)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            roleName += ",,,";
            List<Architect.API.Core.Contracts.Security.UserMember> userList = DataAccess.Security.UserMember.EmailInfoByRoleName(companyId, roleName.Split(',')[0].Trim().ToLower(), roleName.Split(',')[1].Trim().ToLower(), roleName.Split(',')[2].Trim().ToLower());

            foreach (Architect.API.Core.Contracts.Security.UserMember userItem in userList)
            {
                if (!result.ContainsKey(userItem.EMail))
                {
                    result.Add(userItem.EMail, string.Format("{0} {1}", userItem.FirstName, userItem.LastName));
                }               
            }

            return result;
        }
    }
}
