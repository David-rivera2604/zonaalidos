using System;
using System.Collections.Generic;
using System.Linq;
using Architect.Utilities.Extensions;

namespace Architect.API.Core.Business.General
{

    public static partial class ChangeColor
    {
        public static Architect.API.Core.Contracts.General.ChangeColorResult Update(Architect.API.Core.Contracts.Security.ColoresResponse item)
        {
            Architect.API.Core.Contracts.Security.ColoresResponse result = item;
          
                if (Architect.API.Core.DataAccess.General.ColorKey.Update(result) > 0)
                {
                    
                }
            
            return new Architect.API.Core.Contracts.General.ChangeColorResult() { ColoresRespon = result};
        }

        

    }
}