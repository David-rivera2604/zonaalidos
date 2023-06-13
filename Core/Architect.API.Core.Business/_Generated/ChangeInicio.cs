using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Architect.Utilities.Extensions;

namespace Architect.API.Core.Business.General
{

    public static partial class ChangeInicio
    {
        public static Architect.API.Core.Contracts.General.ChangeInicioResult Update(Architect.API.Core.Contracts.Security.ClientesInicioResponse item, Core.Contracts.Security.Token tokenInfo)
        {
            Architect.API.Core.Contracts.Security.ClientesInicioResponse result = item;

            if (Architect.API.Core.DataAccess.General.InicioUpdate.Update(result) > 0)
            {


            }

            return new Architect.API.Core.Contracts.General.ChangeInicioResult() { ClientesInicioResponse = result };
        }



    }
}