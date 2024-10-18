using ModPosh.PasswordSafeClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModPosh.PasswordSafeClient.Interfaces
{
    /// <summary>
    /// Interface for managing users in projects within PasswordSafe.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves the list of users in a specific project.
        /// </summary>
        /// <param name="projectId">The project ID.</param>
        /// <returns>A list of users in the project.</returns>
        Task<List<User>> GetAllUsersAsync(int projectId);

        /// <summary>
        /// Searches for users in a project based on a query string.
        /// </summary>
        /// <param name="projectId">The project ID.</param>
        /// <param name="query">The search query string.</param>
        /// <returns>A list of users matching the search query.</returns>
        Task<List<User>> SearchUsersAsync(int projectId, string query);

        /// <summary>
        /// Adds users to a specific project.
        /// </summary>
        /// <param name="projectId">The project ID.</param>
        /// <param name="userRequest">The user request payload containing the list of users to add.</param>
        /// <returns>A task representing the async operation.</returns>
        Task AddUsersAsync(int projectId, UserRequest userRequest);

        /// <summary>
        /// Deletes a user from a specific project.
        /// </summary>
        /// <param name="projectId">The project ID.</param>
        /// <param name="userId">The user ID.</param>
        /// <returns>A task representing the async operation.</returns>
        Task DeleteUserAsync(int projectId, int userId);
    }
}
