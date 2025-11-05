using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    /// <summary>
    /// Estructura que contiene la información de autenticación del sitio generada de acuerdo al WSSE UsernameToken Profile 1.1
    /// </summary>
    public class Auth
    {
        public string login { get; set; }
        public string tranKey { get; set; }
        public string nonce { get; set; }
        public string seed { get; set; }

    }
}
