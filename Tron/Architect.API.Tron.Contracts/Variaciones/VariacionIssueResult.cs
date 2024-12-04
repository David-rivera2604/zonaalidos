using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Variaciones
{
    public class VariacionIssueResult
    {
        public VariacionIssueResult()
        {
            Recibos = new List<Receipt>();
            ProcessResult = new VariacionIssueProcessResult();
        }
        public VariacionIssueProcessResult ProcessResult { get; set; }
        public List<Receipt> Recibos { get; set; }
        public string McaError { get; set; }


    }

    public class VariacionIssueProcessResult
    {
        public string num_poliza { get; set; }
        public int num_riesgo { get; set; }
        public string num_poliza_definitivo { get; set; }
        public string txt_error { get; set; }
        public string txt_ruta_error { get; set; }
    }

    public class Receipt
    {
        public string num_poliza { get; set; }
        public int num_spto { get; set; }
        public double imp_recibo_spto { get; set; }
        public int num_cuota { get; set; }
        public int num_recibo { get; set; }
        public DateTime fec_efec_recibo { get; set; }
        public DateTime fec_vcto_recibo { get; set; }
        public string tip_situacion { get; set; }
        public int cod_mon { get; set; }
        public double imp_recibo { get; set; }
        public double imp_neta { get; set; }
        public double imp_recargo { get; set; }
        public double imp_imptos { get; set; }
        public double imp_boni { get; set; }
        public double imp_comis { get; set; }
        public int tip_coaseguro { get; set; }
        public int cod_agt { get; set; }
        public double imp_total_comis { get; set; }
        public double imp_interes { get; set; }
        public double imp_imptos_interes { get; set; }
        public DateTime fec_vcto_pago { get; set; }
    }
}
