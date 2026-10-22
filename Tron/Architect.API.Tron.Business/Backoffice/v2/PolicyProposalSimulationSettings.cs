using System;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Centraliza los controles opcionales de simulación local del ciclo de firma y emisión.
    /// Ningún ajuste ausente, vacío o inválido habilita una integración simulada.
    /// </summary>
    internal static class PolicyProposalSimulationSettings
    {
        /// <summary>Clave que habilita localmente todo el ciclo simulado de firma y emisión.</summary>
        private const string SignatureSimulationSetting = "PolicyProposal.SignatureSimulation.Enabled";

        /// <summary>Prefijo que identifica una solicitud de firma creada solo para pruebas.</summary>
        private const string SimulatedSignaturePrefix = "SIM-FIRMA-";

        /// <summary>Prefijo que identifica una póliza emitida solo para pruebas.</summary>
        private const string SimulatedPolicyPrefix = "SIM-POLIZA-";

        /// <summary>
        /// Indica si se debe omitir el PDF, el proveedor de firma y la emisión real.
        /// </summary>
        internal static bool SignatureSimulationEnabled => ReadBoolean(SignatureSimulationSetting);

        /// <summary>
        /// Construye el identificador trazable de una solicitud de firma simulada.
        /// </summary>
        internal static string CreateSimulatedSigningRequestId(int proposalId)
        {
            return SimulatedSignaturePrefix + proposalId;
        }

        /// <summary>
        /// Determina si un identificador pertenece a una firma que jamás debe consultarse en el proveedor real.
        /// </summary>
        internal static bool IsSimulatedSignature(string signingRequestId)
        {
            return !string.IsNullOrWhiteSpace(signingRequestId) &&
                   signingRequestId.StartsWith(SimulatedSignaturePrefix, StringComparison.Ordinal);
        }

        /// <summary>
        /// Construye el identificador trazable de una póliza emitida únicamente en simulación.
        /// </summary>
        internal static string CreateSimulatedPolicyId(int proposalId)
        {
            return SimulatedPolicyPrefix + proposalId;
        }

        /// <summary>
        /// Lee una bandera booleana sin propagar configuraciones incompletas hacia el flujo de negocio.
        /// </summary>
        private static bool ReadBoolean(string settingName)
        {
            string configuredValue = Architect.Utilities.Helpers.Settings.StringValue(settingName);
            bool enabled;
            if (string.IsNullOrWhiteSpace(configuredValue) || !bool.TryParse(configuredValue, out enabled))
            {
                return false;
            }

            return enabled;
        }
    }
}
