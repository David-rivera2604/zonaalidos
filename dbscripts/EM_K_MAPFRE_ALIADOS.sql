CREATE OR REPLACE PACKAGE BODY TRON2000.EM_K_MAPFRE_ALIADOS
AS


PROCEDURE PURDYREPSINIESTROS (p_COD_AGT NUMBER, p_refcur IN OUT SYS_REFCURSOR) IS
BEGIN
  OPEN p_refcur FOR
WITH balance AS (SELECT ROW_NUMBER () OVER (PARTITION BY ASIGES ORDER BY ID) BLine, b1.* FROM Aliados.PurdyPanelBalance b1 WHERE b1.tipodedocumento = 2),
 parcialmo AS (SELECT ROW_NUMBER () OVER (PARTITION BY ASIGES ORDER BY ID) BLine, b1.* FROM Aliados.PurdyPanelBalance b1 WHERE b1.tipodedocumento = 1),
 dedu AS (SELECT ROW_NUMBER () OVER (PARTITION BY ASIGES ORDER BY ID) BLine, b1.* FROM Aliados.PurdyPanelBalance b1 WHERE b1.tipodedocumento = 3),
 ajuste AS (SELECT ROW_NUMBER () OVER (PARTITION BY ASIGES ORDER BY ID) BLine, b1.* FROM Aliados.PurdyPanelBalance b1 WHERE b1.tipodedocumento = 4)
  SELECT a900.COD_CAUSA_SINI,
       a900.NUM_POLIZA "No.Poliza", A2020.VAL_CAMPO "Placa", A1399A.NOM_TERCERO || ' ' || A1399A.APE1_TERCERO "TOMADOR", A1399G.NOM_TERCERO || ' ' || A1399G.APE1_TERCERO "ACREDOR", dano.Observaciones "Observaciones",
       A1399A.NOM_TERCERO || ' ' || A1399A.APE1_TERCERO "Nombre Asegurado", a80.OBS ASIGES,
       dano.OT "OT", dano.asesorTaller ASESOR, dano.expediente "EXPEDIENTE",
       a900.FEC_SINI "FECHA INGRESO SISTEMA", a900.FEC_DENU_SINI "Ingreso de Aviso", EXTRACT(YEAR FROM a900.FEC_DENU_SINI) "A?o", TO_CHAR(a900.FEC_DENU_SINI, 'Month', 'NLS_DATE_LANGUAGE = spanish') "Mes del Siniestro",
       a900.FEC_DENU_SINI "Fecha del evento", a900.NUM_SINI "No.Siniestro",
       ARec.FirstName || ' ' || ARec.LastName "Analista Reclamos", AGes.FirstName || ' ' || AGes.LastName "Analista Gestora",
       (SELECT DESCRIPTION FROM ALIADOS.LOOKUP WHERE LOOKUPID=4101 AND CODE=eve.TIPODEINDEMNIZACION) "Tipo de indemnizaci?n",
       (SELECT DESCRIPTION FROM ALIADOS.LOOKUP WHERE LOOKUPID=4102 AND CODE=eve.motivonoprocede) "Motivo No Procede",
       eve.detallenoprocede "Observaci?n (NoRepara)", A2020C.VAL_CAMPO "Chasis", G200.NOM_CAUSA "DETALLE SINIESTRO",
       (SELECT DESCRIPTION FROM ALIADOS.LOOKUP WHERE LOOKUPID=4103 AND CODE=dano.severidaddelsiniestro) "Severidad del siniestro", A2020M.TXT_CAMPO "MARCA", eve.empresa "EMPRESA",
       a900.TIP_DOCUM_ASEG || '-' || a900.COD_DOCUM_ASEG "CedulaAsegurado", A1331.EMAIL "CorreoAsegurado",
       A1331.TLF_NUMERO "Telefono Asegurado", a400.NOM_MON "Moneda de la poliza", A2020I.VAL_CAMPO "Valor Asegurado",
       eve.primaanual "PrimaAnual",
      ( SELECT NVL(SUM(IMP_RECIBO),0)
  FROM TRON2000.A2990700 a
 WHERE a.NUM_POLIZA=a900.NUM_POLIZA
   AND a.num_spto IN (select max(aa.num_spto) from a2000030 aa JOIN a2990700 t on t.cod_cia = aa.cod_cia and t.num_poliza = aa.num_poliza and t.num_spto = aa.num_spto and t.num_apli = aa.num_apli and t.num_spto_apli = aa.num_spto_apli and t.tip_situacion = 'CT' where aa.cod_cia  = a.cod_cia and aa.num_poliza = a.NUM_POLIZA AND aa.mca_spto_anulado = 'N')
   AND num_recibo IN (select t.num_recibo from a2990700 t where t.cod_cia = a.cod_cia and t.num_poliza = a.num_poliza and t.num_spto = a.num_spto and t.num_apli = a.num_apli and t.num_spto_apli = a.num_spto_apli and t.tip_situacion = 'CT')) "PrimasPagadas",
       eve.deducible "Deducible ORIGINAL",
       dano.TipoCambio "Tipo de Cambio", dano.deduciblecol "Deducible en colones", dano.deducibledol "Deducible en dolares",
       DECODE(eve.enviadoaInvestigacion, 1, 'Si', 'No') "Enviado a Investigaci?n", DECODE(eve.posiblesubrogacion, 1, 'Si', 'No')  "Enviado a subrogaci?n POR PURDY-posible sub", eve.FECHAPOSIBLESUBROGACION "Fecha enviado a Subrogacion",
       NULL "Subrogaci?n Aprobada-llena Adm",
       DECODE(eve.enviadoaacompanamientoLegal, 1, 'Si', 'No') "Enviado a acompa?amiento Legal", eve.FECHAENVIADOACOMPALEGAL "Fecha enviado a compa?amiento",
       (SELECT DESCRIPTION FROM ALIADOS.LOOKUP WHERE LOOKUPID=4104 AND CODE=dano.taller) "Taller", DECODE(dano.taller, 1, 'Interno', 'Externo') "Tipo de taller", NULL "Taller fuera de red",
       dano.FECHAENVIODELAVALUO "Fecha envio del avaluo",
       dano.perdidatmonto "Perdida total", dano.perdidatmontocol "Perdida Colones", dano.perdidatmontodol "Perdida Dolares",
       dano.prerepuestos*1.13 "Repuesto con iva", dano.prerepuestos "Total repuesto sin iva", dano.prerepuestosdesc "NC Descuento",
       dano.prerepuestos - dano.prerepuestosdesc "Total repuestos - Propuesta indemnizatoria sin IVA", CAST( (dano.perdida - dano.prerepuestosdesc)/DECODE(dano.TipoCambio, NULL, 1, 0, 1, dano.TipoCambio) AS NUMBER(18,2)) "Rep $",
       CAST(dano.premano/16800 AS NUMBER(18,2)) "Cantidad de horas", dano.premano "Mano de obra x costo", dano.premano+dano.premanoiva "Mano de obra con IVA",
       dano.premano "Mano de obra sin IVA",
       CAST(dano.premano/DECODE(dano.TipoCambio, NULL, 1, 0, 1, dano.TipoCambio) AS NUMBER(18,2)) "Mano de obra $",
       NVL(dano.perdidatmonto,0) +(NVL(dano.prerepuestos,0) - NVL(dano.prerepuestosdesc,0)) + NVL(dano.premano,0) "Monto Total Reparaci?n sin IVA",
       NULL "Total Rep con depresaci?n", NULL "NC de depreciacion rep", NULL "Total de la depreciacion", NULL "Infraseguro", NULL "Mo Otros Cargos", NULL "Total Otros Cargos Cliente",
