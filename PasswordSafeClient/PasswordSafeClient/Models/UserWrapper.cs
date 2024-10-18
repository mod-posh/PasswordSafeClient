namespace ModPosh.PasswordSafeClient.Models
{
    /// <summary>
    /// Wrapper for a User object returned by the API.
    /// </summary>
    public class UserWrapper
    {
        /// <summary>
        /// The user object inside the wrapper.
        /// </summary>
        public User? User { get; set; }
    }
}
