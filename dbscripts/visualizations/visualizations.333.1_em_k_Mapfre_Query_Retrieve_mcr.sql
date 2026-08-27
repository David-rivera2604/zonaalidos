CREATE OR REPLACE PACKAGE TRON2000.em_k_Mapfre_Query_Retrieve_mcr AS
    TYPE RT1 IS RECORD (cod_cia                        a2000030.cod_cia                   %TYPE,             
                        num_poliza                     a2000030.num_poliza                %TYPE,
                        num_riesgo                     a2000031.num_riesgo                %TYPE,      
                        num_poliza_anterior            a2000030.num_poliza_anterior       %TYPE,
                        num_poliza_cliente             a2000030.num_poliza_cliente        %TYPE,
                        num_poliza_grupo               a2000030.num_poliza_grupo          %TYPE,
                        num_contrato                   a2000030.num_contrato              %TYPE,
                        num_subcontrato                a2000030.num_subcontrato           %TYPE,
                        fec_efec_poliza                a2000030.fec_efec_poliza           %TYPE,
                        fec_vcto_poliza                a2000030.fec_vcto_poliza           %TYPE,
                        num_presupuesto                a2000030.num_presupuesto           %TYPE,
                        nom_certificado                a2000031.nom_certificado           %TYPE,
                        tip_docum                      a2000030.tip_docum                 %TYPE,
                        cod_docum                      a2000030.cod_docum                 %TYPE,
                        num_spto                       a2000030.num_spto                  %TYPE,
                        num_apli                       a2000030.num_apli                  %TYPE,
                        num_spto_apli                  a2000030.num_spto_apli             %TYPE,
                        cod_ramo                       a2000030.cod_ramo                  %TYPE,
                        cod_agt                        a2000030.cod_agt                   %TYPE,
                        NOM_COMPLETO                   v1001390.NOM_COMPLETO              %TYPE,       
                        abr_ramo                       a1001800.abr_ramo                  %TYPE,
                        nom_riesgo                     a2000031.nom_riesgo                %TYPE);
    TYPE RCTpolicy_by_agent IS REF CURSOR RETURN RT1;
--
    TYPE RTpending_receipts IS RECORD (cod_cia         a2000030.cod_cia                   %TYPE,             
                        num_poliza                     a2000030.num_poliza                %TYPE,
                        num_poliza_anterior            a2000030.num_poliza_anterior       %TYPE,
                        num_poliza_cliente             a2000030.num_poliza_cliente        %TYPE,
                        num_poliza_grupo               a2000030.num_poliza_grupo          %TYPE,
                        num_contrato                   a2000030.num_contrato              %TYPE,
                        num_subcontrato                a2000030.num_subcontrato           %TYPE,
                        fec_efec_poliza                a2000030.fec_efec_poliza           %TYPE,
                        fec_vcto_poliza                a2000030.fec_vcto_poliza           %TYPE,
                        num_presupuesto                a2000030.num_presupuesto           %TYPE,
                        tip_docum                      a2000030.tip_docum                 %TYPE,
                        cod_docum                      a2000030.cod_docum                 %TYPE,
                        num_spto                       a2000030.num_spto                  %TYPE,
                        num_apli                       a2000030.num_apli                  %TYPE,
                        num_spto_apli                  a2000030.num_spto_apli             %TYPE,
                        cod_ramo                       a2000030.cod_ramo                  %TYPE,
                        cod_agt                        a2000030.cod_agt                   %TYPE,
                        NOM_COMPLETO                   v1001390.NOM_COMPLETO              %TYPE,       
                        imp_recibo                     a2990700.imp_recibo                %TYPE,
                        imp_comis                      a2990700.imp_comis                 %TYPE,
                        tip_gestor                     a2990700.tip_gestor                %TYPE,
                        fec_vcto_recibo                a2990700.fec_vcto_recibo           %TYPE,
                        tip_situacion                  a2990700.tip_situacion             %TYPE,
                        num_recibo                     a2990700.num_recibo                %TYPE,
                        fec_valor                      a2990700.fec_valor                 %TYPE,
                        key                            VARCHAR2(50),
                        NOM_COMPLETO2                  v1001390.NOM_COMPLETO              %TYPE,
                        fec_efec_recibo2               a2990700.fec_efec_recibo           %TYPE,
                        fec_vcto_recibo2               a2990700.fec_vcto_recibo           %TYPE,
                        tip_situacion_desc             VARCHAR2(50),
                        tip_gestor_desc                VARCHAR2(50),
                        tlf_numero                     a1001331.tlf_numero                %TYPE,
                        tlf_numero_com                 a1001331.tlf_numero_com            %TYPE,
                        fax_numero                     a1001331.fax_numero                %TYPE,
                        fax_numero_com                 a1001331.fax_numero_com            %TYPE,
                        email                          a1001331.email                     %TYPE,
                        nom_domicilio1                 a1001331.nom_domicilio1            %TYPE,
                        nom_domicilio2                 a1001331.nom_domicilio2            %TYPE,
                        nom_domicilio3                 a1001331.nom_domicilio3            %TYPE,
                        nom_mon                        a1000400.nom_mon                   %TYPE,
                        tip_gestor_recibo              a2990700.tip_gestor                %TYPE,
                        nom_fracc_pago                 a1001402.nom_fracc_pago            %TYPE
                        );
    TYPE RCTpending_receipts IS REF CURSOR RETURN RTpending_receipts;  
