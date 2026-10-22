using System;
using System.Collections.Generic;

namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Representa el alcance inmutable de un token temporal de completado por asegurado.
    /// El alcance siempre vincula una invitación, compañía y solicitud concretas; no contiene secretos ni datos personales.
    /// </summary>
    public sealed class InsuredCompletionTokenScope
    {
        /// <summary>Clave que identifica el tipo de alcance dentro de las configuraciones serializadas del token.</summary>
        public const string ScopeKey = "InsuredCompletion.Scope";

        /// <summary>Valor que identifica el permiso exclusivo de completar una solicitud invitada.</summary>
        public const string ScopeValue = "Proposal";

        /// <summary>Clave del identificador numérico de la invitación autorizante.</summary>
        public const string InvitationIdKey = "InsuredCompletion.InvitationId";

        /// <summary>Clave de la compañía propietaria de la solicitud invitada.</summary>
        public const string CompanyIdKey = "InsuredCompletion.CompanyId";

        /// <summary>Clave de la única solicitud que puede consumir el token temporal.</summary>
        public const string ProposalIdKey = "InsuredCompletion.ProposalId";

        /// <summary>Obtiene el identificador numérico de la invitación que emitió el token.</summary>
        public int InvitationId { get; private set; }

        /// <summary>Obtiene la compañía propietaria de la solicitud autorizada.</summary>
        public int CompanyId { get; private set; }

        /// <summary>Obtiene el identificador de la única solicitud autorizada.</summary>
        public string ProposalId { get; private set; }

        private InsuredCompletionTokenScope()
        {
        }

        /// <summary>
        /// Crea un alcance para una invitación activa y una solicitud no vacía.
        /// </summary>
        /// <param name="invitationId">Identificador numérico de la invitación activa.</param>
        /// <param name="companyId">Compañía propietaria de la solicitud.</param>
        /// <param name="proposalId">Identificador de la solicitud autorizada.</param>
        /// <returns>Alcance inmutable listo para incluirse en el token técnico.</returns>
        public static InsuredCompletionTokenScope Create(int invitationId, int companyId, string proposalId)
        {
            if (invitationId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(invitationId));
            }

            if (companyId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(companyId));
            }

            if (string.IsNullOrWhiteSpace(proposalId))
            {
                throw new ArgumentException("Debe indicar la solicitud autorizada.", nameof(proposalId));
            }

            return new InsuredCompletionTokenScope
            {
                InvitationId = invitationId,
                CompanyId = companyId,
                ProposalId = proposalId.Trim()
            };
        }

        /// <summary>
        /// Convierte el alcance en valores que se incorporan al cuerpo protegido del JWT técnico.
        /// </summary>
        /// <returns>Valores de configuración sin secretos, listos para serializar dentro del token.</returns>
        public Dictionary<string, string> ToSettings()
        {
            return new Dictionary<string, string>(StringComparer.Ordinal)
            {
                { ScopeKey, ScopeValue },
                { InvitationIdKey, InvitationId.ToString() },
                { CompanyIdKey, CompanyId.ToString() },
                { ProposalIdKey, ProposalId }
            };
        }

        /// <summary>
        /// Reconstruye y valida el alcance desde los valores del token sin aceptar alcances parciales o alterados.
        /// </summary>
        /// <param name="settings">Valores serializados en el token técnico.</param>
        /// <param name="scope">Alcance validado cuando el método devuelve <c>true</c>.</param>
        /// <returns><c>true</c> solo cuando todos los componentes del alcance son válidos.</returns>
        public static bool TryParse(IDictionary<string, string> settings, out InsuredCompletionTokenScope scope)
        {
            scope = null;
            if (settings == null ||
                !HasValue(settings, ScopeKey, ScopeValue) ||
                !settings.TryGetValue(InvitationIdKey, out string invitationText) ||
                !settings.TryGetValue(CompanyIdKey, out string companyText) ||
                !settings.TryGetValue(ProposalIdKey, out string proposalId) ||
                !int.TryParse(invitationText, out int invitationId) ||
                !int.TryParse(companyText, out int companyId) ||
                string.IsNullOrWhiteSpace(proposalId))
            {
                return false;
            }

            try
            {
                scope = Create(invitationId, companyId, proposalId);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <summary>
        /// Indica si una operación corresponde exactamente a la invitación, compañía y solicitud del token.
        /// </summary>
        /// <param name="invitationId">Invitación validada por la sesión HttpOnly.</param>
        /// <param name="companyId">Compañía solicitada por la operación.</param>
        /// <param name="proposalId">Solicitud solicitada por la operación.</param>
        /// <returns><c>true</c> únicamente para la coincidencia completa del alcance.</returns>
        public bool Authorizes(int invitationId, int companyId, string proposalId)
        {
            return InvitationId == invitationId &&
                   CompanyId == companyId &&
                   string.Equals(ProposalId, proposalId, StringComparison.Ordinal);
        }

        /// <summary>
        /// Verifica una pareja clave-valor sin aceptar una clave ausente o un valor con distinta capitalización.
        /// </summary>
        private static bool HasValue(IDictionary<string, string> settings, string key, string expectedValue)
        {
            return settings.TryGetValue(key, out string value) &&
                   string.Equals(value, expectedValue, StringComparison.Ordinal);
        }
    }
}