CAST(CASE WHEN eve.TIPODEINDEMNIZACION= 8 THEN 0
WHEN NVL(dano.perdidatmonto,0)+(dano.perdrepuesto - dano.prerepuestosdesc)+NVL(dano.premano,0) = 0 THEN 0
ELSE NVL(dano.perdidatmonto,0)+(dano.perdrepuesto - dano.prerepuestosdesc)+NVL(dano.premano,0)-dano.deduciblecol
END AS NUMBER(18,2)) "Monto indemnizar inicial",
CAST(CASE WHEN eve.TIPODEINDEMNIZACION= 8 THEN 0
WHEN NVL(dano.perdidatmonto,0)+(dano.perdrepuesto - dano.prerepuestosdesc)+NVL(dano.premano,0) = 0 THEN 0
ELSE NVL(dano.perdidatmonto,0)+(dano.perdrepuesto - dano.prerepuestosdesc)+NVL(dano.premano,0)-dano.deduciblecol
END /DECODE(dano.TipoCambio, NULL, 1, 0, 1, dano.TipoCambio) AS NUMBER(18,2)) "Total Monto indemnizar $",
       dano.fechasolicitado "Fecha dano Oculto", dano.observaciones "Da?o Oculto Observaci?n",
       CAST(dano.danoocultomano/16800 AS NUMBER(18,2)) "Horas Dano Oculto", dano.danoocultomano "MO x costo de Hora",
       dano.danoocultomanototal "DANO OCULTO MO CON IVA", dano.danoocultomano  "DANO OCULTO MO SIN IVA",  CAST( dano.danoocultomanototal/DECODE(dano.TipoCambio, NULL, 1, 0, 1, dano.TipoCambio) AS NUMBER(18,2)) "MO DANO OCULTO $",
       dano.danoocultototal "DANO OCULTO REP CON IVA", dano.DANOOCULTOMONTOREPDANOOCULTO "DANO OCULTO REP SIN IVA", dano.danoocultodesc "NC REP DANO OCULTO",
       dano.DANOOCULTOMONTOREPDANOOCULTO-dano.danoocultodesc "Total Rep Da?o Oculto",
       CAST( dano.danoocultototal/DECODE(dano.TipoCambio, NULL, 1, 0, 1, dano.TipoCambio) AS NUMBER(18,2)) "RE DA?O OCULTO $",
       dano.danoocultomano+dano.DANOOCULTOMONTOREPDANOOCULTO-dano.danoocultodesc "Total Dano Oculto",
       NULL "AJUSTE POR DIFERENCIA EN PRECIOS DE REP",
       (dano.DANOOCULTOMANO+dano.PREMANO) + (dano.prerepuestos - dano.prerepuestosdesc+dano.DANOOCULTOMONTOREPDANOOCULTO-dano.danoocultodesc) - dano.deduciblecol "Total a indemnizar Dano Oculto Final",
       dano.DANOOCULTOMANO+dano.PREMANO "Total MO",
       dano.prerepuestos - dano.prerepuestosdesc+dano.DANOOCULTOMONTOREPDANOOCULTO-dano.danoocultodesc "Total Rep",
       pm.Fecha "Fecha Liquidacion Parcial MO", TO_CHAR(pm.Fecha, 'Month', 'NLS_DATE_LANGUAGE = spanish') "Mes Pago Mano Obra Parcial", pm.NumeroDeDocumento "# Factura MO Parcial", pm.Monto "Parcial MO (Sin IVA)",
       dedu.Fecha "Fecha Pago Deducible", TO_CHAR(dedu.Fecha, 'Month', 'NLS_DATE_LANGUAGE = spanish') "Mes Pago Deducible", dedu.monto "NC por Deducible (Taller)", NULL "Deducible Gestora", NULL "NC Otros Cargos", NULL "TOTAL MO",
       b1.Fecha "Fecha Liquidacion Parcial Repuestos 1", TO_CHAR(b1.Fecha, 'Month', 'NLS_DATE_LANGUAGE = spanish') "Mes Pago RE 1", b1.NumeroDeDocumento "# Factura Parcial RE 1", b1.Monto "Parcial RE (Sin IVA) SUBTOTAL", b1.NCRepuesto "NC REPUESTOS 1",
       pm.Monto + b1.Monto - b1.NCRepuesto "LIQUIDACION 1",
       b2.Fecha "Fecha Liquidacion Parcial Repuestos 2", TO_CHAR(b2.Fecha, 'Month', 'NLS_DATE_LANGUAGE = spanish') "Mes Pago RE 2", b2.NumeroDeDocumento "# Factura Parcial RE 2", b2.Monto "Parcial RE (Sin IVA) SUBTOTAL", b2.NCRepuesto "NC REPUESTOS 2",
       b3.Fecha "Fecha Liquidacion Parcial Repuestos 3", TO_CHAR(b3.Fecha, 'Month', 'NLS_DATE_LANGUAGE = spanish') "Mes Pago RE 3", b3.NumeroDeDocumento "# Factura Parcial RE 3", b3.Monto "Parcial RE (Sin IVA) SUBTOTAL", b3.NCRepuesto "NC REPUESTOS 3",
       b4.Fecha "Fecha Liquidacion Parcial Repuestos 4", TO_CHAR(b4.Fecha, 'Month', 'NLS_DATE_LANGUAGE = spanish') "Mes Pago RE 4", b4.NumeroDeDocumento "# Factura Parcial RE 4", b4.Monto "Parcial RE (Sin IVA) SUBTOTAL", b4.NCRepuesto "NC REPUESTOS 4",
       b5.Fecha "Fecha Liquidacion Parcial Repuestos 5", TO_CHAR(b5.Fecha, 'Month', 'NLS_DATE_LANGUAGE = spanish') "Mes Pago RE 5", b5.NumeroDeDocumento "# Factura Parcial RE 5", b5.Monto "Parcial RE (Sin IVA) SUBTOTAL", b5.NCRepuesto "NC REPUESTOS 5",
       b6.Fecha "Fecha Liquidacion Parcial Repuestos 6", TO_CHAR(b6.Fecha, 'Month', 'NLS_DATE_LANGUAGE = spanish') "Mes Pago RE 6", b6.NumeroDeDocumento "# Factura Parcial RE 6", b6.Monto "Parcial RE (Sin IVA) SUBTOTAL", b6.NCRepuesto "NC REPUESTOS 6",
       NVL(b2.Monto,0) - NVL(b2.NCRepuesto,0) + NVL(b3.Monto,0) - NVL(b3.NCRepuesto,0) + NVL(b4.Monto,0) - NVL(b4.NCRepuesto,0) + NVL(b5.Monto,0) - NVL(b5.NCRepuesto,0) + NVL(b6.Monto,0) - NVL(b6.NCRepuesto,0) "LIQUIDACION FINAL 2",
       (pm.Monto + b1.Monto - b1.NCRepuesto)+ (NVL(b2.Monto,0) - NVL(b2.NCRepuesto,0) + NVL(b3.Monto,0) - NVL(b3.NCRepuesto,0) + NVL(b4.Monto,0) - NVL(b4.NCRepuesto,0) + NVL(b5.Monto,0) - NVL(b5.NCRepuesto,0) + NVL(b6.Monto,0) - NVL(b6.NCRepuesto,0)) "Total pagado final",
       NULL "Fecha Pago Perdida Total", NULL "Mes Pago Perdida Total", NULL "Monto Perdida Total EN LA MONEDA DE PAGO",
       NULL "Monto Perdida DOLARIZADO final", NULL "salvamento MONTO VENDIDO O RECUPERADO SIN IVA",
       ajuste.Monto "Ajuste",
       (dano.PERDREPUESTO - dano.PERDREPUESTODESC + dano.PERDMANO - dano.DEPRECIACIONYEXCLUSIONES - dano.deduciblecol ) -
     ((SELECT NVL(SUM(Monto-NCREPUESTO),0) FROM Aliados.PurdyPanelBalance bt1 WHERE bt1.ASIGES = a80.OBS AND bt1.tipodedocumento != 3) +
     (SELECT NVL(SUM(Monto-NCREPUESTO),0) FROM Aliados.PurdyPanelBalance bt2 WHERE bt2.ASIGES = a80.OBS AND bt2.tipodedocumento = 3)) "Pendiente x liquidar final",
       ajuste.Observacion "Observaci?n ajuste", NULL "RECUPERADO EN SUBROGACION", NULL "Monto a recuperar total de subrogacion", NULL "Monto ingresado de subrogacion",
       NULL "saldo subrogacion", NULL "SUBROGACION-OBSERVACIONES", NULL "CodigoCXC", NULL "NombredeCXCSubrogaci?n",
       NULL "FECHA TOMADO POR LEGAL", NULL "POSIBLE SUBROGAci?n X ABOGADO", NULL "CASO REAL DE SUBROGACION-ABODADO SENTENCIA O CONCILIACION",
       NULL "MUERTOS", NULL "LESIONADOS", NULL "ASESOR LEGAL ASIGNADO", NULL "ESTADO PROCESAL", NULL "RECOMENDAci?n LEGAL",
       NULL "Nombre Tercero-Condenado", NULL "Cedula Tercero-Condenado", NULL "Telefono Tercero-Condenado", NULL "Email Tercero-Condenado", NULL "Placa Tercero Condenado",
       NULL "Nombre-Tercero Propietario", NULL "C?dula Tercero-Propietario", NULL "Telefono-Tercero-Propietario", NULL "Email Tercero-Propietario",
       NULL "Lugar del accidente", NULL "Juzgado", NULL "Expediente Judicial", NULL "Fecha de la sentencia", NULL "ASEGURADORA"
  FROM a7000900 a900
  LEFT JOIN A1001399 A1399A ON A1399A.COD_CIA=a900.COD_CIA AND A1399A.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1399A.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN A1001331 A1331 ON A1331.COD_CIA=a900.COD_CIA AND A1331.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1331.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN G7000200 G200 ON G200.COD_CIA = G200.COD_CIA AND G200.TIP_CAUSA = 1 AND G200.COD_CAUSA = a900.COD_CAUSA_SINI
  LEFT JOIN A2000020 A2020 ON A2020.COD_CIA=a900.COD_CIA AND A2020.NUM_POLIZA=a900.NUM_POLIZA AND A2020.NUM_SPTO=0 AND A2020.NUM_APLI=0 AND A2020.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020.NUM_RIESGO=a900.NUM_RIESGO AND A2020.COD_CAMPO='NUM_MATRICULA'
  LEFT JOIN A2000020 A2020C ON A2020C.COD_CIA=a900.COD_CIA AND A2020C.NUM_POLIZA=a900.NUM_POLIZA AND A2020C.NUM_SPTO=0 AND A2020C.NUM_APLI=0 AND A2020C.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020C.NUM_RIESGO=a900.NUM_RIESGO AND A2020C.COD_CAMPO='COD_CHASSIS'
  LEFT JOIN A2000020 A2020M ON A2020M.COD_CIA=a900.COD_CIA AND A2020M.NUM_POLIZA=a900.NUM_POLIZA AND A2020M.NUM_SPTO=0 AND A2020M.NUM_APLI=0 AND A2020M.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020M.NUM_RIESGO=a900.NUM_RIESGO AND A2020M.COD_CAMPO='COD_MARCA'
  LEFT JOIN A2000020 A2020I ON A2020I.COD_CIA=a900.COD_CIA AND A2020I.NUM_POLIZA=a900.NUM_POLIZA AND A2020I.NUM_SPTO=0 AND A2020I.NUM_APLI=0 AND A2020I.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020I.NUM_RIESGO=a900.NUM_RIESGO AND A2020I.COD_CAMPO='IMP_VR'
  LEFT JOIN A2000060 A60G ON A60G.NUM_POLIZA=a900.NUM_POLIZA AND A60G.MCA_BAJA = 'N' AND A60G.MCA_VIGENTE = 'S' AND A60G.TIP_BENEF='8'
  LEFT JOIN A1001399 A1399G ON A1399G.COD_CIA=A60G.COD_CIA AND A1399G.TIP_DOCUM = A60G.TIP_DOCUM AND  A1399G.COD_DOCUM = A60G.COD_DOCUM
  LEFT JOIN A2000030 a30  ON a30.COD_CIA=1 AND a30.NUM_POLIZA=a900.NUM_POLIZA AND a30.NUM_SPTO = a900.NUM_SPTO  AND a30.NUM_APLI = NVL(a900.NUM_APLI, 0) AND a30.NUM_SPTO_APLI = NVL(a900.NUM_SPTO_APLI, 0)
  LEFT JOIN a1000400 a400 on a400.COD_MON = a30.COD_MON AND a400.COD_CIA = a30.COD_CIA
  LEFT JOIN A7001080 a80 ON a80.COD_CIA=a900.COD_CIA AND a80.NUM_SINI=a900.NUM_SINI AND NOT a80.OBS IS NULL
  JOIN Aliados.PurdyPanelEvento eve ON eve.ASIGES = a80.OBS
  LEFT JOIN Aliados.UserMember ARec ON ARec.UserID = eve.analistareclamos
  LEFT JOIN Aliados.UserMember AGes ON AGes.UserID = eve.analistagestora
  LEFT JOIN Aliados.PurdyPanelDano dano ON dano.ASIGES = a80.OBS
  LEFT JOIN balance b1 ON b1.ASIGES = a80.OBS AND b1.BLine=1
  LEFT JOIN balance b2 ON b2.ASIGES = a80.OBS AND b2.BLine=2
  LEFT JOIN balance b3 ON b3.ASIGES = a80.OBS AND b3.BLine=3
  LEFT JOIN balance b4 ON b4.ASIGES = a80.OBS AND b4.BLine=4
  LEFT JOIN balance b5 ON b5.ASIGES = a80.OBS AND b5.BLine=5
  LEFT JOIN balance b6 ON b6.ASIGES = a80.OBS AND b6.BLine=6
  LEFT JOIN parcialmo pm ON pm.ASIGES = a80.OBS AND pm.BLine=1
  LEFT JOIN dedu dedu ON dedu.ASIGES = a80.OBS AND dedu.BLine=1
  LEFT JOIN ajuste ajuste ON ajuste.ASIGES = a80.OBS AND ajuste.BLine=1
  WHERE a900.COD_CIA=1
    AND a900.COD_AGT=p_COD_AGT
 ORDER BY a900.FEC_SINI DESC;