--
    TYPE RTp_claims IS RECORD (cod_cia                 a2000030.cod_cia                   %TYPE,             
                               num_poliza              a2000030.num_poliza                %TYPE,
                               nom_riesgo              a2000031.nom_riesgo                %TYPE,                               
                               num_riesgo              a2000031.num_riesgo                %TYPE,                        
	                             fec_sini                a7000900.fec_sini                  %TYPE,                               
                               num_sini                a7000900.num_sini                  %TYPE,                               
                               fec_term_sini           a7000900.fec_term_sini             %TYPE,
                               imp_val_inicial         a7001000.imp_val_inicial           %TYPE,
                               imp_val                 a7001000.imp_val                   %TYPE,
                               imp_liq                 a7001000.imp_liq                   %TYPE,
                               imp_pag                 a7001000.imp_pag                   %TYPE,
                               tip_docum               v1001390.tip_docum              %TYPE,
                               cod_docum               v1001390.cod_docum              %TYPE,
                               NOM_COMPLETO            v1001390.NOM_COMPLETO              %TYPE);
    TYPE RCTp_claims IS REF CURSOR RETURN RTp_claims;  
--
    TYPE RTpending_commission IS RECORD (cod_cia                        a5020058.cod_cia            %TYPE,
                                         cod_agt                        a5020058.cod_agt      %TYPE,             
                                         tip_docum_agt                  a5020058.tip_docum_agt      %TYPE,
                                         cod_docum_agt                  a5020058.cod_docum_agt      %TYPE,
                                         cod_mon                        a5020058.cod_mon            %TYPE,
                                         nom_mon                        a1000400.nom_mon            %TYPE,       
                                         imp_recibo                     a5020058.imp_recibo         %TYPE,
                                         imp_mvto                       a5020058.imp_mvto           %TYPE,
                                         key                            VARCHAR2(50));
                        
    TYPE RCTpending_commission IS REF CURSOR RETURN RTpending_commission;  
--  
    TYPE RTpending_commissionDet IS RECORD (cod_cia                      a5020058.cod_cia                   %TYPE,
                                           cod_agt                       a5020058.cod_agt                   %TYPE,
                                           num_poliza                    a5020058.num_poliza                %TYPE,
                                           cod_nivel3                    a5020058.cod_nivel3                %TYPE,
                                           cod_ramo                      a5020058.cod_ramo                  %TYPE,
                                           abr_ramo                      a1001800.abr_ramo                  %TYPE,
                                           num_recibo                    a5020058.num_recibo                %TYPE,
                                           tip_situacion                 a5020058.tip_situacion             %TYPE,
                                           fec_mvto                      a5020058.fec_mvto                  %TYPE,
                                           nom_completo                  A7005040.nom_completo              %TYPE,
                                           imp_recibo                    a5020058.imp_recibo                %TYPE,
                                           imp_mvto                      a5020058.imp_mvto                  %TYPE);
                                      
    TYPE RCTpending_commissionDet IS REF CURSOR RETURN RTpending_commissionDet;      
