namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Carries a capability secret from the public page to the one-time exchange endpoint.
    /// The caller must supply it in the JSON body, never in a query string or route value.
    /// </summary>
    public sealed class ExchangeInvitationRequest
    {
        /// <summary>Gets or sets the invitation capability extracted from the browser URL fragment.</summary>
        public string Secret { get; set; }
    }
}
