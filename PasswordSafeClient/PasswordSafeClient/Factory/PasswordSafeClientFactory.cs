namespace ModPosh.PasswordSafeClient.Factory
{
    /// <summary>
    /// Factory class for creating instances of the PasswordSafe client.
    /// </summary>
    public static class PasswordSafeClientFactory
    {
        /// <summary>
        /// Creates a new instance of the PasswordSafeClient with the provided HttpClient and auth token.
        /// </summary>
        /// <param name="httpClient">The HttpClient to be used by the client.</param>
        /// <param name="authToken">The authentication token required for authorization.</param>
        /// <returns>A new instance of PasswordSafeClient.</returns>
        public static Client.PasswordSafeClient Create(HttpClient httpClient, string authToken)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                throw new ArgumentNullException(nameof(authToken), "Authentication token cannot be null or empty.");
            }

            return new Client.PasswordSafeClient(httpClient, authToken);
        }
    }
}
