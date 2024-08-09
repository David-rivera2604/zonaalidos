UPDATE ALIADOS.LOOKUPMASTER SET "STATEMENT"='SELECT distinct G29.NUM_CONTRATO,  G2917.NOM_POLIZA || '' '' || G299.NOM_CONTRATO ||'' '' || G29.NUM_CONTRATO NOM_POLIZA, A20.NUM_POLIZA, to_char(a20.fec_vcto_poliza,''dd/mm/yyyy'') fec_vcto_poliza
        FROM   G2990000 G29, A2000010 A20, G2990017 G2917, g2990001 G299
        WHERE  G29.COD_CIA = 1
        AND    G29.COD_RAMO = {cod_ramo}
        AND    G29.COD_AGT IN ({app.p_cod_agt}, {cod_agt})
        AND    A20.NUM_POLIZA LIKE ''303%''
        AND    G29.NUM_CONTRATO NOT IN
               (SELECT num_contrato
                 FROM   ta301004 a
                 WHERE  COD_CIA = 1
                 AND    COD_RAMO = {cod_ramo}
                 AND    COD_AGT IN ({app.p_cod_agt}, {cod_agt})
                 AND    MCA_INH = ''N''
                 AND    COD_SUB_AGT in (99999,{app.p_cod_sub_agt})
                 AND A.NUM_POLIZA_GRUPO = A20.NUM_POLIZA)
         AND    A20.COD_CIA = G29.COD_CIA
        AND    A20.NUM_CONTRATO = G29.NUM_CONTRATO
        AND    G299.COD_CIA = G29.COD_CIA
        AND    G299.NUM_CONTRATO =  g29.NUM_CONTRATO
        AND    G2917.COD_CIA = A20.COD_CIA
        AND    G2917.NUM_POLIZA =  A20.NUM_POLIZA
        ORDER  BY NUM_CONTRATO ASC' WHERE LOOKUPID=3075;