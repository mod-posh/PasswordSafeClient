namespace ModPosh.PasswordSafeClient.Models
{
    /// <summary>
    /// Represents a user in the PasswordSafe system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the UID of the user.
        /// </summary>
        public string? Uid { get; set; }

        /// <summary>
        /// Gets or sets the public key of the user.
        /// </summary>
        public string? PublicKey { get; set; }

        /// <summary>
        /// Gets or sets the login of the user.
        /// </summary>
        public string? Login { get; set; }
    }
}
