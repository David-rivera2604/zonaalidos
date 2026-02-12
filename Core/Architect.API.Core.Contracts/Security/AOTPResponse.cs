using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Represents the response for an access request using AOTP (Access One-Time Password).
    /// Encapsulates authentication information and the generated access token.
    /// </summary>
    [DataContract]
    public class AOTPResponse 
    {
        /// <summary>
        /// Gets or sets the user authentication response information.
        /// Contains the authenticated user data and the result of the authentication process.
        /// </summary>
        [DataMember(), JsonProperty()]
        public AuthenticationResponse Context { get; set; }

        /// <summary>
        /// Gets or sets the security token generated for access.
        /// Contains the JWT token or session token information for subsequent requests.
        /// </summary>
        [DataMember(), JsonProperty()] 
        public Contracts.Security.Token Token { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the operation was executed successfully.
        /// <c>true</c> if the operation was successful; otherwise, <c>false</c>.
        /// </summary>
        [DataMember(), JsonProperty()]
        public bool Successful { get; set; }

        /// <summary>
        /// Gets or sets the details or informative message about the operation result.
        /// May contain error messages, warnings, or additional information.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the unique key identifier associated with this AOTP response.
        /// Used for tracking and correlating authentication attempts.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string Key { get; set; }
    } 
}
