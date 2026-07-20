INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (333,1,1,'Presupuestos pendientes de emitir','Presupuestos pendientes de emitir por agente',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-07-10 19:57:22',TO_CLOB('{
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
            "sortable": ')||TO_CLOB('true,
            "halign": "center",
            "align": "left",
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
            "formatter": "function (value, row, index, field) { var producto = ''mapfremas''; var ramo = row.PROPOSALID.substring(0, 3); if(ramo == 302){producto=''mapfremas'';}if(ramo == 201){producto=''hogartotal'';} if(ramo == 202){producto=''multirriesgo'';} if(ramo == 401){producto=''SaldoDeudor'';} return (row.STATUS===33?''<a class=@_btn btn-sm btn-outline btn-primary@_ href='' + app.setting.basepath + ''emision/''+ producto + ''?mode=continue&presupuesto='' + row.PROPOSALID + ''>Emitir</a>'': '''') +'' '' +  (row.STATUS === 4 || row.STATUS===31 || row.STATUS===32 || row.SIGNINGTYPE===''M''?''<button type=\"button\" name=\"enviarsolicitud\" class=\"btn btn-sm btn-outline btn-warning event\">Reenvia solicitud</button>'': '''' );}",
            "events": true,
            "action_enviarsolicitud": "app.ui.ShowSideBar({ title: ''Enviar solicitud'', subtitle: ''Presupuesto #{PROPOSALID}'', id: 9001, data: row})"
         }
      ]
   }
   }'),'Research',1,NULL,NULL,NULL,'Extend.js',TO_CLOB('SELECT ID, PROPOSALID, INSUREDID, REPLACE(INSUREDID, ''-'', '''') INSUREDIDCLEAR, INSUREDNAME, SUMMARY, ISSUEDATE, SIGNINGREQUESTID, STATUS, LKS.DESCRIPTION STATUSDESC, SigningType, PrimaryEmailAddress
  FROM POLICYPROPOSAL
  LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 2050 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE = POLICYPROPOSAL.STATUS
 WHERE POLICYPROPOSAL.COMPANYID={app.companyid} AND AGENTCODE={app.agentcode} AND STATUS <> 10 ORDER BY ISSUEDATE DESC, POLICYPROPOSAL.UPDATEDATE DESC'));
