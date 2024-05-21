using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Architect.SICOP.WcfService.Business
{
    public sealed class ElectronicWarranty
    {
        public static Contracts.ExecGurtReponse Ejecutar_O_Liberar(Contracts.ExecGurtRequest value)
        {
            Contracts.ExecGurtReponse result = new Contracts.ExecGurtReponse() { Confirmation = "0", Msg_err = string.Empty };

            if (value != null && !string.IsNullOrEmpty(value.Guarantee_Number) && !string.IsNullOrEmpty(value.Guarantee_sequencenumber))
            {
                Contracts.ElectronicWarranty warranty = DataAccess.ElectronicWarranty.RetrieveByGuaranteeNumber(value.Guarantee_Number);

                if (warranty == null)
                {
                    result.Confirmation = "10";
                    result.Msg_err = "La garantía no existe";
                }
                if (result.Confirmation == "0" && warranty.Codigo_Proceso != string.Empty && warranty.Codigo_Proceso == value.codigo_proceso)
                {
                    result.Confirmation = "21";
                    result.Msg_err = "La información enviada ya se encuentra procesada";
                }
                if (result.Confirmation == "0" && warranty.Codigo_Proceso != string.Empty)
                {
                    result.Confirmation = "25";
                    result.Msg_err = string.Format("La garantía ya fue ejecutada o liberada con el código del proceso #{0}", warranty.Codigo_Proceso);
                }
                if (result.Confirmation == "0" && warranty.Guarantee_sequencenumber != value.Guarantee_sequencenumber)
                {
                    result.Confirmation = "22";
                    result.Msg_err = "Sólo se pueden liberar/ejecutar garantías con la última secuencia";
                }
                if (result.Confirmation == "0" && warranty.Moneda != value.Moneda)
                {
                    result.Confirmation = "24";
                    result.Msg_err = "Tipo de moneda no corresponde a la original";
                }

                if (result.Confirmation == "0")
                {
                    if (value.Metodo == "0")
                        value.MetodoDesc = "ejecutar";
                    if (value.Metodo == "1")
                        value.MetodoDesc = "liberar";
                    DataAccess.ElectronicWarranty.Update(warranty.ID, value.Metodo, value.codigo_proceso, value.Amount, value.Contents, value.cuenta_Cliente);

                    API.Core.Business.General.Mail.EnqueueSend("Default", 0, 0, 0, "Notify_ReleaseGuarantee", null, null, null, value, null);
                }
            }
            else
            {
                result.Confirmation = "3";
                result.Msg_err = "La solicitud no puede estar vacia";
            }


            return result;
        }

    }
}