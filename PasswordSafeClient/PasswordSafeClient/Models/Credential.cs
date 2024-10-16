using System.Text.Json.Serialization;

namespace ModPosh.PasswordSafeClient.Models
{
    /// <summary>
    /// Represents a credential resource in the PasswordSafe system.
    /// </summary>
    public class Credential
    {
        /// <summary>
        /// Gets or sets the unique identifier of the credential.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the creation date and time of the credential.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last update date and time of the credential.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the project ID associated with the credential.
        /// </summary>
        [JsonPropertyName("project_id")]
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the username for the credential.
        /// </summary>
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the password for the credential.
        /// </summary>
        [JsonPropertyName("password")]
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the description of the credential.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the category of the credential.
        /// </summary>
        [JsonPropertyName("category")]
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets any prerequisites for using the credential.
        /// </summary>
        [JsonPropertyName("prerequisites")]
        public string? Prerequisites { get; set; }

        /// <summary>
        /// Gets or sets the URL associated with the credential.
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Gets or sets the version of the credential.
        /// </summary>
        [JsonPropertyName("version")]
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with the credential.
        /// </summary>
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the hostname associated with the credential.
        /// </summary>
        [JsonPropertyName("hostname")]
        public string? Hostname { get; set; }
    }
}
