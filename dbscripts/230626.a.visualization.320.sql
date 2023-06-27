UPDATE VISUALIZATIONS SET "TYPE"=1, CAPTION='Presupuestos', DESCRIPTION='Para el agente conectado', "STATEMENT"='SELECT p30.cod_ramo, a1800.NOM_RAMO, p30.num_poliza "NUM_PRESUPUESTO", p30.fec_actu,
  LISTAGG(p20.txt_campo, '' - '') WITHIN GROUP (ORDER BY p20.num_secu) "DETALLE" , a1402.nom_fracc_pago "FRACCIONAMIENTO DE PAGO",
  CASE
  WHEN SYSDATE-p30.fec_actu<30 THEN ''Pendiente''
  ELSE ''Vencido''
END AS Vigencia
  FROM P2000030 p30
  LEFT JOIN  p2000020 p20 ON  p30.num_poliza = p20.num_poliza  and p30.cod_cia = p20.cod_cia  and p30.num_spto = p20.num_spto  and p30.num_apli = p20.num_apli  and p30.num_spto_apli = p20.num_spto_apli  and p30.cod_ramo = p20.cod_ramo
  and p20.cod_campo in (''COD_MARCA'',''COD_MODELO'',''ANIO_SUB_MODELO'',''COD_TIP_VEHI'',''COD_PLAN_AUTO'',''IMP_VR'',''DED_AUTO_CYV'', ''TIP_PLAN'',''TIP_VIAJE'',''DES_DESTINO'',''IMP_MONTO_ORI'',''NUM_PRESTAMO'',''FEC_NACIMIENT'',''NUM_PISOS_EDIF'', ''ANO_CONST'',''TXT_CRED_ESTUD'',''FEC_NACIMIENTO'')
  LEFT JOIN a1001403 a1403 ON p30.cod_cia = a1403.cod_cia  and p30.cod_mon = a1403.cod_mon  and p30.cod_ramo = a1403.cod_ramo AND p30.cod_fracc_pago = a1403.cod_fracc_pago
  LEFT JOIN a1001402 a1402 ON   a1403.cod_cia = a1402.cod_cia  and a1403.cod_fracc_pago = a1402.cod_fracc_pago
  LEFT JOIN a1001800 a1800 ON a1800.COD_CIA=p30.COD_CIA AND a1800.COD_RAMO = p30.COD_RAMO
  WHERE p30.fec_efec_poliza >= SYSDATE-{const.30}
  and p30.cod_ramo in (194, 201, 202, 302, 303, 401, 441)
  and p30.tip_spto = ''XX''
  and p30.num_poliza  not in  (
                               select a.num_presupuesto
                               from a2000030 a, p2000030 p
                               where a.num_presupuesto = p.num_poliza
                               and a.fec_efec_poliza>= SYSDATE-{const.30}
                               and p30.cod_agt = {app.P_COD_AGT}
                               )
  and p30.cod_agt = {app.P_COD_AGT}
  group by p30.cod_ramo, a1800.NOM_RAMO, p30.num_poliza, p30.fec_actu,  a1402.nom_fracc_pago
  order by p30.fec_actu desc, p30.num_poliza,  a1402.nom_fracc_pago', ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=10509, UPDATEDATE=TIMESTAMP '2022-05-31 00:00:00.000000', SPECIFICATION='{
    "title": "Presupuestos",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
        "detailId": 321,
        "detailParameters": "P_NUM_POLIZA=NUM_PRESUPUESTO",
        "columns": [
               {
                "field": "NOM_RAMO",
                "title": "Ramo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "NUM_PRESUPUESTO",
                "title": "No. Presupuesto",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.Extend.EmisionFormatter"
            },
            {
                "field": "FEC_ACTU",
                "title": "Fecha",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter"
            },
            {
                "field": "DETALLE",
                "title": "Detalles",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "FRACCIONAMIENTO DE PAGO",
                "title": "Frecuencia de pago",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringCapitalizeFormatter"
            }
        ]
    }
 }', CONNECTIONNAME='Tron', STATEMENTTYPE=1, DIALOG=NULL, STATEMENTEXTEND=NULL, "KEY"=NULL, JAVASCRIPTTOINCLUDE='Extend.js' WHERE ID=320 AND "SEQUENCE"=1;
