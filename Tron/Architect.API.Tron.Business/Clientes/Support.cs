namespace Architect.API.Tron.Business.Clientes
{
    public static class Support
    {
        public static string ExternalURL(string identificationType, string identification)
        {
            string type = "";

            switch (identificationType)
            {
                case "1": //Cédula
                    type = "CNA";
                    break;
                case "2": //Residencia
                    type = "CRE";
                    break;
                case "3": //Pasaporte
                    type = "PAS";
                    break;
                case "4": //Cédula jurídica
                    type = "CJU";
                    break;
                    //CIN
                    //EEX
            }

            return string.Format("http://localhost:8080/security/login?user=1_{0}_{1}&password=Mapfre20", type, identification.Replace("-", string.Empty));
        }
    }
}
