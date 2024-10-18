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
        /// Gets or sets the username of the user.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the description for the user.
        /// </summary>
        public string? Description { get; set; }
    }
}
