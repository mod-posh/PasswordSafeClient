using ModPosh.PasswordSafeClient.Interfaces;
using ModPosh.PasswordSafeClient.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace ModPosh.PasswordSafeClient.Services
{
    /// <summary>
    /// Service for managing credentials within projects.
    /// </summary>
    public class CredentialsService : ICredentialsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _authToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="CredentialsService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client used for making API calls.</param>
        /// <param name="authToken">The authentication token used for authorization.</param>
        public CredentialsService(HttpClient httpClient, string authToken)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _authToken = authToken ?? throw new ArgumentNullException(nameof(authToken));
        }

        /// <summary>
        /// Creates an HttpRequestMessage and sets the X-Auth-Token header for each request.
        /// </summary>
        /// <param name="method">The HTTP method (GET, POST, etc.).</param>
        /// <param name="requestUri">The request URI.</param>
        /// <returns>The HttpRequestMessage with X-Auth-Token header set.</returns>
        private HttpRequestMessage CreateHttpRequestMessage(HttpMethod method, string requestUri)
        {
            var request = new HttpRequestMessage(method, requestUri);

            // Set the X-Auth-Token header instead of Authorization
            request.Headers.Add("X-Auth-Token", _authToken);

            return request;
        }

        /// <inheritdoc />
        public async Task<List<Credential>> GetAllCredentialsAsync(int projectId)
        {
            var request = CreateHttpRequestMessage(HttpMethod.Get, $"/projects/{projectId}/credentials");

            // Send the request and log the response
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var credentials = await response.Content.ReadFromJsonAsync<List<Credential>>();
            return credentials ?? new List<Credential>();
        }

        /// <summary>
        /// Retrieves a specific credential by its ID and project ID.
        /// </summary>
        /// <param name="projectId">The ID of the project containing the credential.</param>
        /// <param name="credentialId">The ID of the credential to retrieve.</param>
        /// <returns>The credential object associated with the given IDs.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the credential cannot be deserialized.</exception>
        public async Task<Credential> GetCredentialAsync(int projectId, int credentialId)
        {
            var request = CreateHttpRequestMessage(HttpMethod.Get, $"/projects/{projectId}/credentials/{credentialId}");

            // Send the request and log the response
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var rawJson = await response.Content.ReadAsStringAsync();

            var credentialWrapper = JsonSerializer.Deserialize<CredentialWrapper>(rawJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return credentialWrapper?.Credential
                ?? throw new InvalidOperationException("Failed to deserialize the credential.");
        }

        /// <inheritdoc />
        public async Task<Credential> CreateCredentialAsync(int projectId, CredentialRequest credentialRequest)
        {
            var request = CreateHttpRequestMessage(HttpMethod.Post, $"/projects/{projectId}/credentials");
            request.Content = JsonContent.Create(credentialRequest);

            // Send the request and log the response
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var createdCredential = await response.Content.ReadFromJsonAsync<Credential>();
            return createdCredential ?? throw new InvalidOperationException("Failed to create the credential.");
        }

        /// <inheritdoc />
        public async Task UpdateCredentialAsync(int projectId, int credentialId, CredentialRequest credentialRequest)
        {
            var request = CreateHttpRequestMessage(HttpMethod.Put, $"/projects/{projectId}/credentials/{credentialId}");
            request.Content = JsonContent.Create(credentialRequest);

            // Send the request and log the response
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc />
        public async Task DeleteCredentialAsync(int projectId, int credentialId)
        {
            var request = CreateHttpRequestMessage(HttpMethod.Delete, $"/projects/{projectId}/credentials/{credentialId}");

            // Send the request and log the response
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