-- 
    TYPE RTpaid_commission IS RECORD (cod_cia                       a5020059.cod_cia                   %TYPE,
                                      cod_agt                       a5020059.cod_agt                   %TYPE,
                                      fec_proceso                   a5020059.fec_proceso               %TYPE,                                      
                                      cod_mon                       a5020059.cod_mon                   %TYPE,
                                      nom_mon                       a1000400.nom_mon                   %TYPE,
                                      imp_comis                     a5020059.imp_comis                %TYPE,
                                      imp_deduc                     a5020059.imp_imptos                %TYPE,
                                      imp_pagado                    a5020059.imp_pagado                %TYPE,
                                      key                           VARCHAR(10));
                                      
    TYPE RCTpaid_commission IS REF CURSOR RETURN RTpaid_commission;  
--  
    TYPE RTpaid_commissionDet IS RECORD (cod_cia                       a5020054.cod_cia                   %TYPE,
                                         cod_agt                       a5020054.cod_agt                   %TYPE,
                                         num_poliza                    a5020054.num_poliza                   %TYPE,
                                         cod_nivel3_agt                a5020054.cod_nivel3_agt                   %TYPE,
                                         cod_ramo                      a5020054.cod_ramo                   %TYPE,
                                         abr_ramo                      a1001800.abr_ramo                   %TYPE,
                                         num_recibo                    a5020054.num_recibo                   %TYPE,
                                         tip_situacion                 a5020054.tip_situacion                   %TYPE,
                                         fec_mvto                      a5020054.fec_mvto                   %TYPE,
                                         nom_completo                  A7005040.nom_completo                   %TYPE,
                                         imp_recibo                    a5020054.imp_recibo                   %TYPE,
                                         imp_mvto                      a5020054.imp_mvto                   %TYPE);
                                      
    TYPE RCTpaid_commissionDet IS REF CURSOR RETURN RTpaid_commissionDet;  
--   
    TYPE RTpaid_commissionDetDeduc IS RECORD (cod_cia                      a5020054.cod_cia                   %TYPE,
                                              cod_agt                      a5020054.cod_agt                   %TYPE,
                                              tip_docum_agt                a5020054.tip_docum_agt             %TYPE,
                                              cod_docum_agt                a5020054.cod_docum_agt             %TYPE,
                                              cod_mon                      a5020054.cod_mon                   %TYPE,
                                              fec_mvto                     a5020054.fec_mvto                  %TYPE,
                                              imp_mvto                     a5020054.imp_mvto                  %TYPE,
                                              fec_proceso                  a5020054.fec_proceso               %TYPE,
                                              tip_anticipo                 a5020054.tip_anticipo              %TYPE,
                                              nom_anticipo                 VARCHAR2(100)                           ,
                                              cod_mvto                     a5020054.cod_mvto                  %TYPE);
                                          
    TYPE RCTpaid_commissionDetDeduc IS REF CURSOR RETURN RTpaid_commissionDetDeduc;  
-- 
    TYPE RT1polies_canceled IS RECORD (cod_cia                        a2000030.cod_cia                   %TYPE,             
                                       num_poliza                     a2000030.num_poliza                %TYPE,
	                                     fec_efec_spto                  a2000030.fec_efec_poliza           %TYPE,
                                       tip_docum                      v1001390.tip_docum                 %TYPE,
                                       cod_docum                      v1001390.cod_docum                 %TYPE,
                                       APE1_TERCERO                   v1001390.APE1_TERCERO              %TYPE,       
                                       abr_ramo                       a1001800.abr_ramo                  %TYPE);
    TYPE RCTpolies_canceled IS REF CURSOR RETURN  RT1polies_canceled;
