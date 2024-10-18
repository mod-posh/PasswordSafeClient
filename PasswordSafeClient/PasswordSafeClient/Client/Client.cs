using ModPosh.PasswordSafeClient.Interfaces;
using ModPosh.PasswordSafeClient.Services;

namespace ModPosh.PasswordSafeClient.Client
{
    /// <summary>
    /// Main client for interacting with the PasswordSafe API.
    /// </summary>
    public class PasswordSafeClient : IPasswordSafeClient
    {
        /// <inheritdoc />
        public ICredentialsService CredentialsService { get; }

        /// <inheritdoc />
        public IUserService UsersService { get; }

        private string _authToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordSafeClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client used for API requests.</param>
        /// <param name="authToken">The authentication token used for authorization.</param>
        public PasswordSafeClient(HttpClient httpClient, string authToken)
        {
            _authToken = authToken ?? throw new ArgumentNullException(nameof(authToken));

            // Pass the token into CredentialsService
            CredentialsService = new CredentialsService(httpClient, _authToken);
            UsersService = new UsersService(httpClient, authToken);
        }

        /// <summary>
        /// Updates the auth token used by the client.
        /// </summary>
        /// <param name="newToken">The new auth token.</param>
        public void UpdateAuthToken(string newToken)
        {
            if (string.IsNullOrEmpty(newToken))
                throw new ArgumentNullException(nameof(newToken));

            _authToken = newToken;

            // Optionally, update the token in the service(s) as well if required.
        }
    }
}
