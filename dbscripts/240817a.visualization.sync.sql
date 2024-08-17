DELETE FROM VISUALIZATIONS  where ID IN (333,340,360,361,9006,9100,9101,9102,9104,9105,9106,10009,10010);

INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (333,1,1,'Presupuestos pendientes de emitir','Presupuestos pendientes de emitir por agente','SELECT ID, PROPOSALID, INSUREDID, REPLACE(INSUREDID, ''-'', '''') INSUREDIDCLEAR, INSUREDNAME, SUMMARY, ISSUEDATE, SIGNINGREQUESTID, STATUS, LKS.DESCRIPTION STATUSDESC, SigningType, PrimaryEmailAddress
  FROM POLICYPROPOSAL
  LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 2050 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE = POLICYPROPOSAL.STATUS
 WHERE POLICYPROPOSAL.COMPANYID={app.companyid} AND AGENTCODE={app.agentcode} AND STATUS <> 10 ORDER BY ISSUEDATE DESC, POLICYPROPOSAL.UPDATEDATE DESC',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-07-10 19:57:22',TO_CLOB('{
   "title": "Presupuestos pendientes de emitir",
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
        "detailId": 321,
        "detailParameters": "P_NUM_POLIZA=PROPOSALID",
      "columns": [
         {
            "field": "ISSUEDATE",
            "title": "Creacion",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.DateAndTimeFormatter"
         },
         {
            "field": "PROPOSALID",
            "title": "Presupuesto",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "function (value, row, index, field){ var ramo = row.PROPOSALID.substring(0, 3); var producto = ''''; if(ramo == 302){producto=''mapfremas'';} if(ramo == 201){producto=''hogartotal'';} if(ramo == 202){producto=''multirriesgo'';} if(ramo == 401){producto=''SaldoDeudor'';} return row.STATUS===33?''<a href='' + app.setting.basepath + ''emision/''+ producto + ''?mode=continue&presupuesto='' + row.PROPOSALID + ''>'' + value + ''</a>'': ''<span>''+ value + ''</span>'';}"
         },
         {
            "field": "STATUSDESC",
            "title": "Estado",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "function (value, row, index, field) { return ''<span class=@_label '' + (row.STATUS===33?''label-primary'': '' '') + ''@_>'' + value + ''</span>'';}"
         },
         {
            "field": "INSUREDID",
            "visible": false
         },
         {
            "field": "INSUREDIDCLEAR",
            "visible": false
         },
         {
            "field": "INSUREDNAME",
            "title": "Asegurado",
            "sortable": true,
            "halign": "center",
            "a')||TO_CLOB('lign": "left",
            "format": "{INSUREDID} {INSUREDNAME}"
         },
         {
            "field": "SUMMARY",
            "title": "Detalles",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter"
         },
         {
            "title": "Acciones",
            "titleTooltip": "Acciones disponibles para un presupuesto",
            "sortable": false,
            "halign": "left",
            "align": "left",
            "formatter": "function (value, row, index, field) { var producto = ''mapfremas''; var ramo = row.PROPOSALID.substring(0, 3); if(ramo == 302){producto=''mapfremas'';}if(ramo == 201){producto=''hogartotal'';} if(ramo == 202){producto=''multirriesgo'';} if(ramo == 401){producto=''SaldoDeudor'';} return (row.STATUS===33?''<a class=@_btn btn-sm btn-outline btn-primary@_ href='' + app.setting.basepath + ''emision/''+ producto + ''?mode=continue&presupuesto='' + row.PROPOSALID + ''>Emitir</a>'': '''') +'' '' +  (row.STATUS===31 || row.STATUS===32 || row.SIGNINGTYPE===''M''?''<button type=\"button\" name=\"enviarsolicitud\" class=\"btn btn-sm btn-outline btn-warning event\">Reenvia solicitud</button>'': '''');}",
            "events": true,
            "action_enviarsolicitud": "app.ui.ShowSideBar({ title: ''Enviar solicitud'', subtitle: ''Presupuesto #{PROPOSALID}'', id: 9001, data: row})"
         }
      ]
   }
   }'),'Research',1,NULL,NULL,NULL,'Extend.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (340,1,1,'Controles t?cnicos','Pendientes','SELECT distinct a21.num_poliza,
   y.nom_ramo,
     a21.num_spto,
     a21.cod_error,
     g20.nom_error,
     a21.mca_autorizacion,
     a60.cod_docum,
     a100.nom_tercero || '' '' || a100.ape1_tercero || '' '' || a100.ape2_tercero NOMBRE_ASEG,
     a30.num_poliza_grupo,
   a21.fec_autorizacion
FROM  A2000221 a21,
     G2000211 g20,
     a2000060 a60,
     a1001399 a100,
     a2000030 a30
LEFT JOIN a1001800 y ON y.cod_cia = a30.cod_cia AND y.cod_ramo = a30.cod_ramo
WHERE  a21.COD_CIA = 1
AND    a21.COD_SISTEMA = 2
AND    a21.MCA_AUTORIZACION = ''N''
AND    a21.NUM_POLIZA IN
     (SELECT NUM_POLIZA
       FROM   A2000030
       WHERE  COD_CIA = 1
       AND    COD_AGT = {app.P_COD_AGT})
AND    a21.cod_error in (3030,549)
AND    A21.COD_ERROR = G20.COD_ERROR
AND    a60.num_poliza = a21.num_poliza
AND    a60.tip_benef = 2
AND    a100.cod_docum = a60.cod_docum
    ---Poliza Grupo
AND    a30.cod_agt = {app.P_COD_AGT}
AND    a30.num_poliza = a21.num_poliza',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 21:35:45',TO_CLOB('{
    "title": "Pendientes",
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
                "field": "NUM_POLIZA_GRUPO",
                "title": "No. P?liza grupo",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NUM_POLIZA",
                "title": "No. P?liza",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NUM_SPTO",
                "title": "No. Suplemento",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.IntegerWithZeroFormatter",
                "visible": true
            },
            {
                "field": "COD_DOCUM",
                "title": "Asegurado",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true,
                "format": "{COD_DOCUM} - {NOMBRE_ASEG}"
            },
            {
                "field": "COD_ERROR",
                "title": "Causa del control",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "visible": true,
                "format": "{COD_ERROR} - {NOM_ERROR}"
            },
            {
                "title": "Acciones",
                "sortable":')||TO_CLOB(' true,
                "halign": "center",
                "align": "center",
                "formatter": "function (value, row, index, field) { return ''<span class=columnBtn>'' + ''<button type=\"button\" name=\"ctroltec\" class=\"btn btn-sm btn-white event\" title=\"Permite procesar un control t?cnico\"><i class=\"fa fa-check\"></i></button>''+''<button type=\"button\" name=\"print\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir la poliza\"><i class=\"fa fa-print\"></i></button>''+''</span>'' ;}",
                "visible": true,
                "events": true,
                "action_ctroltec": "app.ui.ShowSideBar({ title: ''Control t?cnico'', subtitle: ''Poliza #{NUM_POLIZA}'', id: 9004, data: row, callback: ''app.Ex_Policy.ControlTecnico_Init'', width: ''400px''})"
            }
        ]
    }
}'),'Tron',1,NULL,NULL,NULL,'Extend.Policy.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (340,2,1,'Controles t?cnicos','Procesados','SELECT a21.num_poliza,
     a21.num_spto,
     a21.cod_error,
     g20.nom_error,
     a21.mca_autorizacion,
     a21.fec_autorizacion,
     a21.cod_usr_autorizacion,
     a21.obs_autorizacion
FROM   A2000221 a21, G2000211 g20
WHERE  a21.COD_CIA = 1
AND    a21.COD_SISTEMA = 2
AND    a21.MCA_AUTORIZACION = ''S''
AND    a21.NUM_POLIZA IN
     (SELECT NUM_POLIZA
       FROM   A2000030
       WHERE  COD_CIA = 1
       AND    COD_AGT = {app.P_COD_AGT})
AND    A21.COD_ERROR = G20.COD_ERROR
ORDER BY a21.fec_autorizacion DESC',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 21:35:45',TO_CLOB('{
    "title": "Procesados",
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
                "field": "NUM_POLIZA",
                "title": "No. P?liza",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NUM_SPTO",
                "title": "No. Suplemento",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DecimalFormatter",
                "visible": true
            },
            {
                "field": "COD_ERROR",
                "title": "Causa del control",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "visible": true,
                "format": "{COD_ERROR} - {NOM_ERROR}"
            },
            {
                "field": "FEC_AUTORIZACION",
                "title": "Autorizado",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "COD_USR_AUTORIZACION",
                "title": "Autorizado por",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "OBS_AUTORIZACION",
                "title": "Observaci?n",
                "sortable": true,
  ')||TO_CLOB('              "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            }
        ]
    }
}'),'Tron',1,NULL,NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (360,1,1,'Polizas activas','Polizas activas version 2','SELECT distinct      a.cod_cia,            a.num_poliza,       b.num_riesgo,      a.num_poliza_anterior,
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

       ORDER BY a.num_poliza',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 21:49:26',TO_CLOB('{
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
"f')||TO_CLOB('ormatter": "app.ui.StringFormatter"
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
}'),'Tron',1,NULL,NULL,NULL,'Extend.Policy.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (361,1,1,'Siniestros','Siniestros version 2','   SELECT a900.NUM_SINI, a80.OBS ASIGES, a900.TIP_EST_SINI, G31A.NOM_VALOR NOM_TIP_EST_SINI, a900.FEC_DENU_SINI,a900.HORA_DENU_SINI, a900.FEC_SINI, a900.HORA_SINI, a900.COD_CAUSA_SINI, G200.NOM_CAUSA, a900.FEC_TERM_SINI, a900.FEC_REAP_SINI, a900.MCA_CULPABLE,a900.TIP_APERTURA,
        a900.COD_RAMO, a1800.NOM_RAMO, a900.NUM_POLIZA, a900.NUM_SPTO, a900.NUM_APLI, a900.NUM_SPTO_APLI, a900.NUM_RIESGO, A2020.VAL_CAMPO Matricula,
       em_f_nom_riesgo_web (a900.cod_cia, a900.num_poliza, a900.num_spto, a900.num_riesgo) nom_riesgo,
       a900.TIP_DOCUM_TOMADOR, a900.COD_DOCUM_TOMADOR, A1399A.NOM_TERCERO NOM_TOMADOR,  A1399A.APE1_TERCERO APE_TOMADOR,
       a900.TIP_DOCUM_ASEG, a900.COD_DOCUM_ASEG, A1399A.NOM_TERCERO NOM_ASEG,  A1399A.APE1_TERCERO APE_ASEG, A1331.EMAIL EMAIL_ASEG,
       a900.TIP_DOCUM_CONTACTO, a900.COD_DOCUM_CONTACTO, a900.NOM_CONTACTO, a900.APE_CONTACTO, a900.TEL_PAIS_CONTACTO, a900.TEL_ZONA_CONTACTO, a900.TEL_NUMERO_CONTACTO, a900.EMAIL_CONTACTO, a900.TIP_RELACION, G31B.NOM_VALOR NOM_TIP_RELACION,
       a1000.NUM_EXP, a1000.TIP_EXP, G90.NOM_EXP,a1000.FEC_APER_EXP, a1000.FEC_TERM_EXP,  a1000.TIP_EST_EXP, G31EA.NOM_VALOR NOM_TIP_EST_EXP,
       nvl(a1000.imp_val_inicial,0) IMP_RESERVA, nvl(a1000.imp_val,0) IMP_ESTIMADO, nvl(a1000.imp_liq,0) IMP_LIQUIDADO, nvl(a1000.imp_pag,0) IMP_PAGADO,
       a1000.TIP_DOCUM, a1000.COD_DOCUM, a1000.NOMBRE, a1000.APELLIDOS       
  FROM a7000900 a900
  LEFT JOIN G1010031 G31A ON G31A.COD_CAMPO =''TIP_EST_SINI'' AND G31A.COD_VALOR = a900.TIP_EST_SINI AND G31A.COD_IDIOMA=''ES''
  LEFT JOIN G1010031 G31B ON G31B.COD_CAMPO =''TIP_RELACION'' AND G31B.COD_VALOR = a900.TIP_RELACION AND G31B.COD_IDIOMA=''ES''
  LEFT JOIN A1001399 A1399T ON A1399T.COD_CIA=a900.COD_CIA AND A1399T.TIP_DOCUM = a900.TIP_DOCUM_TOMADOR AND  A1399T.COD_DOCUM = a900.COD_DOCUM_TOMADOR
  LEFT JOIN A1001399 A1399A ON A1399A.COD_CIA=a900.COD_CIA AND A1399A.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1399A.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN A1001331 A1331 ON A1331.COD_CIA=a900.COD_CIA AND A1331.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1331.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN a1001800 a1800 ON a1800.COD_CIA=a900.COD_CIA AND a1800.COD_RAMO = a900.COD_RAMO
  LEFT JOIN G7000200 G200 ON G200.COD_CIA = a900.COD_CIA AND G200.TIP_CAUSA = 1 AND G200.COD_CAUSA = a900.COD_CAUSA_SINI
  LEFT JOIN A2000020 A2020 ON A2020.COD_CIA=a900.COD_CIA AND A2020.NUM_POLIZA=a900.NUM_POLIZA AND A2020.NUM_SPTO=0 AND A2020.NUM_APLI=0 AND A2020.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020.NUM_RIESGO=a900.NUM_RIESGO AND A2020.COD_CAMPO=''NUM_MATRICULA''
  LEFT JOIN A7001080 a80 ON a80.COD_CIA=a900.COD_CIA AND a80.NUM_SINI=a900.NUM_SINI AND NOT a80.OBS IS NULL
  LEFT JOIN A7001000 a1000 ON a1000.COD_CIA=a900.COD_CIA AND a1000.NUM_SINI=a900.NUM_SINI
  LEFT JOIN G7000090 G90 ON G90.COD_CIA = a1000.COD_CIA AND G90.TIP_EXP = a1000.TIP_EXP
  LEFT JOIN G1010031 G31EA ON G31EA.COD_CAMPO =''TIP_EST_EXP'' AND G31EA.COD_VALOR = a1000.TIP_EST_EXP AND G31EA.COD_IDIOMA=''ES''  
  WHERE a900.COD_CIA={app.P_COD_CIA}
    AND a900.COD_AGT={app.P_COD_AGT}
 ORDER BY a900.FEC_SINI DESC, a900.NUM_SINI, a1000.NUM_EXP',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
  "title": "Siniestros",
  "table": {
    "pagination": true,
    "search": true,
    "showToggle": false,
    "showRefresh": true,
    "showColumns": false,
    "showExport": false,
    "showPaginationSwitch": false,
    "exportTypes": [
      "csv",
      "excel"
    ],
    "columns": [{
        "title": "No. Siniestro",
        "halign": "center",
        "align": "center",
        "formatter": "app.ExtendClaims.NUM_SINIFormatter",
        "visible": true,
        "events": true,
        "action_viewClaim": "app.ExtendClaims.ShowClaimDetail(row)",
      },   
      {
        "field": "FEC_SINI",
        "title": "Ocurrencia",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ExtendClaims.FEC_SINIFormatter"
      },
      {
        "field": "NOM_CAUSA",
        "title": "Causa",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter"
      },
      {
        "field": "NOM_TIP_EST_SINI",
        "title": "Estado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "cellStyle": "app.ExtendClaims.NOM_TIP_EST_SINICellStyle",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter"
      },
            {
                "field": "NOM_EXP",
                "title": "Expediente",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ExtendClaims.NOM_EXPFormatter",
                "events": true,
                "action_viewClaimExp": "app.ExtendClaims.ShowExpedienteDetail(row)"
            },        
      {
        "field": "NUM_POLIZA",
        "title": "No. Póliza",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ExtendClaims.NUM_POLIZAFormatter",
        "visible": true,
        "events": true,
        "action_viewPolicy": "app.ExtendClaims')||TO_CLOB('.ShowPolicyDetail(row)",
      },
      {
        "field": "NOM_ASEG",
        "title": "Asegurado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ExtendClaims.NOM_ASEG2Formatter",
        "events": true,
        "action_viewTercero": "app.ExtendClaims.ShowTercero(row)"        
      },
      {"field": "NUM_SINI", "visible": false},      
      {"field": "ASIGES", "visible": false},
      {"field": "COD_DOCUM_ASEG", "visible": false},
      {"field": "APE_ASEG", "visible": false},
      {"field": "MATRICULA", "visible": false}
    ]
  }
}'),'Tron',1,NULL,NULL,NULL,'Extend.Claims.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (9006,1,9,'Enviar enlace de pago','Panel',NULL,NULL,NULL,NULL,NULL,1,1,888,TIMESTAMP'2023-03-31 00:00:00',NULL,NULL,NULL,'Enviar enlace de pago|titulo
|zona|12
 Enviar por Correo|Boton|name=ESendBtn;click=app.Payment.SendLink(''Correo'',{NUM_POLIZA},{NUM_RECIBO});class=btn-danger btn-outline btn-block m-t
 Enviar por WhatsApp|Boton|name=WSendBtn;click=app.Payment.SendLink(''WhatsApp'',{NUM_POLIZA},{NUM_RECIBO});class=btn-danger btn-outline btn-block m-t',NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (9100,1,9,'Información del proveedor','Form',NULL,NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Información del proveedor|título
Datos para la busqueda|zona|4
 Identificación del proveedor a buscar+|texto(12)|name=SUPPLIER_ID
 Buscar|button|name=btnSearch;class=btn-on-primary
Datos del proveedor|zona|4
 Nombre|texto|name=SUPPLIER_NM;disabled=true
 Dirección|texto|name=ADDR;disabled=true
 Código postal|texto|name=POST_NO;disabled=true
 Página web|texto|name=HPAGE;disabled=true
Datos de contacto|zona|4 
 Número de teléfono|texto|name=TEL_NO;disabled=true
 Número de fax|texto|name=FAX_NO;disabled=true
 Correo electrónico|texto|name=EMAIL;disabled=true',NULL,'InformacionProveedor','Form.Ext.SICOP.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (9101,1,9,'Notificar a SICOP de la recepción de garantías electrónicas de participación y cumplimiento','Form',NULL,NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Notificar a SICOP de la recepción de garantías electrónicas de participación y cumplimiento|título
Datos de la garantía electrónica|zona|3
 Número+|texto(14)|name=Guarantee_number;title=Cedula jurídica institución que promueve el proceso de contratación
 Secuencia+|texto(2)|name=Guarantee_sequencenumber;disabled=true
 Tipo|radio|name=Guarantee_type_code;values=BG->Participación,CG->Cumplimiento,PG->Colateral;datatype=string
 Forma de pago|lista|name=Guarantee_payment_code;datatype=string;values=01->Efectivo,02->Certificados depósitos,03->Cheque certificado,05->Bono del estado,06->Cheque gerencia,07->Garantía Electrónica;default=07;disabled=true
 Número de cuenta|texto(20)|name=Cuenta_cliente;title=Solo en caso de ser garantías en efectivo;visible=ctrol.Guarantee_payment_code.eq.''01'' 
 Moneda+|radio|name=Moneda;values=CRC->Colón Costarricense,USD->Dolar;default=CRC;datatype=string
 Monto total+|decimal(18,3)|name=Guarantee_amount
 Tipo de modificación+|radio|name=Tipo_de_modification;values=01->Ampliación de plazo,02->Ampliación de monto,03->Prórroga de plazo y monto;datatype=string;hidden=true 
Datos de la entidad garante|zona|3  
 Cédula jurídica+|texto(10)|name=Guarantee_identifier;disabled=true
 Entidad garante|texto(200)|name=Guarantee_name;disabled=true
 Nombre del funcionario|texto(200)|name=Guarantee_charge_person_name;column=6
 Correo electrónico|Correo(50)|name=Guarantee_charge_person_email
 Teléfono|Teléfono(16)|name=Guarantee_telephone_number;modo=simple
 Código postal|texto(5)|name=Guarantee_postal_code
 Dirección|nota(200)|name=Guarantee_address_line;filas=2;column=6 
Datos generales|zona|3
 Número de procedimiento+|texto(24)|name=Institucion_notice_number
 Número del pliego de condiciones+|texto(11)|name=Notice_number;title=Número de cartel en SICOP
 Cédula del proveedor+|texto(12)|name=Supplier_identifier;title=Garantía por cuenta de
 Nombre del proveedor|texto(200)|name=Supplier_name;disabled=true
 Cédula de la institución+|texto(10)|name=Institution_identifier;title=Garantía a favor de
 Fecha de inicio de validez+|fechainicio|name=Issue_date;default=today;title=Fecha de inicio de validez de la garantía
 Fecha de vencimiento+|fechafin|name=Valid_period_date;title=Fecha de vencimiento de la garantía
 Comentarios de la garantía|nota(2000)|name=Guarantee_contents;filas=4;column=6 
 Notificar|button|name=btnNotify;class=btn-on-primary',NULL,'NotificarGarantia','Form.Ext.SICOP.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (9102,1,9,'Notificar a SICOP de la recepción de garantías electrónicas de participación y cumplimiento','Form',NULL,NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Notificar a SICOP sobre la ejecución de los procesos de liberación y ejecución de las Garantías Electrónicas por parte de la Institución promotora del proceso de Contratación Administrativa|título
Datos generales|zona|3
 Número de garantía electrónica generado por la entidad garante+|texto(14)|name=Guarantee_number;disabled=true
 Secuencia de la garantía electrónica+|texto(2)|name=Guarantee_sequencenumber;disabled=true
 Cédula jurídica de la entidad garante|texto(10)|name=Guarantee_identifier;disabled=true
 Nombre de la entidad garante|texto(200)|name=Guarantee_name;disabled=true
 Número de cuenta en la cual se depositó el monto solicitado|texto(20)|name=Cuenta_cliente;disabled=true
 Moneda+|radio|name=Moneda;values=CRC->Colón Costarricense,USD->Dolar;default=CRC;datatype=string;disabled=true
 Monto de ejecución/liberación de la garantía+|decimal(18,3)|name=Execute_release_amount;disabled=true
 Número de comprobante de la transacción|texto(25)|name=Transaction_num
 Fecha y hora de la fecha en que se hace efectiva la ejecución o liberación de la garantía+|fecha|name=Date_time;default=today
 Descripción o comentario de la ejecución/liberación de la Garantía|nota(2000)|name=Execute_release_contents;filas=4;column=6 
 Notificar|button|name=btnNotify;class=btn-on-primary',NULL,'NotificarLiberacion','Form.Ext.SICOP.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (9104,1,1,'Garantías electrónicas - Historia',NULL,'SELECT Guarantee_sequencenumber "Guarantee_sequencenumber", Guarantee_amount "Guarantee_amount", Moneda "Moneda",  Valid_period_date "Valid_period_date", DECODE(Tipo_de_modification, ''01'',''Ampliación de plazo'',''02'',''Ampliación de monto'',''03'',''Prórroga de plazo y monto'', '''') "Tipo_de_modificationDesc", UpdateDate "UpdateDate"
FROM ElectronicWarranty P WHERE Guarantee_number={code:varchar} ORDER BY Guarantee_sequencenumber DESC',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'2024-05-13 00:00:00',TO_CLOB('{
    "title": "Historia",
    "table": {
  		"pagination": true,
		"search": false,
		"showToggle": false,
		"showRefresh": false,
		"showColumns": false,
		"showExport": false,
        "columns": [
            {
                "field": "Guarantee_sequencenumber",
                "title": "Número de secuencia",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Guarantee_amount",
                "title": "Monto de la garantía",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.CurrencyAmountFormatter"
            },
            {
                "field": "Valid_period_date",
                "title": "Fecha de Vencimiento",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter"
            },
            {
                "field": "Tipo_de_modificationDesc",
                "title": "Tipo de modificación",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "UpdateDate",
                "title": "Fecha y hora de recepción de garantía",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter"
            }
        ]        
    }
}'),'Research',1,NULL,NULL,NULL,'Form.Ext.SICOP.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (9105,1,9,'Emitir una póliza','Form',NULL,NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Emisión de una pólizas|título
Datos generales|zona|columns=4;width=6
 Ramo+|lista|name=RAMO;values=194->Accidentes personales,401->Saldo deudor declarativo,117->Seguro vida colectivo
 Contrato+|lista|name=NUM_CONTRATO;disabled=true
 Póliza Grupo|texto(13)|name=NUM_POLIZA_GRUPO;disabled=true
 Moneda|texto|name=MONEDA;disabled=true
 Inicio de vigencia+|fechainicio|name=EFEC_SPTO
 Fin de vigencia+|fechafin|name=VCTO_SPTO
Datos del asegurado|zona|columns=4;width=6
 Identificación+|cedula|name=COD_DOCUM_ASEG
 Nombre+|texto(20)|name=NOM_TERCERO_ASEG
 Apellido+|texto(20)|name=APE_TERCERO_ASEG
 Fecha de nacimiento|Nacimiento|name=NAC_ASEG
 Sexo|radio|name=MCA_SEXO_ASEG;values=0->Femenino,1->Masculino
 Nacionalidad|tron.País|name=NACIONALIDAD_ASEG
 Provincia|tron.Provincia|name=COD_ESTADO
 Cantón|tron.Cantón|name=COD_PROVINCIA
 Distrito|tron.Distrito|name=COD_LOCALIDAD
 Otra señas|nota(180)|name=DOMICILIO;filas=2;column=12
Datos del riesgo|zona|columns=4;visible=entry.RAMO.neq.0
 Número del préstamo+|texto(30)|name=NUM_PRESTAMO;visible=entry.RAMO.eq.401
 Inicio del préstamo+|fecha|name=INI_PRESTAMO;visible=entry.RAMO.eq.401
 Fin del préstamo+|fecha|name=VCTO_PRESTAMO;visible=entry.RAMO.eq.401
 Suma asegurada+|decimal(18,3)|name=IMP_SUMA_ASEG;visible=entry.RAMO.eq.401
 Prima informada+|decimal(18,3)|name=IMP_PRIMA_INFORMADA;visible=entry.RAMO.eq.117.or.entry.RAMO.eq.401
 Identificación del estudiante+|texto(15)|name=ID_CRED_ESTUDIANTE;visible=entry.RAMO.eq.194
 ¿Asistencia?|radio|name=MCA_ASISTENCIA;values=1->Si,2->No
 Suma asegurada por muerte|decimal(18,3)|name=IMP_SUMA_MUERTE;visible=entry.RAMO.eq.194
 Plan+|lista|name=COD_PLAN_AP;lookup=TRON_TAVID000;datatype=string;visible=entry.RAMO.eq.194
 Emitir|button|name=btnIssue;class=btn-on-primary',NULL,'EmitirPoliza','Form.Ext.Altas.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (9106,1,9,'Anular una póliza','Form',NULL,NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Anular una pólizas|título
Datos generales|zona|columns=4;width=6
 Ramo+|lista|name=RAMO;values=194->Accidentes personales,401->Saldo deudor declarativo,117->Seguro vida colectivo;disabled=true
 Contrato+|lista|name=NUM_CONTRATO;disabled=true
 Póliza Grupo|texto(13)|name=NUM_POLIZA_GRUPO;disabled=true
 Moneda|texto|name=MONEDA;disabled=true
 Inicio de vigencia+|fechainicio|name=EFEC_SPTO;disabled=true
 Fin de vigencia+|fechafin|name=VCTO_SPTO;disabled=true
Datos del asegurado|zona|columns=4;width=6
 Identificación+|cedula|name=COD_DOCUM_ASEG;disabled=true
 Nombre+|texto(20)|name=NOM_TERCERO_ASEG;disabled=true
 Apellido+|texto(20)|name=APE_TERCERO_ASEG;disabled=true
 Fecha de nacimiento|Nacimiento|name=NAC_ASEG;disabled=true
 Sexo|radio|name=MCA_SEXO_ASEG;values=0->Femenino,1->Masculino;disabled=true
 Nacionalidad|tron.País|name=NACIONALIDAD_ASEG;disabled=true
 Provincia|tron.Provincia|name=COD_ESTADO;disabled=true
 Cantón|tron.Cantón|name=COD_PROVINCIA;disabled=true
 Distrito|tron.Distrito|name=COD_LOCALIDAD;disabled=true
 Otra señas|nota(180)|name=DOMICILIO;filas=2;column=12;disabled=true
Datos del riesgo|zona|columns=4;visible=entry.RAMO.neq.0
 Número del préstamo|texto(30)|name=NUM_PRESTAMO;visible=entry.RAMO.eq.401;disabled=true
 Inicio del préstamo|fecha|name=INI_PRESTAMO;visible=entry.RAMO.eq.401;disabled=true
 Fin del préstamo|fecha|name=VCTO_PRESTAMO;visible=entry.RAMO.eq.401;disabled=true
 Suma asegurada|decimal(18,3)|name=IMP_SUMA_ASEG;visible=entry.RAMO.eq.401;disabled=true
 Prima informada|decimal(18,3)|name=IMP_PRIMA_INFORMADA;visible=entry.RAMO.eq.117.or.entry.RAMO.eq.401;disabled=true
 Identificación del estudiante|texto(15)|name=ID_CRED_ESTUDIANTE;visible=entry.RAMO.eq.194;disabled=true
 ¿Asistencia?|radio|name=MCA_ASISTENCIA;values=1->Si,2->No;disabled=true
 Suma asegurada por muerte|decimal(18,3)|name=IMP_SUMA_MUERTE;visible=entry.RAMO.eq.194;disabled=true
 Plan|texto(30)|name=COD_PLAN_AP;visible=entry.RAMO.eq.194;disabled=true
 Anular|button|name=btnIssue;class=btn-on-primary;disabled=true
',NULL,'AnularPoliza','Form.Ext.Bajas.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (10009,1,9,'Excel para carga ARS','Panel','Excel para carga ARS|titulo
|zona|12
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Exportar|Boton|class=btn-block btn-primary;click=app.core.GetXLSX(10010)',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-03-29 20:02:48',NULL,NULL,NULL,'Excel para carga ARS|titulo
|zona|12
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Exportar|Boton|class=btn-block btn-primary;click=app.core.GetXLSX(10010)',NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (10010,1,8,'Carga electronica ARS','Carga electronica ARS','WITH CTE AS (SELECT A.POLICYID, A.TYPE, A.UPDATEDATE, A.DOCUMENTNUMBER, A.FIRSTNAME, A.MIDDLENAME, A.LASTNAME, A.SECONDLASTNAME, A.BirthDate,
       A.PARTICIPATIONRATE, A.RELATIONSHIP, LKRE.DESCRIPTION RELATIONSHIPDESC,
       row_number() over (partition by A.POLICYID order by A.UPDATEDATE desc) as row_num
  FROM RiskRoles A LEFT JOIN LOOKUP LKRE ON LKRE.LOOKUPID = 2108 AND LKRE.LANGUAGE=1 AND LKRE.CODE = A.RELATIONSHIP WHERE A.TYPE=100)
SELECT NULL CONTRATO, DECODE(B.ISHEALTH, ''A'', ''Clase 1'', ''B'', ''Clase 2'', ''C'', ''Clase 3'') PLAN, R.ID CODIGO_EMPLEADO, REPLACE(RL.DOCUMENTNUMBER,''-'','''') CEDULA,
       RL.FIRSTNAME PRI_NOM, RL.MIDDLENAME SEG_NOM, RL.LASTNAME PRI_APE, RL.SECONDLASTNAME SEG_APE,
       DECODE(RL.TYPE, 2, ''T'', ''D'') TIP_AFI,  DECODE(RL.RELATIONSHIP,0,''Titular'',l.DESCRIPTION) PARENTESCO, DECODE(RL.GENDER,1,''M'',''F'') SEXO,
       RL.BIRTHDATE FEC_NAC, DECODE(RL.RELATIONSHIP,0,B.MONTHLYSALARY,NULL) SALARIO, DECODE(B.ISLIFE, ''A'', ''Clase 1'', ''B'', ''Clase 2'', ''C'', ''Clase 3'') CLASE,
       TRIM(T.FIRSTNAME) || '' ''  ||  TRIM(T.MIDDLENAME) || '' ''  || TRIM(T.LASTNAME) || '' ''  || TRIM(T.SECONDLASTNAME) BENEFICIARIO, B.RefundBankAccount "NUMERO CUENTA", DECODE(B.RefundBankAccountCurrency,1,''Colones'',2,''D?lares'') MONEDA, DECODE(B.RefundBankAccountType,1,''AH'',2,''CO'') "TIPO CUENTA",
       DECODE(B.RefundBankCode, 1,''Banco BAC San Jos? S.A.'', 2,''Banco BCT S.A.'', 3,''Banco Cathay de Costa Rica S.A.'', 4,''Banco Davivienda S.A.'', 5,''Banco de Costa Rica'', 6,''Banco General S.A.'', 7,''Banco Improsa S.A.'', 8,''Banco Lafise S.A.'', 9,''Banco Nacional de Costa Rica'', 12,''Banco Popular'', 10,''Banco Prom?rica de Costa Rica S.A.'', 13,''MUCAP (Mutual Cartago Ahorro y Prestamo)'', 11,''Scotiabank de Costa Rica S.A'') BANCO,
       	BN1.PARTICIPATIONRATE "PORCIENTO BENEFICIARIO", BN1.FIRSTNAME "PRIMER NOMBRE", BN1.MIDDLENAME "SEGUNDO NOMBRE", BN1.LASTNAME "PRIMER APELLIDO", BN1.SECONDLASTNAME "SEGUNDO APELLIDO", BN1.RELATIONSHIPDESC PARENTESCO, BN1.BirthDate "FECHA NACIIMENTO", NULL"RNC CEDULA",
       	BN2.PARTICIPATIONRATE "PORCIENTO BENEFICIARIO", BN2.FIRSTNAME "PRIMER NOMBRE", BN2.MIDDLENAME "SEGUNDO NOMBRE", BN2.LASTNAME "PRIMER APELLIDO", BN2.SECONDLASTNAME "SEGUNDO APELLIDO", BN2.RELATIONSHIPDESC PARENTESCO, BN2.BirthDate "FECHA NACIIMENTO", NULL"RNC CEDULA",
       	BN3.PARTICIPATIONRATE "PORCIENTO BENEFICIARIO", BN3.FIRSTNAME "PRIMER NOMBRE", BN3.MIDDLENAME "SEGUNDO NOMBRE", BN3.LASTNAME "PRIMER APELLIDO", BN3.SECONDLASTNAME "SEGUNDO APELLIDO", BN3.RELATIONSHIPDESC PARENTESCO, BN3.BirthDate "FECHA NACIIMENTO", NULL"RNC CEDULA"
  FROM RISKROLES RL
  LEFT JOIN RISK R ON R.ID=RL.POLICYID AND R.COMPANYID=RL.COMPANYID
  LEFT JOIN RISKBAYER B ON B.ID=RL.POLICYID AND B.COMPANYID=RL.COMPANYID
  LEFT JOIN LOOKUP l ON l.LOOKUPID =2108 AND l.CODE=RL.RELATIONSHIP
  LEFT JOIN RISKROLES T ON T.POLICYID=RL.POLICYID AND T.COMPANYID=RL.COMPANYID AND T.TYPE=2
  LEFT JOIN (SELECT * FROM (CTE) b1  where b1.row_num = 1) BN1 on BN1.POLICYID = R.ID
  LEFT JOIN (SELECT * FROM (CTE) b1  where b1.row_num = 2) BN2 on BN2.POLICYID = R.ID
  LEFT JOIN (SELECT * FROM (CTE) b1  where b1.row_num = 3) BN3 on BN3.POLICYID = R.ID
 WHERE RL.COMPANYID=4 AND RL.TYPE IN (2,90) AND R.ISSUEDATE >= {desde:date} AND R.ISSUEDATE <= {hasta:date}
ORDER BY R.ID',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'1970-02-07 00:00:00',NULL,'Research',1,NULL,NULL,NULL,NULL);
