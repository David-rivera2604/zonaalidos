using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Protege los controles del formulario para cada actor del ciclo de solicitud.
    /// </summary>
    [TestClass]
    public class EmitirPolizaWorkflowUiSourceTests
    {
        /// <summary>
        /// Exige que el formulario cargue la solicitud autorizada y use modos explícitos para guardar, enviar y confirmar.
        /// </summary>
        [TestMethod]
        public void Formulario_UsaSolicitudDeInvitacionYModosDelCiclo()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            StringAssert.Contains(source, "v1/InsuredCompletion/proposal");
            StringAssert.Contains(source, "isInsuredCompletionDestination()");
            StringAssert.Contains(source, "'Draft'");
            StringAssert.Contains(source, "'SendSignature'");
            StringAssert.Contains(source, "'Complete'");
            StringAssert.Contains(source, "#btnSaveDraft");
            StringAssert.Contains(source, "#btnComplete");
        }

        /// <summary>
        /// Impide que una solicitud nueva muestre controles para administrar una invitación que todavía no existe.
        /// </summary>
        [TestMethod]
        public void Formulario_EnModoAgente_OcultaAccionesDeSeguimientoHastaCargarSolicitud()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            StringAssert.Contains(source, "setAgentProposalActionVisibility('btnResendLink', false);");
            StringAssert.Contains(source, "setAgentProposalActionVisibility('btnRevokeLink', false);");
            StringAssert.Contains(source, "setAgentProposalActionVisibility('btnResumeEditing', false);");
        }

        /// <summary>
        /// Impide que el motor de visibilidad del ramo vuelva a exponer controles de una invitación inexistente.
        /// </summary>
        [TestMethod]
        public void Formulario_AlCambiarRamo_RestableceAccionesDeSolicitudNueva()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));
            int ramoChangeStart = source.IndexOf("$('#RAMO').on('change'", StringComparison.Ordinal);
            int ramoChangeEnd = source.IndexOf("$('#EFEC_SPTO').blur", ramoChangeStart, StringComparison.Ordinal);
            string ramoChange = source.Substring(ramoChangeStart, ramoChangeEnd - ramoChangeStart);

            StringAssert.Contains(ramoChange, "configureWorkflowButtons(false);");
        }

        /// <summary>
        /// Impide que una marca residual de invitación en la pestaña bloquee un formulario abierto por un agente.
        /// </summary>
        [TestMethod]
        public void Formulario_NormalNoInterpretaUnaMarcaResidualComoInvitacion()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));
            int functionStart = source.IndexOf("function isInsuredCompletion()", StringComparison.Ordinal);
            int functionEnd = source.IndexOf("function configureWorkflowButtons", functionStart, StringComparison.Ordinal);
            string functionSource = source.Substring(functionStart, functionEnd - functionStart);

            StringAssert.Contains(functionSource, "isInsuredCompletionDestination()");
            Assert.IsFalse(functionSource.Contains("!!sessionStorage.getItem('InsuredCompletionPath')"),
                "La sola existencia de la marca de sesión no puede convertir un formulario normal en una invitación.");
        }

        /// <summary>
        /// Exige que la infraestructura común resuelva los catálogos simulados solo en localhost y que el contrato local conserve sus datos comerciales.
        /// </summary>
        [TestMethod]
        public void Formulario_UsaCatalogosSimuladosSoloEnLocalhost()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string coreSource = File.ReadAllText(Path.Combine(root, "WebApp", "app", "js", "core.js"));
            string formSource = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));
            string simulationScript = File.ReadAllText(Path.Combine(root, "dbscripts", "20261019a.lookup.local-policy-proposal-simulation.sql"));

            StringAssert.Contains(coreSource, "localStorage.getItem('Lookup.LocalSimulation') === 'true'");
            StringAssert.Contains(coreSource, "window.location.hostname.toLowerCase() === 'localhost'");
            StringAssert.Contains(coreSource, "return `s_${masterKey}${suffix}`;");
            StringAssert.Contains(coreSource, "onlyKeys.push(resolveLookupKey");
            StringAssert.Contains(coreSource, "lookupKey = resolveLookupKey(lookupKey);");
            StringAssert.Contains(coreSource, "values.Key = cacheKeys[index];");
            StringAssert.Contains(formSource, "app.core.Lookups(['Contratos_v2.NUM_CONTRATO']");
            Assert.IsFalse(formSource.Contains("loadLocalSimulationContract"),
                "El formulario no debe duplicar la carga del contrato que resuelve core.js.");
            StringAssert.Contains(simulationScript, "'s_Contratos_v2'");
            StringAssert.Contains(simulationScript, "'99340'' AS CODE");
            StringAssert.Contains(simulationScript, "'1170000000008'' AS NUM_POLIZA");
            StringAssert.Contains(simulationScript, "'COLONES'' AS NOM_MON");
            Assert.IsFalse(simulationScript.Contains("SET DEFINE", StringComparison.OrdinalIgnoreCase),
                "El script debe poder ejecutarse desde clientes JDBC y no incluir comandos exclusivos de SQL*Plus.");
            Assert.IsFalse(simulationScript.Contains("COLOR1TENANT", StringComparison.OrdinalIgnoreCase),
                "El script debe ser compatible con la estructura base de LOOKUP, que no contiene columnas de color.");
        }

        /// <summary>
        /// Verifica que la página active temporalmente la marca de simulación para facilitar las pruebas locales integradas.
        /// La infraestructura común conserva la restricción de aplicar catálogos simulados únicamente en localhost.
        /// </summary>
        [TestMethod]
        public void Formulario_HabilitaTemporalmenteLaSimulacionLocal()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            StringAssert.Contains(source, "localStorage.setItem('Lookup.LocalSimulation', 'true');");
        }

        /// <summary>
        /// Impide enviar una invitación desde la interfaz si aún faltan datos que el asegurado no podrá cambiar.
        /// </summary>
        [TestMethod]
        public void Formulario_EnviarEnlaceValidaDatosBloqueadosDelAgente()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));
            int sendLinkStart = source.IndexOf("$('#btnSendLink').click", StringComparison.Ordinal);
            int sendLinkEnd = source.IndexOf("$('#btnSaveDraft').click", sendLinkStart, StringComparison.Ordinal);
            string sendLinkSource = source.Substring(sendLinkStart, sendLinkEnd - sendLinkStart);

            StringAssert.Contains(source, "function validateInvitationAgentFields(spec)");
            StringAssert.Contains(source, "'ramo'");
            StringAssert.Contains(source, "'contrato'");
            StringAssert.Contains(source, "'inicio de vigencia'");
            StringAssert.Contains(source, "'fin de vigencia'");
            StringAssert.Contains(source, "case 117:");
            StringAssert.Contains(source, "case 194:");
            StringAssert.Contains(source, "case 401:");
            StringAssert.Contains(sendLinkSource, "validateInvitationAgentFields(spec)");
            Assert.IsTrue(sendLinkSource.IndexOf("validateInvitationAgentFields(spec)", StringComparison.Ordinal) <
                          sendLinkSource.IndexOf("postWorkflowAction", StringComparison.Ordinal),
                "La validación de datos bloqueados debe ocurrir antes de enviar la solicitud al API.");

            string uiSource = File.ReadAllText(Path.Combine(root, "WebApp", "app", "js", "core.ui.js"));
            StringAssert.Contains(uiSource, "ShowValidationErrors: function (formId, errors)");
            StringAssert.Contains(source, "app.ui.ShowValidationErrors('#EmitirPolizaEdtForm', pending);");
        }

        /// <summary>
        /// Evita mostrar como corregible una prima que la modalidad calcula y deshabilita en Vida Colectivo.
        /// </summary>
        [TestMethod]
        public void Formulario_EnviarEnlaceSincronizaPrimaCalculadaCuandoEstaDeshabilitada()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            StringAssert.Contains(source, "function synchronizeInvitationCalculatedValues(entry)");
            StringAssert.Contains(source, "$('#IMP_PRIMA_INFORMADA').is(':disabled')");
            StringAssert.Contains(source, "entry.IMP_PRIMA_INFORMADA = entry.IMP_SUM_ASEG_VC;");
            StringAssert.Contains(source, "synchronizeInvitationCalculatedValues(entry);");
        }

        /// <summary>
        /// Exige bloquear en el navegador los campos exclusivos del agente cuando el formulario se abre mediante invitación.
        /// </summary>
        [TestMethod]
        public void Formulario_DeInvitacionBloqueaDatosGeneralesYRiesgoDelAgente()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            StringAssert.Contains(source, "function lockInsuredAgentFields()");
            StringAssert.Contains(source, "#RAMO");
            StringAssert.Contains(source, "#NUM_CONTRATO");
            StringAssert.Contains(source, "#EFEC_SPTO");
            StringAssert.Contains(source, "#VCTO_SPTO");
            StringAssert.Contains(source, "#IMP_SUM_ASEG_VC");
            StringAssert.Contains(source, "#IMP_PRIMA_INFORMADA");
            StringAssert.Contains(source, "input[name='MCA_ASISTENCIA']");
            StringAssert.Contains(source, ".prop('disabled', true)");
            StringAssert.Contains(source, "proposal.NUM_CONTRATO");
            StringAssert.Contains(source, "app.EmitirPoliza.SetData(proposal);");

            int load = source.IndexOf("app.EmitirPoliza.SetData(proposal)", StringComparison.Ordinal);
            int lockIndex = source.IndexOf("lockInsuredAgentFields();", load, StringComparison.Ordinal);
            Assert.IsTrue(load >= 0 && lockIndex > load,
                "Los controles del agente deben bloquearse después de cargar la propuesta de la invitación.");
        }

        /// <summary>
        /// Exige mostrar el contrato persistido sin consultar la lista filtrada por el agente autenticado.
        /// </summary>
        [TestMethod]
        public void Formulario_DeInvitacionUsaDescripcionPersistidaDeContrato()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));
            int loadStart = source.IndexOf("function loadInsuredProposal()", StringComparison.Ordinal);
            int loadEnd = source.IndexOf("function createWorkflowEntry", loadStart, StringComparison.Ordinal);
            string loadSource = source.Substring(loadStart, loadEnd - loadStart);

            StringAssert.Contains(source, "function setStoredContractOption(proposal)");
            StringAssert.Contains(source, "proposal.NUM_CONTRATODesc");
            StringAssert.Contains(source, "new Option");
            StringAssert.Contains(loadSource, "setStoredContractOption(proposal);");
            Assert.IsFalse(loadSource.Contains("$('#RAMO').change()"),
                "La sesión del asegurado no debe consultar contratos filtrados por el agente.");

            int ramoChangeStart = source.IndexOf("$('#RAMO').on('change'", StringComparison.Ordinal);
            int lookupStart = source.IndexOf("app.core.Lookups(['Contratos_v2.NUM_CONTRATO']", ramoChangeStart, StringComparison.Ordinal);
            int insuredGuard = source.IndexOf("if (isInsuredCompletion())", ramoChangeStart, StringComparison.Ordinal);
            Assert.IsTrue(ramoChangeStart >= 0 && insuredGuard > ramoChangeStart && lookupStart > insuredGuard,
                "El cambio de ramo debe salir antes de consultar contratos cuando la sesión pertenece al asegurado.");

            int policyGroupHelperStart = source.IndexOf("function update_info_poliza_grupo()", StringComparison.Ordinal);
            int policyGroupHelperEnd = source.IndexOf("function beneficiarios_table_OtherValidations", policyGroupHelperStart, StringComparison.Ordinal);
            string policyGroupHelper = source.Substring(policyGroupHelperStart, policyGroupHelperEnd - policyGroupHelperStart);
            StringAssert.Contains(policyGroupHelper, "if (isInsuredCompletion())");

            int contractValidationStart = source.IndexOf("$.validator.addMethod(\"ContratoVencido\"", StringComparison.Ordinal);
            int contractValidationEnd = source.IndexOf("$(`#${formName}EdtForm`).validate()", contractValidationStart, StringComparison.Ordinal);
            string contractValidation = source.Substring(contractValidationStart, contractValidationEnd - contractValidationStart);
            StringAssert.Contains(contractValidation, "if (isInsuredCompletion())");
        }

        /// <summary>
        /// Exige conservar y mostrar la moneda de la instantánea sin volver a obtener datos del contrato del agente.
        /// </summary>
        [TestMethod]
        public void Formulario_DeInvitacionConservaMonedaPersistida()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            StringAssert.Contains(source, "entry.MONEDA = isInsuredCompletion()");
            StringAssert.Contains(source, "_insuredProposal.MONEDA");
            StringAssert.Contains(source, "$('#MONEDA').val(proposal.MONEDA);");
        }

        /// <summary>
        /// Exige que la emisión directa local se desvíe antes de invocar el procedimiento real de emisión.
        /// </summary>
        [TestMethod]
        public void EmisionDirecta_SimuladaNoInvocaServicioDeEmision()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "AltasBajasPoliza.cs"));
            int directIssueStart = source.IndexOf("case AltasBajasOperation.Issue:", StringComparison.Ordinal);
            int directIssueEnd = source.IndexOf("case AltasBajasOperation.Cancel:", directIssueStart, StringComparison.Ordinal);
            string directIssue = source.Substring(directIssueStart, directIssueEnd - directIssueStart);

            StringAssert.Contains(directIssue, "PolicyProposalSimulationSettings.SignatureSimulationEnabled");
            StringAssert.Contains(directIssue, "CreateSimulatedPolicyId");
            Assert.IsTrue(directIssue.IndexOf("PolicyProposalSimulationSettings.SignatureSimulationEnabled", StringComparison.Ordinal) <
                          directIssue.IndexOf("EmitirPropuesta(poliza, true)", StringComparison.Ordinal),
                "La simulación debe decidirse antes de invocar la emisión real.");
        }

        /// <summary>
        /// Exige recuperar tablas y catálogos dependientes que el asignador genérico del formulario no puede restaurar por sí solo.
        /// </summary>
        [TestMethod]
        public void Formulario_DeInvitacionRestauraBeneficiariosYUbicacionPersistidos()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            StringAssert.Contains(source, "function restoreInsuredDependentFields(proposal)");
            StringAssert.Contains(source, "$('#beneficiariosTbl').bootstrapTable('load', proposal.Beneficiarios || []);");
            StringAssert.Contains(source, "app.ui.SetDropDownNumericValue('#OCUPACION_ASEG', proposal.OCUPACION_ASEG, false);");
            StringAssert.Contains(source, "app.core.LookupDependency(proposal.COD_ESTADO, 'COD_PROVINCIA'");
            StringAssert.Contains(source, "app.core.LookupDependency(proposal.COD_PROVINCIA, 'COD_LOCALIDAD'");

            int initialLookupStart = source.IndexOf("app.core.Lookups(options.Lookups", StringComparison.Ordinal);
            int initialLookupEnd = source.IndexOf("}, options.Base);", initialLookupStart, StringComparison.Ordinal);
            string initialLookup = source.Substring(initialLookupStart, initialLookupEnd - initialLookupStart);
            StringAssert.Contains(initialLookup, "if (isInsuredCompletion())");
            StringAssert.Contains(initialLookup, "loadInsuredProposal();");
        }

        /// <summary>
        /// Exige que la ocupación persistida se refleje también cuando el agente recupera una solicitud bloqueada.
        /// </summary>
        [TestMethod]
        public void FormularioAgente_RestauraLaOcupacionPersistidaDespuesDeCargarLaSolicitud()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            StringAssert.Contains(source, "function restoreProposalOccupation(proposal)");
            StringAssert.Contains(source, "app.ui.SetDropDownNumericValue('#OCUPACION_ASEG', proposal.OCUPACION_ASEG, false);");
            StringAssert.Contains(source, "restoreProposalOccupation(proposal);");

            int loadStart = source.IndexOf("function loadAgentProposal()", StringComparison.Ordinal);
            int loadEnd = source.IndexOf("function postAgentProposalCommand", loadStart, StringComparison.Ordinal);
            string loadAgent = source.Substring(loadStart, loadEnd - loadStart);
            StringAssert.Contains(loadAgent, "app.EmitirPoliza.SetData(proposal);");
            StringAssert.Contains(loadAgent, "restoreInsuredDependentFields(proposal);");
        }

        /// <summary>
        /// Exige que el agente vea el contrato almacenado sin depender del catálogo que requiere su sesión dinámica.
        /// </summary>
        [TestMethod]
        public void FormularioAgente_RestauraElContratoPersistidoDespuesDeCargarLaSolicitud()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            int loadStart = source.IndexOf("function loadAgentProposal()", StringComparison.Ordinal);
            int loadEnd = source.IndexOf("function postAgentProposalCommand", loadStart, StringComparison.Ordinal);
            string loadAgent = source.Substring(loadStart, loadEnd - loadStart);
            StringAssert.Contains(loadAgent, "setStoredContractOption(proposal)");
            StringAssert.Contains(source, "function setStoredContractOption(proposal)");
            StringAssert.Contains(source, "const contractNumber = Number(proposal.NUM_CONTRATO);");
            StringAssert.Contains(source, "contractNumber <= 0");
            StringAssert.Contains(source, "!description");
            StringAssert.Contains(loadAgent, "La solicitud almacenada no contiene un contrato válido.");
            Assert.IsFalse(source.Contains("`Contrato ${proposal.NUM_CONTRATO}`"),
                "Una instantánea incompleta no puede mostrarse como el contrato ficticio 'Contrato 0'.");
        }

        /// <summary>
        /// Exige que el agente reconstruya la tabla de beneficiarios desde la instantánea persistida al reabrir un borrador.
        /// </summary>
        [TestMethod]
        public void FormularioAgente_RestauraBeneficiariosPersistidosDespuesDeCargarLaSolicitud()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));
            int loadStart = source.IndexOf("function loadAgentProposal()", StringComparison.Ordinal);
            int loadEnd = source.IndexOf("function postAgentProposalCommand", loadStart, StringComparison.Ordinal);
            string loadAgent = source.Substring(loadStart, loadEnd - loadStart);

            StringAssert.Contains(loadAgent, "restoreInsuredDependentFields(proposal);");
            StringAssert.Contains(source, "$('#beneficiariosTbl').bootstrapTable('load', proposal.Beneficiarios || []);");
        }

        /// <summary>
        /// Exige que el catálogo exclusivo de simulación pueda representar la ocupación persistida en las propuestas de prueba.
        /// </summary>
        [TestMethod]
        public void SimulacionLocal_IncluyeLaOcupacionPersistidaEnLaPropuesta()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string script = File.ReadAllText(Path.Combine(root, "dbscripts", "20261019a.lookup.local-policy-proposal-simulation.sql"));

            StringAssert.Contains(script, "990701001, 6003");
        }

        /// <summary>
        /// Exige que la definición persistida del formulario incluya acciones diferenciadas para el agente y asegurado.
        /// </summary>
        [TestMethod]
        public void Migracion_DeFormularioIncluyeAccionesDelCiclo()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string migrationPath = Path.Combine(root, "dbscripts", "20260824b.visualization.emitirpoliza.workflow.sql");

            Assert.IsTrue(File.Exists(migrationPath), "Debe existir la migración de controles del formulario EmitirPoliza.");
            string source = File.ReadAllText(migrationPath);
            StringAssert.Contains(source, "btnSaveDraft");
            StringAssert.Contains(source, "btnSendLink");
            StringAssert.Contains(source, "btnSendSignature");
            StringAssert.Contains(source, "btnComplete");
        }

        /// <summary>
        /// Exige que el agente pueda recuperar el seguimiento persistido y bloquee la solicitud enviada.
        /// </summary>
        [TestMethod]
        public void InterfazAgente_RecuperaSolicitudPersistidaYNoPermiteEditarPendiente()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));
            string migration = File.ReadAllText(Path.Combine(root, "dbscripts", "20260824b.visualization.emitirpoliza.workflow.sql"));

            StringAssert.Contains(source, "URLNumericValue('proposalId')");
            StringAssert.Contains(source, "v1/PolicyProposals/");
            StringAssert.Contains(source, "lockAgentProposalFields");
            StringAssert.Contains(source, "const editable = view.Status === 1");
            StringAssert.Contains(source, "$('#EmitirPolizaEdtForm fieldset').prop('disabled', !editable);");
            StringAssert.Contains(source, "btnResendLink");
            StringAssert.Contains(source, "btnRevokeLink");
            StringAssert.Contains(source, "btnResumeEditing");
            StringAssert.Contains(source, "showResendInvitationModal");
            StringAssert.Contains(source, "showRevokeInvitationModal");
            Assert.IsFalse(source.Contains("window.prompt"));
            StringAssert.Contains(migration, "proposalWorkflowStatus");
            StringAssert.Contains(migration, "name=btnResendLink|class=btn-on-primary|visible=false");
            StringAssert.Contains(migration, "name=btnRevokeLink|class=btn-on-primary|visible=false");
            StringAssert.Contains(migration, "name=btnResumeEditing|class=btn-on-primary|visible=false");
        }

        /// <summary>
        /// Evita que una actualización tardía del formulario oculte las acciones que el API autorizó al agente.
        /// </summary>
        [TestMethod]
        public void FormularioAgente_ConservaAccionesAutorizadasDuranteLaReconfiguracion()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            StringAssert.Contains(source, "let _agentProposalView = null;");
            StringAssert.Contains(source, "_agentProposalView = view;");
            StringAssert.Contains(source, "if (!insuredCompletion && _agentProposalView != null)");
            StringAssert.Contains(source, "renderAgentProposalStatus(_agentProposalView);");
        }

        /// <summary>
        /// Evita ocultar una acción autorizada cuando el generador la ubica dentro de una columna de visibilidad.
        /// </summary>
        [TestMethod]
        public void FormularioAgente_MuestraTambienElContenedorGeneradoDeCadaAccionAutorizada()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            StringAssert.Contains(source, "function setAgentProposalActionVisibility(buttonName, visible)");
            StringAssert.Contains(source, ".${buttonName}Visible");
            StringAssert.Contains(source, "setAgentProposalActionVisibility('btnResendLink'");
            StringAssert.Contains(source, "setAgentProposalActionVisibility('btnRevokeLink'");
            StringAssert.Contains(source, "setAgentProposalActionVisibility('btnResumeEditing'");
        }

        /// <summary>
        /// Evita que el fieldset bloqueado deshabilite las acciones de seguimiento autorizadas para el agente.
        /// </summary>
        [TestMethod]
        public void FormularioAgente_MantieneHabilitadasLasAccionesDeSeguimientoConElFormularioBloqueado()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            StringAssert.Contains(source, "form.find('fieldset').prop('disabled', false);");
            StringAssert.Contains(source, "#btnResendLink, #btnRevokeLink, #btnResumeEditing");
            StringAssert.Contains(source, "const controls = form.find('input, select, textarea, button').not(allowedActions);");
            StringAssert.Contains(source, "controls.each(function ()");
            StringAssert.Contains(source, "$(allowedActions).prop('disabled', false);");
        }

        /// <summary>
        /// Impide que retomar una corrección conserve deshabilitados los controles que el bloqueo de la invitación había alterado.
        /// </summary>
        [TestMethod]
        public void FormularioAgente_AlRetomarCorreccion_RestauraElEstadoOriginalDeLosControles()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));

            StringAssert.Contains(source, "function unlockAgentProposalFields()");
            StringAssert.Contains(source, "agentProposalInitialDisabled");
            StringAssert.Contains(source, "if (editable) {");
            StringAssert.Contains(source, "unlockAgentProposalFields();");
        }

        /// <summary>
        /// Evita que jQuery interprete el atributo HTML autocomplete como una llamada al complemento de autocompletado.
        /// </summary>
        [TestMethod]
        public void ReenvioDeEnlace_CreaElCampoDeCorreoSinInvocarElComplementoAutocomplete()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Scripts", "Form.Ext.Altas.js"));
            int start = source.IndexOf("function showResendInvitationModal()", StringComparison.Ordinal);
            int end = source.IndexOf("function showRevokeInvitationModal()", start, StringComparison.Ordinal);
            string resendSource = source.Substring(start, end - start);

            StringAssert.Contains(resendSource, ".attr('autocomplete', 'email')");
            Assert.IsFalse(resendSource.Contains("autocomplete: 'email'"),
                "El atributo debe asignarse después de crear el input para no invocar el complemento jQuery UI.");
        }
    }
}
