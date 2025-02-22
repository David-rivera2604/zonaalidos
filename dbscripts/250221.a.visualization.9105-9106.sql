INSERT INTO VISUALIZATIONS (ID, "SEQUENCE", "TYPE", CAPTION, DESCRIPTION, "STATEMENT", ICON, ICONCLASS, VALUEFORMAT, ENTITYTYPE, RECORDSTATUS, COMPANYID, UPDATEUSERCODE, UPDATEDATE, SPECIFICATION, CONNECTIONNAME, STATEMENTTYPE, DIALOG, STATEMENTEXTEND, "KEY", JAVASCRIPTTOINCLUDE) VALUES(9105, 1, 9, 'Emitir una póliza', 'Form', NULL, NULL, NULL, NULL, NULL, 1, 1, 777, TIMESTAMP '2023-02-27 00:00:00.000000', NULL, NULL, NULL, 'Emisión de una pólizas|título
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
 Suma asegurada+|decimal(18,3)|name=IMP_SUMA_ASEG|visible=entry.RAMO.eq.401
 Prima informada+|decimal(18,3)|name=IMP_PRIMA_INFORMADA|visible=entry.RAMO.eq.117.or.entry.RAMO.eq.401
 Identificación del estudiante+|texto(15)|name=ID_CRED_ESTUDIANTE|visible=entry.RAMO.eq.194
 ¿Asistencia?|radio|name=MCA_ASISTENCIA|values=1->Si,2->No
 Suma asegurada por muerte|decimal(18,3)|name=IMP_SUMA_MUERTE|visible=entry.RAMO.eq.194
 Plan+|lista|name=COD_PLAN_AP|lookup=TRON_TAVID000|datatype=string|visible=entry.RAMO.eq.194
 Emitir|button|name=btnIssue|class=btn-on-primary', NULL, 'EmitirPoliza', 'Form.Ext.Altas.js');
INSERT INTO VISUALIZATIONS (ID, "SEQUENCE", "TYPE", CAPTION, DESCRIPTION, "STATEMENT", ICON, ICONCLASS, VALUEFORMAT, ENTITYTYPE, RECORDSTATUS, COMPANYID, UPDATEUSERCODE, UPDATEDATE, SPECIFICATION, CONNECTIONNAME, STATEMENTTYPE, DIALOG, STATEMENTEXTEND, "KEY", JAVASCRIPTTOINCLUDE) VALUES(9106, 1, 9, 'Anular una póliza', 'Form', NULL, NULL, NULL, NULL, NULL, 1, 1, 777, TIMESTAMP '2023-02-27 00:00:00.000000', NULL, NULL, NULL, 'Anular una pólizas|título
Datos generales|zona|columns=4|width=6
 Ramo+|lista|name=RAMO|values=194->Accidentes personales,401->Saldo deudor declarativo,117->Seguro vida colectivo|disabled=true
 Contrato+|lista|name=NUM_CONTRATO|disabled=true
 Póliza Grupo|texto(13)|name=NUM_POLIZA_GRUPO|disabled=true
 Moneda|texto|name=MONEDA|disabled=true
 Inicio de vigencia+|fechainicio|name=EFEC_SPTO|disabled=true
 Fin de vigencia+|fechafin|name=VCTO_SPTO|disabled=true
Datos del asegurado|zona|columns=4|width=6
 Identificación+|cedula|name=COD_DOCUM_ASEG|disabled=true
 Nombre+|texto(20)|name=NOM_TERCERO_ASEG|disabled=true
 Apellido+|texto(20)|name=APE_TERCERO_ASEG|disabled=true
 Fecha de nacimiento|Nacimiento|name=NAC_ASEG|disabled=true
 Sexo|radio|name=MCA_SEXO_ASEG|values=0->Femenino,1->Masculino|disabled=true
 Nacionalidad|tron.País|name=NACIONALIDAD_ASEG|disabled=true
 Provincia|tron.Provincia|name=COD_ESTADO|disabled=true
 Cantón|tron.Cantón|name=COD_PROVINCIA|disabled=true
 Distrito|tron.Distrito|name=COD_LOCALIDAD|disabled=true
 Otra señas|nota(180)|name=DOMICILIO|filas=2|column=12|disabled=true
Datos del riesgo|zona|columns=4|visible=entry.RAMO.neq.0
 Número del préstamo|texto(30)|name=NUM_PRESTAMO|visible=entry.RAMO.eq.401|disabled=true
 Inicio del préstamo|fecha|name=INI_PRESTAMO|visible=entry.RAMO.eq.401|disabled=true
 Fin del préstamo|fecha|name=VCTO_PRESTAMO|visible=entry.RAMO.eq.401|disabled=true
 Suma asegurada|decimal(18,3)|name=IMP_SUMA_ASEG|visible=entry.RAMO.eq.401|disabled=true
 Prima informada|decimal(18,3)|name=IMP_PRIMA_INFORMADA|visible=entry.RAMO.eq.117.or.entry.RAMO.eq.401|disabled=true
 Identificación del estudiante|texto(15)|name=ID_CRED_ESTUDIANTE|visible=entry.RAMO.eq.194|disabled=true
 ¿Asistencia?|radio|name=MCA_ASISTENCIA|values=1->Si,2->No|disabled=true
 Suma asegurada por muerte|decimal(18,3)|name=IMP_SUMA_MUERTE|visible=entry.RAMO.eq.194|disabled=true
 Plan|texto(30)|name=COD_PLAN_AP|visible=entry.RAMO.eq.194|disabled=true
 Anular|button|name=btnIssue|class=btn-on-primary|disabled=true
', NULL, 'AnularPoliza', 'Form.Ext.Bajas.js');