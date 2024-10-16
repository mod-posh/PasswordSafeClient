namespace ModPosh.PasswordSafeClient.Interfaces
{
    /// <summary>
    /// Defines the operations available in the PasswordSafe client.
    /// </summary>
    public interface IPasswordSafeClient
    {
        /// <summary>
        /// Gets the service for managing credentials.
        /// </summary>
        ICredentialsService CredentialsService { get; }
    }
}
