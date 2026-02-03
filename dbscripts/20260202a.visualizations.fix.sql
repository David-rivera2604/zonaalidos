UPDATE VISUALIZATIONS v SET JAVASCRIPTTOINCLUDE = 'Extend.Policy.js' WHERE id= 302 AND SEQUENCE = 1;

UPDATE ALIADOS.VISUALIZATIONS
SET DIALOG='Carga de documento|título|name=DocumentUpload
|zona|12
 Descripción+|Texto(120)
 Archivo+|Archivo
 Guardar|Boton|class=btn-form btn-primary float-right;event.click=app.Ex_Policy.FileUpLoad({NUM_POLIZA})'
WHERE ID=9002 AND "SEQUENCE"=1;