namespace ModPosh.PasswordSafeClient.Models
{
    /// <summary>
    /// Represents the request payload for adding users to a project.
    /// </summary>
    public class UserRequest
    {
        /// <summary>
        /// List of usernames to be added to the project.
        /// </summary>
        public List<string> Users { get; set; } = new List<string>();
    }
}
