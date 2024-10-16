namespace ModPosh.PasswordSafeClient.Models
{
    /// <summary>
    /// Represents the request payload for creating or updating a credential.
    /// </summary>
    public class CredentialRequest
    {
        /// <summary>
        /// Gets or sets the credential to be created or updated.
        /// </summary>
        public Credential? Credential { get; set; }
    }
}
