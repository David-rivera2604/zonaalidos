UPDATE VISUALIZATIONS SET "TYPE"=1, CAPTION='Detalle de la póliza - Documentos requeridos', DESCRIPTION='Detalle...', "STATEMENT"='SELECT ID, DOCUMENTTYPE, DESCRIPTION, FILENAME, FILESIZE, UPDATEDATE FROM ATTACHMENTS WHERE COMPANYID={app.companyid} AND ENTITYTYPE=3000 AND ENTITYID={P_NUM_POLIZA}', ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=77, UPDATEDATE=TIMESTAMP '2021-12-21 10:19:24.000000', SPECIFICATION='{
  "title": "Documentos cargados",
  "class": "role-Callcenter-notvisible",
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
        "field": "DESCRIPTION",
        "title": "Tipo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "format": "<button name=''download'' type=''button'' class=''btn btn-sm btn-link event'' title=''Permite descargar el archivo'' style=''font-size: 11px;''><i class=''fa fa-download''></i> {DESCRIPTION}</button>",
        "events": true,
        "action_download": "app.ui.Download(''{FILENAME}'', {ID})"
      },
      {
        "field": "FILENAME",
        "title": "Archivo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "FILESIZE",
        "title": "Peso",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "function (value, row, index, field) { if (value === null || value === 0) return ''''; else return parseInt(value / 1024) + ''kb'';}"
      },
      {
        "field": "UPDATEDATE",
        "title": "Fecha",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
    ]
  }
}', CONNECTIONNAME='Research', STATEMENTTYPE=1, DIALOG='|titulo
|zona|12
 Cargar un documento nuevo|Boton|class=btn btn-primary float-right;click=app.ui.ShowModal({ title: @_Cargar de documento@_, subtitle: @_@_, id: 9002, data: { NUM_POLIZA: app.core.URLStringValue(@_P_NUM_POLIZA@_) } })', STATEMENTEXTEND=NULL, "KEY"=NULL, JAVASCRIPTTOINCLUDE=NULL WHERE ID=302 AND "SEQUENCE"=6;