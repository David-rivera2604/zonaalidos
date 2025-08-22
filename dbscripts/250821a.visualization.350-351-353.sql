DELETE FROM VISUALIZATIONS WHERE id IN (350, 351, 353);

INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,UPDATEUSERCODE,UPDATEDATE) VALUES (350,1,1,'Siniestros','Siniestros por agente',TO_CLOB('SELECT a900.NUM_SINI, a80.NUM_EXP, a80.OBS ASIGES, a900.TIP_EST_SINI, G31A.NOM_VALOR NOM_TIP_EST_SINI, L.DESCRIPTION TIPODEINDEMNIZACION, a900.FEC_DENU_SINI,a900.HORA_DENU_SINI, a900.FEC_SINI, a900.HORA_SINI, a900.COD_CAUSA_SINI, G200.NOM_CAUSA, a900.FEC_TERM_SINI, a900.FEC_REAP_SINI, a900.MCA_CULPABLE,a900.TIP_APERTURA,
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
  LEFT JOIN G7000200 G200 ON G200.COD_CIA = G200.COD_CIA AND G200.TIP_CAUSA = 1 AND G200.COD_CAUSA = a900.COD_CAUSA')||TO_CLOB('_SINI
  LEFT JOIN A2000020 A2020 ON A2020.COD_CIA=a900.COD_CIA AND A2020.NUM_POLIZA=a900.NUM_POLIZA AND A2020.NUM_SPTO=0 AND A2020.NUM_APLI=0 AND A2020.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020.NUM_RIESGO=a900.NUM_RIESGO AND A2020.COD_CAMPO=''NUM_MATRICULA''
  LEFT JOIN A7001080 a80 ON a80.COD_CIA=a900.COD_CIA AND a80.NUM_SINI=a900.NUM_SINI AND NOT a80.OBS IS NULL
  LEFT JOIN ALIADOS.PURDYPANELEVENTO E ON E.NUM_SINI=a900.NUM_SINI AND E.NUM_EXP=a80.NUM_EXP AND E.ASIGES=a80.OBS
  LEFT JOIN ALIADOS.LOOKUP L ON L.LOOKUPID=4101 AND L.CODE=E.TIPODEINDEMNIZACION    
  WHERE a900.COD_CIA={app.P_COD_CIA}
    AND a900.COD_AGT={app.P_COD_AGT}  
    AND trunc(a900.FEC_SINI) BETWEEN {desde:date} AND {hasta:date}
 ORDER BY a900.FEC_SINI DESC'),NULL,NULL,NULL,NULL,1,1,TO_CLOB('{
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
        "field": "TIPODEINDEMNIZACION",
        "title": "Tipo de indemnización",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "cellStyle": "app.ExtendClaims.NOM_TIP_EST_SINICellStyle",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter"
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
        "titleTooltip": "Estado MAPFRE",
        "sortable": true,
        "halign": "c')||TO_CLOB('enter",
        "align": "center",
        "cellStyle": "app.ExtendClaims.NOM_TIP_EST_SINICellStyle",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter"
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
}'),'Tron',1,'|titulo
|zona|4
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Filtrar|Boton|class=btn-form btn-primary btn-QueryFilter;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 350, @_@_)',NULL,NULL,'Extend.Claims.js',1,TIMESTAMP'2021-01-23 12:18:19');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,UPDATEUSERCODE,UPDATEDATE) VALUES (351,1,1,'Expedientes','Expedientes del siniestro',TO_CLOB('SELECT a1000.NUM_SINI, a1000.NUM_EXP, a1000.TIP_EXP, G90.NOM_EXP,a1000.FEC_APER_EXP, a1000.FEC_TERM_EXP,  a1000.TIP_EST_EXP, G31A.NOM_VALOR NOM_TIP_EST_EXP,
       nvl(a1000.imp_val_inicial,0) IMP_RESERVA, nvl(a1000.imp_val,0) IMP_ESTIMADO, nvl(a1000.imp_liq,0) IMP_LIQUIDADO, nvl(a1000.imp_pag,0) IMP_PAGADO,
       a1000.TIP_DOCUM, a1000.COD_DOCUM, a1000.NOMBRE, a1000.APELLIDOS
  FROM A7001000 a1000
  LEFT JOIN G7000090 G90 ON G90.COD_CIA = a1000.COD_CIA AND G90.TIP_EXP = a1000.TIP_EXP
  LEFT JOIN G1010031 G31A ON G31A.COD_CAMPO =''TIP_EST_EXP'' AND G31A.COD_VALOR = a1000.TIP_EST_EXP AND G31A.COD_IDIOMA=''ES''
 WHERE a1000.COD_CIA={app.p_cod_cia} AND a1000.NUM_SINI={num_sini} ORDER BY a1000.NUM_EXP'),NULL,NULL,NULL,NULL,1,1,TO_CLOB('{
  "title": "Expedientes del siniestro #{NUM_SINI}",
  "table": {
    "pagination": true,
    "search": false,
    "showToggle": false,
    "showRefresh": true,
    "showColumns": false,
    "showExport": false,
    "showPaginationSwitch": false,
    "exportTypes": [
      "csv",
      "excel"
    ],
    "detailId": 353,
    "detailParameters": "num_sini=NUM_SINI:num_exp=NUM_EXP",
    "columns": [
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
        "field": "NOM_TIP_EST_EXP",
        "title": "Estado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringCapitalizeFormatter"
      },
      {
        "field": "FEC_APER_EXP",
        "title": "Apertura",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter"
      },
      {
        "field": "FEC_TERM_EXP",
        "title": "Termino",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter"
      },
      {
        "field": "IMP_RESERVA",
        "title": "Reserva",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalWithZeroFormatter"
      },
      {
        "field": "IMP_ESTIMADO",
        "title": "Estimado",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalWithZeroFormatter",
        "visible": false
      },
      {
        "field": "IMP_LIQUIDADO",
        "title": "Liquidado",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalWithZeroFormatter",
 ')||TO_CLOB('       "visible": false
      },
      {
        "field": "IMP_PAGADO",
        "title": "Pagado",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalWithZeroFormatter",
        "visible": false
      }
    ]
  }
}'),'Tron',1,NULL,NULL,NULL,NULL,1,TIMESTAMP'2021-01-24 22:30:14');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,UPDATEUSERCODE,UPDATEDATE) VALUES (353,1,1,'Plan de tramitación','Plan de tramitación',TO_CLOB('SELECT DISTINCT q.NUM_exp, s.NOM_NIVEL nivel, t.nom_tramite tramite, LISTAGG(TO_CHAR(q.fec_actu, ''DD/MM/YY HH:MMAM'') || '' '' ||q.obs_tramite, '', '') within GROUP(ORDER BY q.fec_actu) AS observaciones
  FROM A7500000 q
  JOIN G7500020 t ON t.cod_tramite = q.cod_tramite
  JOIN G7500010 s ON s.cod_cia = q.cod_cia AND s.cod_nivel = q.cod_nivel
 WHERE q.cod_cia = {app.p_cod_cia}
   AND q.num_sini = {num_sini}
   AND q.num_exp = {num_exp}
   AND q.tip_est_tramite NOT IN (''IN'')
 GROUP BY q.NUM_exp, s.NOM_NIVEL, q.num_exp, t.nom_tramite'),NULL,NULL,NULL,NULL,1,1,TO_CLOB('{
  "title": "Plan de tramitación",
  "table": {
    "pagination": true,
    "search": false,
    "showToggle": false,
    "showRefresh": true,
    "showColumns": false,
    "showExport": false,
    "showPaginationSwitch": false,
    "exportTypes": [
      "csv",
      "excel"
    ],
    "columns": [
      {
        "field": "NIVEL",
        "title": "Nivel",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter",
        "width": 20,
        "widthUnit": "%"
      },
      {
        "field": "TRAMITE",
        "title": "Tramite",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter",
        "width": 15,
        "widthUnit": "%"
      },
      {
        "field": "OBSERVACIONES",
        "title": "Observaciones",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ExtendClaims.ObservacionesFormatter",
        "width": 65,
        "widthUnit": "%"
      }
    ]
  }
}'),'Tron',1,NULL,NULL,NULL,NULL,1,TIMESTAMP'2021-01-24 22:30:14');
