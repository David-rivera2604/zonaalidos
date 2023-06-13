using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.Security
{
    public class ClientesInicioResponse
    {
        public int CompanyId { get; set; }

        public string Titulo1 { get; set; }
        public string Descripcion1 { get; set; }
        public string Frase1 { get; set; }
        public string Link1 { get; set; }
        //public byte[] Imagen1 { get; set; }
        //public string imagen1String { get; set; }
        public string Imagen1 { get; set; }

        public string Titulo2 { get; set; }
        public string Descripcion2 { get; set; }
        public string Frase2 { get; set; }
        public string Link2 { get; set; }
        public string Imagen2 { get; set; }

        public string Titulo3 { get; set; }
        public string Descripcion3 { get; set; }
        public string Frase3 { get; set; }
        public string Link3 { get; set; }
        public string Imagen3 { get; set; }

        public string Titulo4 { get; set; }
        public string Descripcion4 { get; set; }
        public string Frase4 { get; set; }
        public string Link4 { get; set; }
        public string Imagen4 { get; set; }

    }
}
