INSERT INTO VISUALIZATIONS (ID, "SEQUENCE", "KEY", COMPANYID, ENTITYTYPE, "TYPE", CAPTION, DESCRIPTION, STATEMENTTYPE, "STATEMENT", SPECIFICATION, DIALOG, ICON, ICONCLASS, VALUEFORMAT, CONNECTIONNAME, JAVASCRIPTTOINCLUDE, STATEMENTEXTEND, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(360, 1, NULL, 1, NULL, 1, 'Polizas activas', 'Polizas activas version 2', 1, 'SELECT distinct      a.cod_cia,            a.num_poliza,       b.num_riesgo,      a.num_poliza_anterior,
             a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,    a.num_subcontrato,
             a.fec_efec_poliza,    a.fec_vcto_poliza,  a.num_presupuesto, b.nom_certificado,
             a.tip_docum,          a.cod_docum,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client(a.tip_docum, a.cod_docum) NOM_TOMADOR,
             em_k_Mapfre_Query_Contract_mcr.f_search_email_client(a.tip_docum, a.cod_docum) email,
             em_k_Mapfre_Query_Contract_mcr.f_search_phone_client(a.tip_docum, a.cod_docum) tlf_numero,
             a.num_spto,        a.num_apli, a.num_spto_apli,      a.cod_ramo,         a.cod_agt,
             a60.tip_docum || '' '' || a60.cod_docum IDENTIFICACION,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client( a60.tip_docum,a60.cod_docum)  NOM_COMPLETO,
             em_k_Mapfre_Query_Contract_mcr.f_search_email_client(a60.tip_docum, a60.cod_docum) email_aseg,
             em_k_Mapfre_Query_Contract_mcr.f_search_phone_client(a60.tip_docum, a60.cod_docum) tlf_numero_aseg,
             d.abr_ramo,
             b.nom_riesgo || ''  '' ||  em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a.num_poliza,''COD_CHASSIS'') nom_riesgo,
             a1402.nom_fracc_pago,
             a60.tip_benef,
             F_PRIMA_TOTAL_MCR(a.num_poliza) prima_total,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client_tip_benef(a.num_poliza,''8'') nom_acreedor
        FROM a2000030 a,
             a2000031 b,
             v1001390 c,
             a1001800 d,
             a2000060 a60,
             a1001403 a1403,
             a1001402 a1402
       WHERE a.cod_cia            = {app.P_COD_CIA}
         AND a.cod_agt            = {app.P_COD_AGT}
         AND a.cod_ramo           in (194, 401, 117)
         AND a.mca_spto_anulado   = ''N''
         AND a.mca_poliza_anulada = ''N''
         AND a.mca_provisional    = ''N''
         AND a.num_spto  in (select max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza
                                AND a20.mca_spto_anulado = ''N'')
         ---Riesgo
         AND b.cod_cia          = a.cod_cia
         AND b.num_poliza       = a.num_poliza
         AND b.mca_vigente      = ''S''
         AND b.mca_baja_riesgo  = ''N''
         AND b.num_spto  in (SELECT MAX(num_spto)
                               FROM a2000031 a31
                              WHERE a31.cod_cia          = b.cod_cia
                                AND a31.num_poliza       = b.num_poliza
                                AND a31.mca_vigente      = ''S'')

         ---
         --
         AND a.cod_cia = d.cod_cia
         AND a.cod_ramo = d.cod_ramo
         --Informacion tercero Asegurado
         and a60.cod_cia = a.cod_cia
         and a60.num_poliza = a.num_poliza
         and a60.num_poliza = b.num_poliza
         and a60.num_riesgo = b.num_riesgo
         and a60.mca_baja = ''N''
         and a60.mca_vigente = ''S''
         and a60.tip_benef = 2
         and c.tip_docum =  a60.tip_docum
         and c.cod_docum =  a60.cod_docum
         --
         ---Fraccionamiento de Pago
          and a.cod_cia = a1403.cod_cia
          and a.cod_mon = a1403.cod_mon
          and a.cod_ramo = a1403.cod_ramo
          and a.cod_fracc_pago = a1403.cod_fracc_pago
          and a1403.cod_cia = a1402.cod_cia
          and a1403.cod_fracc_pago = a1402.cod_fracc_pago

       ORDER BY a.num_poliza', '{
"title": "Polizas activas",
"table": {
"pagination": true,
"search": true,
"showToggle": false,
"showRefresh": true,
"showColumns": false,
"showExport": true,
"showPaginationSwitch": false,
"exportTypes": [
"csv",
"excel"
],
"columns": [
{
"title": "Acciones",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "function (value, row, index, field) { return ''<span class=columnBtn>''+''<button type=\"button\" name=\"cancelpol\" class=\"btn btn-sm btn-white event\" title=\"Permite cancelar la p?liza\"><i class=\"fa fa-close\"></i></button>''+''</span>'' ;}",
"visible": true,
"events": true,
"action_cancelpol": "app.ui.Redirect(''../viewer/Form?id=AnularPoliza&poliza={NUM_POLIZA}'')",
},
{
"field": "NUM_POLIZA_GRUPO",
"title": "Poliza Grupo",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NUM_CONTRATO",
"title": "Contrato",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NUM_POLIZA",
"title": "No. Poliza",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "function (value, row, index, field) { return ''<a href=tabrender?id=302&P_NUM_POLIZA='' + row.NUM_POLIZA + '' onclick=app.ViewerQuery.TabRender(this); return false;>'' + value + ''</a>''; }"
},
{
"field": "ABR_RAMO",
"title": "Ramo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeFormatter"
},
{
"field": "COD_DOCUM",
"title": "Cedula Tomador",
"sortable": true,
"halign": "center",
"align": "left",
"format": "{TIP_DOCUM} {COD_DOCUM}"
},
{
"field": "NOM_TOMADOR",
"title": "Tomador",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeEachWordFormatter"
},
{
"field": "TLF_NUMERO",
"title": "Telefono",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "EMAIL",
"title": "Correo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "IDENTIFICACION",
"title": "Cedula Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_COMPLETO",
"title": "Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeEachWordFormatter"
},
{
"field": "TLF_NUMERO_ASEG",
"title": "Telefono Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "EMAIL_ASEG",
"title": "Correo Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_ACREEDOR",
"title": "Acreedor",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_RIESGO",
"title": "Riesgo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_FRACC_PAGO",
"title": "Fraccionamiento",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeFormatter"
},
{
"field": "FEC_EFEC_POLIZA",
"title": "Inicio de vigencia",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.DateFormatter"
},
{
"field": "FEC_VCTO_POLIZA",
"title": "Fin de vigencia",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.DateFormatter"
}
]
}
}', NULL, NULL, NULL, NULL, 'Tron', 'Extend.Policy.js', NULL, 1, 777, TIMESTAMP '2023-02-27 21:49:26.000000');