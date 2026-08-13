INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (42,1,1,'Solicitudes','Solicitudes',NULL,NULL,NULL,NULL,1,1,77,TIMESTAMP'2022-01-20 21:15:52',TO_CLOB('{
    "title": "Todas",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": false,
        "showPaginationSwitch": false,
        "detailView": false,
        "columns": [
            {
                "field": "Inclusión",
                "title": "Inclusión",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "Ramo",
                "title": "Tipo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Póliza",
                "title": "Solicitud",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "function (value, row, index, field) { return ''<a href=../Bayer/Inclusion?id='' + row.Id + ''>'' + value + ''</a>'';}",
                "visible": true
            },
            {
                "field": "Identificación",
                "title": "Identificación",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Asegurado",
                "title": "Asegurado",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Filial",
                "title": "Filial",
                "sortable": true,
                "halign"')||TO_CLOB(': "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "PolizaTron",
                "title": "N° de póliza",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Estado",
                "title": "Estado",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            }
        ]
    }
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT P.ISSUEDATE "Inclusión", LKR.DESCRIPTION "Ramo", P.ID "Id", DECODE(P.POLICYID, 0,''I-''|| P.ID, P.POLICYID) "Póliza",
        A.DOCUMENTNUMBER "Identificación", TRIM(A.FIRSTNAME) || '' ''  ||  TRIM(A.MIDDLENAME) || '' ''  || TRIM(A.LASTNAME) || '' ''  || TRIM(A.SECONDLASTNAME) "Asegurado", LKS.DESCRIPTION "Estado",
        LKF.DESCRIPTION "Filial", LKF.EXTENDSTRINGVALUE1 "PolizaTron"
  FROM Risk P
  LEFT JOIN RiskRoles A ON A.POLICYID = P.ID AND A.TYPE=2
  LEFT JOIN RiskBayer B ON B.ID = P.ID
  LEFT JOIN LOOKUP LKR ON LKR.LOOKUPID = 2000 AND LKR.COMPANYID=P.COMPANYID AND LKR.LANGUAGE=1 AND LKR.CODE = P.LINEOFBUSINESSCODE
  LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 2050 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE = P.STATUS
  LEFT JOIN LOOKUP LKF ON LKF.LOOKUPID = 4000 AND LKF.COMPANYID=P.COMPANYID AND LKF.LANGUAGE=1 AND LKF.CODE = B.MAINPOLICYID
 WHERE P.CompanyId={app.companyid} AND P.STATUS > 1
 ORDER BY P.ISSUEDATE DESC'));
