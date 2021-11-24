using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia
{
	[XmlRoot(ElementName = "policyData")]
	public class PolicyData
	{
		[XmlElement(ElementName = "contratoReplicadoV2")]
		public string ContratoReplicadoV2 { get; set; } = "0";
		[XmlElement(ElementName = "txtPrecioBrutoTotal")]
		public string TxtPrecioBrutoTotal { get; set; }
		[XmlElement(ElementName = "txtNpoliza")]
		public string TxtNpoliza { get; set; } = "AUTO";
		[XmlElement(ElementName = "tipoPagador")]
		public string TipoPagador { get; set; } = "1";
		[XmlElement(ElementName = "txtFhInicio")]
		public string TxtFhInicio { get; set; }
		[XmlElement(ElementName = "txtFhFin")]
		public string TxtFhFin { get; set; }
		[XmlElement(ElementName = "txtProducto")]
		public string TxtProducto { get; set; } = "PTRI21CR2100000000020P";
		[XmlElement(ElementName = "txtDivisaProducto")]
		public string TxtDivisaProducto { get; set; }
		[XmlElement(ElementName = "idRegProducto")]
		public string IdRegProducto { get; set; } = "1048";
		[XmlElement(ElementName = "txtComentario")]
		public string TxtComentario { get; set; }
		[XmlElement(ElementName = "idRegFranquicia")]
		public string IdRegFranquicia { get; set; } = "-1";
		[XmlElement(ElementName = "idRegDivisaProducto")]
		public string IdRegDivisaProducto { get; set; } = "-1";
		[XmlElement(ElementName = "idRegRegion")]
		public string IdRegRegion { get; set; } = "-1";
		[XmlElement(ElementName = "txtFHExpiracion")]
		public string TxtFHExpiracion { get; set; }
		[XmlElement(ElementName = "idRegProductoComisionVariable")]
		public string IdRegProductoComisionVariable { get; set; }
		[XmlElement(ElementName = "txtCodDealer")]
		public string TxtCodDealer { get; set; } = "DL0001S";
		[XmlElement(ElementName = "txtFhCambioDivisa")]
		public string TxtFhCambioDivisa { get; set; }
		[XmlElement(ElementName = "txtCodPromocion")]
		public string TxtCodPromocion { get; set; }
		[XmlElement(ElementName = "txtSufijo")]
		public string TxtSufijo { get; set; } = "PTRI";
		[XmlElement(ElementName = "txtDuracion")]
		public string TxtDuracion { get; set; }
	}

	[XmlRoot(ElementName = "riskData")]
	public class RiskData
	{
		[XmlElement(ElementName = "CMBDESTINOSV")]
		public string CMBDESTINOSV { get; set; }
		[XmlElement(ElementName = "txtPaisDestino")]
		public string txtPaisDestino { get; set; }
		[XmlElement(ElementName = "txtAttribute1")]
		public string txtAttribute1 { get; set; }
		[XmlElement(ElementName = "txtAttribute2")]
		public string txtAttribute2 { get; set; }
		[XmlElement(ElementName = "txtAttribute3")]
		public string txtAttribute3 { get; set; }
		[XmlElement(ElementName = "txtCodigoFipe")]
		public string txtCodigoFipe { get; set; }
		[XmlElement(ElementName = "txtNotaFiscal")]
		public string txtNotaFiscal { get; set; }
		[XmlElement(ElementName = "txtDetalleVehiculo")]
		public string txtDetalleVehiculo { get; set; }
		[XmlElement(ElementName = "txtAttribute014")]
		public string txtAttribute014 { get; set; }
		[XmlElement(ElementName = "txtAttribute015")]
		public string txtAttribute015 { get; set; }
		[XmlElement(ElementName = "txtAttribute016")]
		public string txtAttribute016 { get; set; }
		[XmlElement(ElementName = "txtAttribute010")]
		public string txtAttribute010 { get; set; }
		[XmlElement(ElementName = "txtAttribute011")]
		public string txtAttribute011 { get; set; }
		[XmlElement(ElementName = "txtAttribute012")]
		public string txtAttribute012 { get; set; }
	}

	[XmlRoot(ElementName = "insuredData")]
	public class InsuredData
	{
		[XmlElement(ElementName = "txtNmAsegurado")]
		public string TxtNmAsegurado { get; set; }
		[XmlElement(ElementName = "txtApeAsegurado")]
		public string TxtApeAsegurado { get; set; }
		[XmlElement(ElementName = "cmbTipoCIF")]
		public string CmbTipoCIF { get; set; }
		[XmlElement(ElementName = "txtIdFiscal")]
		public string TxtIdFiscal { get; set; }
		[XmlElement(ElementName = "txtEmail")]
		public string TxtEmail { get; set; }
		[XmlElement(ElementName = "txtFhNacimiento")]
		public string TxtFhNacimiento { get; set; }
		[XmlElement(ElementName = "TXTEDADSV")]
		public string TXTEDADSV { get; set; }
		[XmlElement(ElementName = "txtDirAsegurado")]
		public string TxtDirAsegurado { get; set; }
		[XmlElement(ElementName = "txtMovil")]
		public string TxtMovil { get; set; }
		[XmlElement(ElementName = "txtNmPersonaContacto")]
		public string TxtNmPersonaContacto { get; set; }
		[XmlElement(ElementName = "txtTlfMovilPersonaContacto")]
		public string TxtTlfMovilPersonaContacto { get; set; }
	}

	[XmlRoot(ElementName = "CoberturaLimites")]
	public class CoberturaLimites
	{
		[XmlElement(ElementName = "chk_AC7_21_10_852")]
		public string chk_AC7_21_10_852 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC7_21_10_851")]
		public string chk_AC7_21_10_851 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AB8_21_10_980")]
		public string chk_AB8_21_10_980 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AB8_21_10_921")]
		public string chk_AB8_21_10_921 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AB8_21_10_714")]
		public string chk_AB8_21_10_714 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AB8_21_10_701")]
		public string chk_AB8_21_10_701 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AB8_21_10_697")]
		public string chk_AB8_21_10_697 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC0_21_10_915")]
		public string chk_AC0_21_10_915 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC0_21_10_700")]
		public string chk_AC0_21_10_700 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC8_21_10_847")]
		public string chk_AC8_21_10_847 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC8_21_10_846")]
		public string chk_AC8_21_10_846 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC1_21_10_890")]
		public string chk_AC1_21_10_890 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC1_21_10_883")]
		public string chk_AC1_21_10_883 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC1_21_10_707")]
		public string chk_AC1_21_10_707 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC6_21_10_856")]
		public string chk_AC6_21_10_856 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC6_21_10_712")]
		public string chk_AC6_21_10_712 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC3_21_10_711")]
		public string chk_AC3_21_10_711 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC2_21_10_710")]
		public string chk_AC2_21_10_710 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AB9_21_10_979")]
		public string chk_AB9_21_10_979 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AB9_21_10_695")]
		public string chk_AB9_21_10_695 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AB9_21_10_694")]
		public string chk_AB9_21_10_694 { get; set; } = "-1";
		[XmlElement(ElementName = "chk_AC4_21_10_699")]
		public string chk_AC4_21_10_699 { get; set; } = "-1";
	}

	[XmlRoot(ElementName = "coberData")]
	public class CoberData
	{
		[XmlElement(ElementName = "chk_AC7_21_10")]
		public string chk_AC7_21_10 { get; set; } = "1";
		[XmlElement(ElementName = "chk_AB8_21_10")]
		public string chk_AB8_21_10 { get; set; } = "1";
		[XmlElement(ElementName = "chk_AC0_21_10")]
		public string chk_AC0_21_10 { get; set; } = "1";
		[XmlElement(ElementName = "chk_AC8_21_10")]
		public string chk_AC8_21_10 { get; set; } = "1";
		[XmlElement(ElementName = "chk_AC1_21_10")]
		public string chk_AC1_21_10 { get; set; } = "1";
		[XmlElement(ElementName = "chk_AC6_21_10")]
		public string chk_AC6_21_10 { get; set; } = "1";
		[XmlElement(ElementName = "chk_AC3_21_10")]
		public string chk_AC3_21_10 { get; set; } = "1";
		[XmlElement(ElementName = "chk_AC2_21_10")]
		public string chk_AC2_21_10 { get; set; } = "1";
		[XmlElement(ElementName = "chk_AB9_21_10")]
		public string chk_AB9_21_10 { get; set; } = "1";
		[XmlElement(ElementName = "chk_AC4_21_10")]
		public string chk_AC4_21_10 { get; set; } = "1";
		[XmlElement(ElementName = "CoberturaLimites")]
		public CoberturaLimites CoberturaLimites { get; set; }
	}

	[XmlRoot(ElementName = "tomadorData")]
	public class TomadorData
	{
		[XmlElement(ElementName = "txtNmAsegurado_policyHolder")]
		public string TxtNmAsegurado_policyHolder { get; set; }
		[XmlElement(ElementName = "txtApeAsegurado_policyHolder")]
		public string TxtApeAsegurado_policyHolder { get; set; }
		[XmlElement(ElementName = "cmbTipoCIF_policyHolder")]
		public string CmbTipoCIF_policyHolder { get; set; }
		[XmlElement(ElementName = "txtIdFiscal_policyHolder")]
		public string TxtIdFiscal_policyHolder { get; set; }
	}

	[XmlRoot(ElementName = "parameters")]
	public class Parameters
	{
		[XmlElement(ElementName = "origenRecepcion")]
		public string OrigenRecepcion { get; set; } = "1";
		[XmlElement(ElementName = "noAceptaOfertasCom")]
		public string NoAceptaOfertasCom { get; set; } = "0";
		[XmlElement(ElementName = "permitirEnvioPublicidad")]
		public string PermitirEnvioPublicidad { get; set; } = "-1";
		[XmlElement(ElementName = "permitirVentaDistancia")]
		public string PermitirVentaDistancia { get; set; } = "-1";
		[XmlElement(ElementName = "permitirEstudioMercado")]
		public string PermitirEstudioMercado { get; set; } = "-1";
		[XmlElement(ElementName = "adjuntarCondiciones")]
		public string AdjuntarCondiciones { get; set; } = "1";
		[XmlElement(ElementName = "infoValidada")]
		public string InfoValidada { get; set; } = "1";
		[XmlElement(ElementName = "action")]
		public string Action { get; set; } = "A";
		[XmlElement(ElementName = "estadoContrato")]
		public string EstadoContrato { get; set; } = "1";
		[XmlElement(ElementName = "posicionTomador")]
		public string PosicionTomador { get; set; } = "1";
		[XmlElement(ElementName = "posAsegEliminados")]
		public string PosAsegEliminados { get; set; }
		[XmlElement(ElementName = "divisaCobro")]
		public string DivisaCobro { get; set; } = "0";
	}

	[XmlRoot(ElementName = "root")]
	public class Root
	{
		[XmlElement(ElementName = "policyData")]
		public PolicyData PolicyData { get; set; }
		[XmlElement(ElementName = "riskData")]
		public RiskData RiskData { get; set; }
		[XmlElement(ElementName = "insuredData")]
		public List<InsuredData> InsuredData { get; set; }
		[XmlElement(ElementName = "coberData")]
		public CoberData CoberData { get; set; }
		[XmlElement(ElementName = "ecasData")]
		public string EcasData { get; set; }
		[XmlElement(ElementName = "tomadorData")]
		public TomadorData TomadorData { get; set; }
		[XmlElement(ElementName = "parameters")]
		public Parameters Parameters { get; set; }
	}

}
