using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Represents the response returned after an authentication request.
    /// Contains user information, access tokens, and authentication status details.
    /// </summary>
    [DataContract]
    public class AuthenticationResponse
    {
        /// <summary>
        /// Gets or sets the username of the authenticated user.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the tenant or owner identifier associated with the user.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string Tenant { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user must change their password.
        /// When <c>true</c>, the user should be prompted to update their credentials.
        /// </summary>
        [DataMember(), JsonProperty()]
        public bool MustChangePassword { get; set; }

        /// <summary>
        /// Gets or sets the duration in seconds until the access token expires.
        /// </summary>
        [DataMember(), JsonProperty()]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the reason or message associated with the authentication result.
        /// Typically contains error messages when authentication fails or additional information for successful authentication.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the array of role names assigned to the authenticated user.
        /// Used for authorization and access control purposes.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string[] Roles { get; set; }

        /// <summary>
        /// Gets or sets the JWT access token for the authenticated session.
        /// This token should be included in subsequent API requests for authorization.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the initial navigation path or route for the user after successful authentication.
        /// Used to redirect the user to their designated starting page.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string InitialPath { get; set; }

        /// <summary>
        /// Gets or sets the email address of the authenticated user.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string EMail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether two-factor authentication (2FA) via One-Time Password (OTP) is required.
        /// When <c>true</c>, the user must provide an OTP code to complete authentication.
        /// </summary>
        [DataMember(), JsonProperty()]
        public bool Need2FAOTP { get; set; }

        /// <summary>
        /// Gets or sets the collection of configuration settings associated with the user.
        /// Contains key-value pairs for user-specific or application settings.
        /// </summary>
        [DataMember(), JsonProperty()]
        public List<SettingItem> Settings { get; set; }

        /// <summary>
        /// Gets or sets the Adaptive One-Time Password (AOTP) response details.
        /// Contains information related to the OTP verification process when 2FA is enabled.
        /// </summary>
        [DataMember(), JsonProperty()]
        public AOTPResponse AOTP { get; set; }
    }

    /// <summary>
    /// Represents a single configuration setting as a key-value pair.
    /// </summary>
    [DataContract]
    public class SettingItem
    {
        /// <summary>
        /// Gets or sets the unique identifier or name of the setting.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the value associated with the setting key.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string Value { get; set; }
    }
}
