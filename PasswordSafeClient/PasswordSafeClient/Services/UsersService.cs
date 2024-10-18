using ModPosh.PasswordSafeClient.Interfaces;
using ModPosh.PasswordSafeClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ModPosh.PasswordSafeClient.Services
{
    /// <summary>
    /// Service for managing users within projects.
    /// </summary>
    public class UsersService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _authToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client used for making API calls.</param>
        /// <param name="authToken">The authentication token used for authorization.</param>
        public UsersService(HttpClient httpClient, string authToken)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _authToken = authToken ?? throw new ArgumentNullException(nameof(authToken));
        }

        /// <summary>
        /// Sets the Authorization header with the current auth token.
        /// </summary>
        private void SetAuthHeader()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authToken);
        }

        /// <inheritdoc />
        public async Task<List<User>> GetAllUsersAsync(int projectId)
        {
            SetAuthHeader();

            var response = await _httpClient.GetAsync($"/projects/{projectId}/users");
            response.EnsureSuccessStatusCode();

            var users = await response.Content.ReadFromJsonAsync<List<User>>();
            return users ?? new List<User>();
        }

        /// <inheritdoc />
        public async Task<List<User>> SearchUsersAsync(int projectId, string query)
        {
            SetAuthHeader();

            var response = await _httpClient.GetAsync($"/projects/{projectId}/users/search?search_query={query}");
            response.EnsureSuccessStatusCode();

            var users = await response.Content.ReadFromJsonAsync<List<User>>();
            return users ?? new List<User>();
        }

        /// <inheritdoc />
        public async Task AddUsersAsync(int projectId, UserRequest userRequest)
        {
            SetAuthHeader();

            var response = await _httpClient.PostAsJsonAsync($"/projects/{projectId}/users/add", userRequest);
            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc />
        public async Task DeleteUserAsync(int projectId, int userId)
        {
            SetAuthHeader();

            var response = await _httpClient.DeleteAsync($"/projects/{projectId}/users/{userId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
