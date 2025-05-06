UPDATE VISUALIZATIONS SET "TYPE"=9, CAPTION='Emitir una póliza', DESCRIPTION='Form', "STATEMENT"=NULL, ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=10509, UPDATEDATE=TIMESTAMP '2025-04-15 00:00:00.000000', SPECIFICATION=NULL, CONNECTIONNAME=NULL, STATEMENTTYPE=NULL, DIALOG='Emisión de una pólizas|título
Datos generales|zona|columns=4|width=6
 Ramo+|lista|name=RAMO|values=194->Accidentes personales,401->Saldo deudor declarativo,117->Seguro vida colectivo
 Contrato+|lista|name=NUM_CONTRATO|disabled=true
 Póliza Grupo|texto(13)|name=NUM_POLIZA_GRUPO|disabled=true
 Moneda|texto|name=MONEDA|disabled=true
 Inicio de vigencia+|fechainicio|name=EFEC_SPTO
 Fin de vigencia+|fechafin|name=VCTO_SPTO
Datos del asegurado|zona|columns=4|width=6
 Identificación+|cedula|name=COD_DOCUM_ASEG
 Nombre+|texto(20)|name=NOM_TERCERO_ASEG
 Apellido+|texto(20)|name=APE_TERCERO_ASEG
 Fecha de nacimiento|Nacimiento|name=NAC_ASEG
 Sexo|radio|name=MCA_SEXO_ASEG|values=0->Femenino,1->Masculino
 Nacionalidad|tron.País|name=NACIONALIDAD_ASEG
 Provincia|tron.Provincia|name=COD_ESTADO
 Cantón|tron.Cantón|name=COD_PROVINCIA
 Distrito|tron.Distrito|name=COD_LOCALIDAD
 Otra señas|nota(180)|name=DOMICILIO|filas=2|column=12
Datos del riesgo|zona|columns=4|visible=entry.RAMO.neq.0
 Número del préstamo+|texto(30)|name=NUM_PRESTAMO|visible=entry.RAMO.eq.401
 Inicio del préstamo+|fecha|name=INI_PRESTAMO|visible=entry.RAMO.eq.401
 Fin del préstamo+|fecha|name=VCTO_PRESTAMO|visible=entry.RAMO.eq.401
 Sueldo del asegurado+|decimal(18,3)|name=IMP_SUM_ASEG_VC|visible=entry.RAMO.eq.117
 Suma asegurada+|decimal(18,3)|name=IMP_SUMA_ASEG|visible=entry.RAMO.eq.401 
 Prima a facturar+|decimal(18,3)|name=IMP_PRIMA_FACT|visible=entry.RAMO.eq.117
 Prima informada+|decimal(18,3)|name=IMP_PRIMA_INFORMADA|visible=entry.RAMO.eq.117.or.entry.RAMO.eq.401
 Identificación del estudiante+|texto(15)|name=ID_CRED_ESTUDIANTE|visible=entry.RAMO.eq.194
 ¿Asistencia?|radio|name=MCA_ASISTENCIA|values=1->Si,2->No
 Suma asegurada por muerte|decimal(18,3)|name=IMP_SUMA_MUERTE|visible=entry.RAMO.eq.194
 Plan+|lista|name=COD_PLAN_AP|lookup=TRON_TAVID000|datatype=string|visible=entry.RAMO.eq.194
 Emitir|button|name=btnIssue|class=btn-on-primary', STATEMENTEXTEND=NULL, "KEY"='EmitirPoliza', JAVASCRIPTTOINCLUDE='Form.Ext.Altas.js' WHERE ID=9105 AND "SEQUENCE"=1;