--
    TYPE RTPREMIUMCOLLECTION IS RECORD (cod_cia                         a2000030.cod_cia          %TYPE,
                                        num_poliza                      a5020301.num_poliza       %TYPE,
                                        fec_efec_poliza                 a2000030.fec_efec_poliza  %TYPE,
                                        fec_vcto_poliza                 a2000030.fec_vcto_poliza  %TYPE,
                                        tip_gestor                      a2000030.tip_gestor       %TYPE,
                                        cod_mon                         a5020301.cod_mon          %TYPE,
                                        nom_mon                         a1000400.nom_mon          %TYPE,
                                        cod_mon_iso                     a1000400.cod_mon_iso      %TYPE,
                                        cod_ramo                        a2000030.cod_ramo         %TYPE,
                                        nom_ramo                        a1001800.nom_ramo         %TYPE,
                                        abr_ramo                        a1001800.abr_ramo         %TYPE,
                                        nom_tercero                     a1001399.nom_tercero      %TYPE,
                                        ape1_tercero                    a1001399.ape1_tercero     %TYPE,
                                        ape2_tercero                    a1001399.ape2_tercero     %TYPE,
                                        nom_completo                    v1001390.nom_completo     %TYPE,
                                        num_recibo                      a5020301.num_recibo       %TYPE,
                                        fec_efec_recibo                 a5020301.fec_efec_recibo  %TYPE,
                                        fec_vcto_recibo                 a5020301.fec_vcto_recibo  %TYPE,
                                        tip_situacion                   a5020301.tip_situacion    %TYPE,
                                        fec_situacion                   a5020301.fec_situacion    %TYPE,
                                        cod_usr                         a5020301.cod_usr          %TYPE,
                                        fec_actu                        a5020301.fec_actu         %TYPE,
                                        num_bloque_tes                  a5020301.num_bloque_tes   %TYPE,
                                        tip_cobro                       a5020301.tip_cobro        %TYPE,
                                        nom_tip_cobro                   g1010031.nom_valor        %TYPE,
                                        cod_agt                         a5020301.cod_agt          %TYPE,
                                        nom_agente                      v1001390.nom_completo     %TYPE,
                                        val_cambio                      a5020301.val_cambio       %TYPE,                          
                                        imp_recibo                      a5020301.imp_recibo       %TYPE,
                                        imp_neta                        a5020301.imp_neta         %TYPE,
                                        imp_recargo                     a5020301.imp_recargo      %TYPE,
                                        imp_imptos		                  a5020301.imp_imptos		    %TYPE,
                                        imp_interes 		                a5020301.imp_interes 		  %TYPE);
    TYPE RCTPREMIUMCOLLECTION IS REF CURSOR RETURN RTPREMIUMCOLLECTION;
--    
TYPE RTp_claims_by_policy IS RECORD (cod_cia                 a2000030.cod_cia                   %TYPE,             
                               num_poliza              a2000030.num_poliza                %TYPE,
                               nom_riesgo              a2000031.nom_riesgo                %TYPE,                               
                               num_riesgo              a2000031.num_riesgo                %TYPE,                        
	                             fec_sini                a7000900.fec_sini                  %TYPE,                               
                               num_sini                a7000900.num_sini                  %TYPE,                               
                               fec_term_sini           a7000900.fec_term_sini             %TYPE,
                               imp_val_inicial         a7001000.imp_val_inicial           %TYPE,
                               imp_val                 a7001000.imp_val                   %TYPE,
                               imp_liq                 a7001000.imp_liq                   %TYPE,
                               imp_pag                 a7001000.imp_pag                   %TYPE,
                               num_exp                 a7001000.num_exp                   %TYPE/*,
                               NOM_COMPLETO            v1001390.NOM_COMPLETO              %TYPE*/);
    TYPE RCTp_claims_by_policy IS REF CURSOR RETURN RTp_claims_by_policy;  
--
TYPE RTp_group_polcy_by_document IS RECORD(num_poliza_grupo a2000030.num_poliza_grupo %TYPE);
TYPE RCTp_group_polcy_by_document IS REF CURSOR RETURN RTp_group_polcy_by_document;
--
TYPE RTpinfoextra IS RECORD (email    a1001300.email %TYPE);
TYPE RCTpinfoextra IS REF CURSOR RETURN RTpinfoextra;
--
END;