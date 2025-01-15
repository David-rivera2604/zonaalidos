UPDATE VISUALIZATIONS SET "TYPE"=1, CAPTION='Recibos pendientes', DESCRIPTION='Mi cuenta - Agente conectado', "STATEMENT"='SELECT   a.num_poliza, a.fec_efec_poliza, a.fec_vcto_poliza, a.tip_docum, a.cod_docum, 1 num_spto,
         a.cod_agt, d.NOM_COMPLETO, em_k_Mapfre_Query_Contract_mcr.f_obtener_total_recibo(a.cod_cia,c.num_recibo) imp_recibo, em_k_Mapfre_Query_Contract_mcr.f_obtener_total_comision(a.cod_cia,c.num_recibo)  imp_comis,
         a.tip_gestor, em_k_Mapfre_Query_Contract_mcr.f_obtener_num_tarjeta(a.cod_cia, a.num_poliza) num_tarjeta, c.fec_efec_recibo fec_vcto_recibo, c.tip_situacion, c.num_recibo, c.fec_valor,a.tip_docum || ''-'' || a.cod_docum key, d.NOM_COMPLETO NOM_COMPLETO2,
         DECODE(c.tip_situacion, ''RE'', ''REMESADO'', ''EP'', ''PENDIENTE'') tip_situacion_desc,
         DECODE(a.tip_gestor, ''AG'', ''VENTANILLA'', ''BA'', ''CUENTA'', ''TA'', ''TARJETA'') tip_gestor_desc,
         a1331.tlf_numero, a1331.tlf_numero_com, a1331.fax_numero, a1331.fax_numero_com,
         nvl(upper(a1331.email),''***'') email, nom_domicilio1, nom_domicilio2, nom_domicilio3, a400.cod_mon_iso nom_mon
    FROM a2000030 a,
         a2990700 c,
         v1001390 d,
         a1001331 a1331,
         a1000400 a400
   WHERE a.cod_cia  = {app.P_COD_CIA}
     AND a.cod_agt  = {app.P_COD_AGT}
     AND a.cod_ramo not in (230)
     AND a.mca_spto_anulado = ''N''
     AND a.mca_poliza_anulada = ''N''
     AND a.mca_provisional = ''N''
     AND a.num_spto  in (select num_spto--max(num_spto)
                               from a2990700 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza
                                and a20.tip_situacion = ''EP'')
     AND a.cod_cia   = d.cod_cia
     AND a.tip_docum = d.tip_docum
     AND a.cod_docum = d.cod_docum
     AND d.COD_ACT_TERCERO = 1
     --
     AND a1331.tip_docum = d.tip_DOCUM
     AND a1331.cod_docum = d.COD_DOCUM
     --
     AND c.cod_mon = a400.cod_mon
     --
     AND c.cod_cia  = a.cod_cia
     AND c.num_spto  = a.num_spto
     AND c.num_apli   = a.num_apli
     AND c.num_poliza  = a.num_poliza
     AND c.num_spto_apli = a.num_spto_apli
     AND trunc(c.fec_efec_recibo) <= trunc(sysdate) + 365
     AND c.tip_situacion  in (''EP'')
     AND c.num_recibo > 0
     and c.num_recibo = (select min(t.num_recibo)
                            from a2990700 t
                            where cod_cia = 1
                            and t.num_poliza = a.num_poliza
                            and t.num_spto = a.num_spto
                            and t.num_apli = a.num_apli
                            and t.num_spto_apli = a.num_spto_apli
                            and t.tip_situacion = ''EP'')
     GROUP BY a.cod_cia,            a.num_poliza,       a.num_poliza_anterior,
         a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,
         a.num_subcontrato,    a.fec_efec_poliza,  a.fec_vcto_poliza,
         a.num_presupuesto,    a.tip_docum,        a.cod_docum,
         1,           a.num_apli,         a.num_spto_apli,
         a.cod_ramo,           a.cod_agt,
         substr(d.NOM_COMPLETO, 0, 8) ,
         a.tip_gestor,
         a1331.num_tarjeta,
         c.fec_efec_recibo ,
         c.tip_situacion,
         c.num_recibo,
         c.fec_valor,
         a.tip_docum || ''-'' || a.cod_docum,
         d.NOM_COMPLETO,
         c.fec_efec_recibo ,
         c.fec_vcto_recibo ,
         DECODE(c.tip_situacion,
                        ''RE'', ''REMESADO'',
                        ''EP'', ''PENDIENTE'') ,
         DECODE(a.tip_gestor,
                        ''AG'', ''VENTANILLA'',
                        ''BA'', ''CUENTA'',
                        ''TA'', ''TARJETA'') ,
         a1331.tlf_numero,
         a1331.tlf_numero_com,
         a1331.fax_numero,
         a1331.fax_numero_com,
         nvl(upper(a1331.email),''***'') ,
         nom_domicilio1,
         nom_domicilio2,
         nom_domicilio3,
         a400.cod_mon_iso
   ORDER BY c.fec_efec_recibo', ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=2025, UPDATEDATE=TIMESTAMP '2025-01-15 00:00:00.000000', SPECIFICATION='{
"title": "Recibos pendientes",
"maintitle": "Mi cuenta",
"table": {
	"pagination": true,
	"search": true,
	"showToggle": false,
	"showRefresh": true,
	"showColumns": false,
	"showExport": true,
	"showPaginationSwitch": false,
	"exportTypes": ["csv", "excel"],
	"detailId": 311,
	"detailParameters": "tip_docum=TIP_DOCUM:cod_docum=COD_DOCUM",
	"columns": [
		{
			"field": "NUM_POLIZA",
			"title": "No. Poliza",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
		},
		{
			"field": "NOM_COMPLETO",
			"title": "Contratante",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringCapitalizeFormatter"
		},
		{
			"field": "TIP_GESTOR_DESC",
			"title": "Gestor",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
		},
		{
			"field": "NUM_TARJETA",
			"title": "Tarjeta",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
		},
		{
			"field": "TIP_SITUACION",
			"title": "Estado",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
		},
		{
			"field": "NUM_RECIBO",
			"title": "No. Recibo",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
		},
		{
			"field": "IMP_RECIBO",
			"title": "Monto",
			"sortable": true,
			"halign": "center",
			"align": "right",
			"formatter": "app.ui.CurrencyAmountFormatter"
		},
		{
			"field": "IMP_COMIS",
			"title": "Comision",
			"sortable": true,
			"halign": "center",
			"align": "right",
			"formatter": "app.ui.CurrencyAmountFormatter"
		},
		{
			"field": "FEC_VCTO_RECIBO",
			"title": "Vencimiento",
			"sortable": true,
			"halign": "center",
			"align": "center",
			"formatter": "app.ui.DateFormatter"
		},
		{
			"field": "TIP_DOCUM",
			"title": "Tipo de cedula",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
		},
		{
			"field": "COD_DOCUM",
			"title": "Cedula",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
		},
		{
			"title": "Acciones",
			"sortable": true,
			"halign": "center",
			"align": "center",
	  "formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button name=\"printr\" type=\"button\"class=\"btn btn-sm btn-white event\" title=\"Permite imprimir el recibo\"><i class=\"fa fa-print\"></i></button><button type=\"button\" name=\"payment\" class=\"btn btn-sm btn-white d-none role-Pago-visible event\" title=\"Permite pagar el recibo actual\"><i class=\"fa fa-shopping-cart\"></i></button></span>'' ;}",
			"events":  true,
			"action_payment": "app.core.LoadScriptFile(''Payment.js'').then(d => {app.Payment.Recibo(row, 310, 2)})"
		}
	]
}
}', CONNECTIONNAME='Tron', STATEMENTTYPE=1, DIALOG=NULL, STATEMENTEXTEND=NULL, "KEY"=NULL, JAVASCRIPTTOINCLUDE='Extend.js' WHERE ID=310 AND "SEQUENCE"=2;
UPDATE VISUALIZATIONS SET "TYPE"=9, CAPTION='Enviar enlace de pago', DESCRIPTION='Panel', "STATEMENT"=NULL, ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=2025, UPDATEDATE=TIMESTAMP '2025-01-15 00:00:00.000000', SPECIFICATION=NULL, CONNECTIONNAME=NULL, STATEMENTTYPE=NULL, DIALOG='Opciones de pago|titulo
|zona|12
 Enviar por Correo|Boton|name=ESendBtn;click=app.Payment.SendLink(''Correo'',{NUM_POLIZA},{NUM_RECIBO});class=btn-danger btn-outline btn-block m-t
 Enviar por WhatsApp|Boton|name=WSendBtn;click=app.Payment.SendLink(''WhatsApp'',{NUM_POLIZA},{NUM_RECIBO});class=btn-danger btn-outline btn-block m-t
 Pago Directo|Boton|name=DirectBtn;click=app.Payment.SendLink(''Direct'',{NUM_POLIZA},{NUM_RECIBO});class=btn-danger btn-outline btn-block m-t', STATEMENTEXTEND=NULL, "KEY"=NULL, JAVASCRIPTTOINCLUDE=NULL WHERE ID=9006 AND "SEQUENCE"=1;