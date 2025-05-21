UPDATE VISUALIZATIONS SET "TYPE"=1, CAPTION='Siniestros', DESCRIPTION='Siniestros por agente', "STATEMENT"='SELECT a900.NUM_SINI, a80.NUM_EXP, a80.OBS ASIGES, a900.TIP_EST_SINI, G31A.NOM_VALOR NOM_TIP_EST_SINI, a900.FEC_DENU_SINI,a900.HORA_DENU_SINI, a900.FEC_SINI, a900.HORA_SINI, a900.COD_CAUSA_SINI, G200.NOM_CAUSA, a900.FEC_TERM_SINI, a900.FEC_REAP_SINI, a900.MCA_CULPABLE,a900.TIP_APERTURA,
        a900.COD_RAMO, a1800.NOM_RAMO, a900.NUM_POLIZA, a900.NUM_SPTO, a900.NUM_APLI, a900.NUM_SPTO_APLI, a900.NUM_RIESGO, A2020.VAL_CAMPO Matricula,
       em_f_nom_riesgo_web (a900.cod_cia, a900.num_poliza, a900.num_spto, a900.num_riesgo) nom_riesgo,
       a900.TIP_DOCUM_TOMADOR, a900.COD_DOCUM_TOMADOR, A1399A.NOM_TERCERO NOM_TOMADOR,  A1399A.APE1_TERCERO APE_TOMADOR,
       a900.TIP_DOCUM_ASEG, a900.COD_DOCUM_ASEG, A1399A.NOM_TERCERO NOM_ASEG,  A1399A.APE1_TERCERO APE_ASEG, A1331.EMAIL EMAIL_ASEG,
       a900.TIP_DOCUM_CONTACTO, a900.COD_DOCUM_CONTACTO, a900.NOM_CONTACTO, a900.APE_CONTACTO, a900.TEL_PAIS_CONTACTO, a900.TEL_ZONA_CONTACTO, a900.TEL_NUMERO_CONTACTO, a900.EMAIL_CONTACTO, a900.TIP_RELACION, G31B.NOM_VALOR NOM_TIP_RELACION
  FROM a7000900 a900
  LEFT JOIN G1010031 G31A ON G31A.COD_CAMPO =''TIP_EST_SINI'' AND G31A.COD_VALOR = a900.TIP_EST_SINI AND G31A.COD_IDIOMA=''ES''
  LEFT JOIN G1010031 G31B ON G31B.COD_CAMPO =''TIP_RELACION'' AND G31B.COD_VALOR = a900.TIP_RELACION AND G31B.COD_IDIOMA=''ES''
  LEFT JOIN A1001399 A1399T ON A1399T.COD_CIA=a900.COD_CIA AND A1399T.TIP_DOCUM = a900.TIP_DOCUM_TOMADOR AND  A1399T.COD_DOCUM = a900.COD_DOCUM_TOMADOR
  LEFT JOIN A1001399 A1399A ON A1399A.COD_CIA=a900.COD_CIA AND A1399A.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1399A.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN A1001331 A1331 ON A1331.COD_CIA=a900.COD_CIA AND A1331.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1331.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN a1001800 a1800 ON a1800.COD_CIA=a900.COD_CIA AND a1800.COD_RAMO = a900.COD_RAMO
  LEFT JOIN G7000200 G200 ON G200.COD_CIA = G200.COD_CIA AND G200.TIP_CAUSA = 1 AND G200.COD_CAUSA = a900.COD_CAUSA_SINI
  LEFT JOIN A2000020 A2020 ON A2020.COD_CIA=a900.COD_CIA AND A2020.NUM_POLIZA=a900.NUM_POLIZA AND A2020.NUM_SPTO=0 AND A2020.NUM_APLI=0 AND A2020.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020.NUM_RIESGO=a900.NUM_RIESGO AND A2020.COD_CAMPO=''NUM_MATRICULA''
  LEFT JOIN A7001080 a80 ON a80.COD_CIA=a900.COD_CIA AND a80.NUM_SINI=a900.NUM_SINI AND NOT a80.OBS IS NULL
  WHERE a900.COD_CIA={app.P_COD_CIA}
    AND a900.COD_AGT={app.P_COD_AGT}
    AND trunc(a900.FEC_SINI) BETWEEN {desde:date} AND {hasta:date}
 ORDER BY a900.FEC_SINI DESC', ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=1, UPDATEDATE=TIMESTAMP '2021-01-23 12:18:19.000000', SPECIFICATION='{
  "title": "Siniestros",
  "table": {
    "skipload": false,
    "extendName": "ExtendClaims",    
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
    "detailId": 351,
    "detailParameters": "num_sini=NUM_SINI",
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
        "field": "ASIGES",
        "title": "ASIGES",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ExtendClaims.ASIGESFormatter",
        "visible": true,
        "events": true,
        "action_viewClaimPanel": "app.ExtendClaims.ShowClaimPanel(row)",
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
        "field": "NUM_POLIZA",
        "title": "No. P?liza",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ExtendClaims.NUM_POLIZAFormatter",
        "visible": true,
        "events": true,
        "action_viewPolicy": "app.ExtendClaims.ShowPolicyDetail(row)",
      },
      {
        "field": "MATRICULA",
        "title": "Placa",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "NOM_ASEG",
        "title": "Asegurado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ExtendClaims.NOM_ASEG2Formatter",
        "events": true,        
        "action_viewTercero": "app.ExtendClaims.ShowTercero(row)",
      },
      {
        "field": "COD_DOCUM_ASEG",
        "visible": false
      },
      {
        "field": "APE_ASEG",
        "visible": false
      },
      {
        "field": "NUM_SINI",
        "title": "Detalle",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ExtendClaims.SINIDetailFormatter",
        "visible": false
      }
    ]
  }
}', CONNECTIONNAME='Tron', STATEMENTTYPE=1, DIALOG='|titulo
|zona|4
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Filtrar|Boton|class=btn-form btn-primary btn-QueryFilter;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 350, @_@_)', STATEMENTEXTEND=NULL, "KEY"=NULL, JAVASCRIPTTOINCLUDE='Extend.Claims.js' WHERE ID=350 AND "SEQUENCE"=1;