UPDATE LOOKUPMASTER SET DESCRIPTION='Mapfre MAS. Plan', "KEY"='MM_Plan', TENANT=2, RECORDSTATUS=1, UPDATEUSERCODE=1, UPDATEDATE=TIMESTAMP '2021-09-28 08:09:12.000000', "STATEMENT"='SELECT a.cod_plan, a.nom_plan 
FROM ta301000 a
WHERE a.cod_cia = {app.p_cod_cia}
  AND a.num_poliza_grupo = ''9999999999999''    
  AND a.num_contrato = 99999
  AND a.num_subcontrato  = 99999
  AND a.cod_marca  = 999
  AND a.cod_modelo  = 999
  AND a.cod_sub_modelo = 999
  AND a.anio = 9999
  AND a.cod_tip_vehi = 999
  AND a.cod_uso_vehi = 999
  AND a.mca_sexo = 9      
  AND a.cod_zona_circul = 9999
  AND {edad} BETWEEN a.edad_desde AND a.edad_hasta
  AND a.cod_ramo = {cod_ramo}
  AND a.cod_mon  = {cod_mon}
  AND a.mca_inh = ''N''
  AND ((not ''purdy'' in ({app.UserRoleNameList})
  AND  (({plan:varchar} = ''basico'' AND a.cod_plan BETWEEN 31 AND 31)
   OR   ({plan:varchar} = ''amplio'' AND a.cod_plan BETWEEN 32 AND 32)
   OR   ({plan:varchar} = ''plus'' AND a.cod_plan BETWEEN 33 AND 33)
   OR   ({plan:varchar} = ''oro'' AND a.cod_plan BETWEEN 34 AND 34)
   OR   ({plan:varchar} = ''plata'' AND a.cod_plan BETWEEN 35 AND 35)
   OR   ({plan:varchar} = ''trebol'' AND a.cod_plan BETWEEN 36 AND 36)
   OR   ({plan:varchar} = ''trebolrc'' AND a.cod_plan BETWEEN 37 AND 37))
  OR   (''purdy'' in ({app.UserRoleNameList}) AND {plan:varchar} = ''basico'' AND a.cod_plan BETWEEN 38 AND 38)))
ORDER BY a.cod_cia, a.num_poliza_grupo, a.num_contrato, a.num_subcontrato, a.cod_marca, a.cod_modelo, a.cod_sub_modelo,
        a.anio, a.cod_tip_vehi, a.cod_uso_vehi, a.mca_sexo, a.cod_zona_circul, a.edad_desde, a.edad_hasta, a.cod_ramo, a.cod_mon, a.cod_plan, a.fec_validez DESC', CONNECTIONNAME='tron', "TYPE"=2, INCLUDEBYROLE=NULL, EXCLUDEBYROLE=NULL, ISCACHED=1, STATEMENTTYPE=1, FIELDS=NULL WHERE LOOKUPID=3032;
