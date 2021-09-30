using System.Collections.Generic;

namespace Architect.API.Core.Business.Security
{
    /// <summary>
    /// Manejo de los usuarios registrados.
    /// </summary>
    public static partial class UserMember
    {
        /// <summary>
        /// Recupera una lista con la información de correo electronico de los usuario asociados a un rol.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="roleName">Nombre del rol usando para filtrar la lista</param>
        /// <returns>Lista de correos electronicos</returns>
        public static Dictionary<string, string> EmailListByRolename(int companyId, string roleName)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            List<Architect.API.Core.Contracts.Security.UserMember> userList = DataAccess.Security.UserMember.EmailInfoByRoleName(companyId, roleName);

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
