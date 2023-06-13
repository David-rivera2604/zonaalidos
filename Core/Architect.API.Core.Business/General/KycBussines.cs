using Architect.API.Core.Contracts;
using Architect.API.Core.DataAccess;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Kyc 
    /// </summary>
    public static class KycBussines
    {

        public static int Insert_or_UpdateKYCpersona(Kycpersona kycpersona)
        {
            int result = 0;
            string id = kycpersona.numidentificacion.Replace("-", string.Empty);
            int count = KycDataBase.Count(id, "persona");
            if (count > 0)
            {
                result = KycDataBase.Update(id, kycpersona);
            }
            else
            {
                result = KycDataBase.Create(kycpersona);
            }

            return result;
        }
        public static int Insert_or_UpdateKYCjuridico(KycJuridico kycjuridico)
        {
            int result = 0;
            string id = kycjuridico.numidentificacion.Replace("-", string.Empty);
            int count = KycDataBase.Count(id, "juridico");
            if (count > 0)
            {
                result = KycDataBase.Update(id, kycjuridico);
            }
            else
            {
                result = KycDataBase.Create(kycjuridico);
            }

            return result;
        }

        public static Kycpersona RetrieveKycPersona(string Id)
        {
            string type = "persona";
            int count = KycDataBase.Count(Id, type);
            if (count > 0)
            {
                Kycpersona kycpersona = KycDataBase.Retrieve(type, Id);
                return kycpersona;
            }

            return null;
        }

        public static KycJuridico RetrieveKycJuridico(string Id)
        {
            string type = "juridico";
            int count = KycDataBase.Count(Id, type);
            if (count > 0)
            {
                KycJuridico kycjuridico = KycDataBase.Retrieve(type, Id);
                try
                {
                    kycjuridico.participacionaccionariaJur = JsonSerializer.Deserialize<List<Participador_Accionario>>(kycjuridico.participaciostring);
                }
                catch (Exception e)
                {
                    kycjuridico.participacionaccionariaJur = null;
                }
                return kycjuridico;
            }

            return null;
        }
    }
}