END PURDYREPSINIESTROS;

PROCEDURE MAPFREREPSINIESTROS (p_COD_AGT NUMBER, p_refcur IN OUT SYS_REFCURSOR) IS
BEGIN
  OPEN p_refcur FOR
SELECT DISTINCT a900.NUM_SINI, a700.NUM_EXP, NULL COD_CTO_RVA, NULL ANIO_MES, a900.COD_CIA,
       a900.COD_NIVEL1_CAPTURA, a900.COD_NIVEL2_CAPTURA, a900.COD_NIVEL3_CAPTURA,
       a900.COD_NIVEL1, a900.COD_NIVEL2, a900.COD_NIVEL3,
       a900.TIP_DOCUM_TOMADOR, a900.COD_DOCUM_TOMADOR, A1399T.NOM_TERCERO || ' ' || A1399T.APE1_TERCERO NOMBRE_TOMADOR,
       a900.COD_AGT, a900.COD_SECTOR, NULL COD_SUBSECTOR, NULL COD_RAMO_CONTABLE,
       a900.COD_RAMO, a900.COD_MODALIDAD, a900.NUM_POLIZA, a900.FEC_SINI, a700.TIP_EST_EXP,
       a900.COD_MON, a700.TIP_EXP, NULL TIP_EXP_RECOBRO, a700.TIP_EXP_AFEC, a700.NUM_EXP_AFEC,
       a700.FEC_APER_EXP, a700.FEC_TERM_EXP, a700.PCT_COA, NULL ESTIMACION, NULL MAS, NULL MENOS,
       NULL PAGOS, NULL PAGOS_COA, NULL RESERVA_ACT, NULL RESERVA_ANT, NULL RESERVA_PEND_LIQ,
       NULL TIP_RESERVA, NULL COD_TRAMITADOR, NULL FEC_REAP_EXP, NULL FEC_ACTU, NULL MCA_JUICIO,
       NULL TIP_EST_JUICIO, NULL FEC_DENU_SINI, NULL NUM_SPTO, NULL NUM_APLI,
       NULL NUM_SPTO_APLI, NULL NUM_RIESGO, NULL NUM_SPTO_RIESGO,
       NULL COD_COB, NULL NOM_COB, a900.COD_CAUSA_SINI, G200.NOM_CAUSA, NULL POLIZA_SPTO, NULL TC_1,
       NULL PAGOS_COLONIZADOS, NULL RESERVA_COLONIZADA, NULL POLIZA_SPTO_RIESGO, NULL POLIZA_RIESGO,
       NULL ANIO_SUBMODELO, NULL COD_AGT_PRINCIPAL, A2020C.TXT_CAMPO COD_TIP_VEHI, A2020.TXT_CAMPO COD_USO_VEHI,
       NULL FEC_INICIAL_RIESGO_ANULIDAD, NULL FEC_VCTO_RIESGO, NULL NOM_AGT_PRINCIPAL,
       A2020M.TXT_CAMPO NOM_MARCA, A2020I.TXT_CAMPO NOM_MODELO, a900.NUM_POLIZA_GRUPO, NULL TIP_AGT_PRINCIPAL, a30.TIP_SPTO
  FROM a7000900 a900
  LEFT JOIN A7001000 a700 on a700.NUM_SINI=a900.NUM_SINI
  LEFT JOIN A1001399 A1399T ON A1399T.COD_CIA=a900.COD_CIA AND A1399T.TIP_DOCUM = a900.TIP_DOCUM_TOMADOR AND A1399T.COD_DOCUM = a900.COD_DOCUM_TOMADOR
  LEFT JOIN G7000200 G200 ON G200.COD_CIA = G200.COD_CIA AND G200.TIP_CAUSA = 1 AND G200.COD_CAUSA = a900.COD_CAUSA_SINI
  LEFT JOIN A2000020 A2020 ON A2020.COD_CIA=a900.COD_CIA AND A2020.NUM_POLIZA=a900.NUM_POLIZA AND A2020.NUM_SPTO=0 AND A2020.NUM_APLI=0 AND A2020.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020.NUM_RIESGO=a900.NUM_RIESGO AND A2020.COD_CAMPO='COD_USO_VEHI'
  LEFT JOIN A2000020 A2020C ON A2020C.COD_CIA=a900.COD_CIA AND A2020C.NUM_POLIZA=a900.NUM_POLIZA AND A2020C.NUM_SPTO=0 AND A2020C.NUM_APLI=0 AND A2020C.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020C.NUM_RIESGO=a900.NUM_RIESGO AND A2020C.COD_CAMPO='COD_TIP_VEHI'
  LEFT JOIN A2000020 A2020M ON A2020M.COD_CIA=a900.COD_CIA AND A2020M.NUM_POLIZA=a900.NUM_POLIZA AND A2020M.NUM_SPTO=0 AND A2020M.NUM_APLI=0 AND A2020M.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020M.NUM_RIESGO=a900.NUM_RIESGO AND A2020M.COD_CAMPO='COD_MARCA'
  LEFT JOIN A2000020 A2020I ON A2020I.COD_CIA=a900.COD_CIA AND A2020I.NUM_POLIZA=a900.NUM_POLIZA AND A2020I.NUM_SPTO=0 AND A2020I.NUM_APLI=0 AND A2020I.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020I.NUM_RIESGO=a900.NUM_RIESGO AND A2020I.COD_CAMPO='COD_MODELO'
  LEFT JOIN A2000030 a30  ON a30.COD_CIA=1 AND a30.NUM_POLIZA=a900.NUM_POLIZA AND a30.NUM_SPTO = a900.NUM_SPTO  AND a30.NUM_APLI = NVL(a900.NUM_APLI, 0) AND a30.NUM_SPTO_APLI = NVL(a900.NUM_SPTO_APLI, 0)
  ORDER BY a900.NUM_SINI, a700.NUM_EXP;
END MAPFREREPSINIESTROS;

END EM_K_MAPFRE_ALIADOS;
