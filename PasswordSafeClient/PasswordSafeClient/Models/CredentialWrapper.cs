using System.Text.Json.Serialization;

namespace ModPosh.PasswordSafeClient.Models
{
    /// <summary>
    /// Wraps the Credential object returned by the API.
    /// </summary>
    public class CredentialWrapper
    {
        /// <summary>
        /// Gets or sets the credential object.
        /// </summary>
        [JsonPropertyName("credential")]
        public Credential? Credential { get; set; }
    }
}
