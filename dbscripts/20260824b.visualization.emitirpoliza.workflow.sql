-- Actualiza los controles de EmitirPoliza para reflejar el ciclo de borrador, invitación, firma y emisión.
-- El script conserva la configuración de campos existente; la seguridad de cada acción se valida siempre en el API.
UPDATE ALIADOS.VISUALIZATIONS
SET DIALOG = q'~Emisión de una pólizas|título
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
 Número de teléfono+|Teléfono|name=TLF_NUMERO_ASEG|modo=simple
 Correo electrónico+|Correo|name=EMAIL_ASEG
 Ocupación|lista|name=OCUPACION_ASEG|lookup=TRON_G1000100
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
Beneficiarios|tabla
 Identificación+|cedula|name=COD_DOCUM_BENEF
 Primer Nombre+|texto(100)|name=NOM_TERCERO_BENEF|tabletitle=Nombre
 Segundo Nombre+|texto(100)|name=NOM2_TERCERO_BENEF|tablevisible=false
 Primer Apellido+|texto(50)|name=APE1_TERCERO_BENEF|tabletitle=Apellido
 Segundo Apellido+|texto(50)|name=APE2_TERCERO_BENEF|tablevisible=false
 Fecha de nacimiento+|Nacimiento|name=FEC_NAC_BENEF|tabletitle=Nacimiento|tablevisible=false
 Sexo+|lista|name=MCA_SEXO_BENEF|values=F->Femenino,M->Masculino|tablevisible=false|datatype=string
 Número de teléfono+|Teléfono|name=TLF_NUMERO_BENEF|tabletitle=Teléfono
 Correo electrónico+|Correo|name=EMAIL_BENEF
 Parentesco|lista|name=TIP_RELAC|lookup=Relationship|tablevisible=false
 Porcentaje+|Porcentaje|name=PCT_PARTICIPACION
 Provincia+|tron.Provincia|name=ESTADO_BENEF
 Cantón+|tron.Cantón|name=PROVINCIA_BENEF
 Distrito+|tron.Distrito|name=LOCALIDAD_BENEF
Acciones|zona|columns=2|width=8|visible=entry.RAMO.neq.0 
Estado de seguimiento|texto(255)|name=proposalWorkflowStatus|disabled=true|column=12
 Guardar borrador|button|name=btnSaveDraft|class=btn-on-primary|visible=entry.RAMO.eq.117.or.entry.RAMO.eq.401
 Enviar al asegurado|button|name=btnSendLink|class=btn-on-primary|visible=entry.RAMO.eq.117.or.entry.RAMO.eq.401
 Enviar a firma|button|name=btnSendSignature|class=btn-on-primary|visible=entry.RAMO.eq.117.or.entry.RAMO.eq.401
 Confirmar datos|button|name=btnComplete|class=btn-on-primary|visible=entry.RAMO.eq.117.or.entry.RAMO.eq.401
 Reenviar enlace|button|name=btnResendLink|class=btn-on-primary|visible=false
 Anular enlace|button|name=btnRevokeLink|class=btn-on-primary|visible=false
 Retomar corrección|button|name=btnResumeEditing|class=btn-on-primary|visible=false
 Emitir póliza|button|name=btnIssue|class=btn-on-primary
~'
WHERE ID = 9105 AND "SEQUENCE" = 1;

-- La actualización debe afectar exactamente la definición activa del formulario de emisión.
-- Verificar en el registro de despliegue que SQL%ROWCOUNT sea igual a uno.
