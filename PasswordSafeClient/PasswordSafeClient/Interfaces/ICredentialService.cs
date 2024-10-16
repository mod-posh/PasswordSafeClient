using ModPosh.PasswordSafeClient.Models;

namespace ModPosh.PasswordSafeClient.Interfaces
{
    /// <summary>
    /// Defines the operations for managing credentials within a project.
    /// </summary>
    public interface ICredentialsService
    {
        /// <summary>
        /// Retrieves all credentials for the specified project.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        /// <returns>A list of credentials associated with the project.</returns>
        Task<List<Credential>> GetAllCredentialsAsync(int projectId);

        /// <summary>
        /// Retrieves a specific credential by ID.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        /// <param name="credentialId">The ID of the credential.</param>
        /// <returns>The credential associated with the specified ID.</returns>
        Task<Credential> GetCredentialAsync(int projectId, int credentialId);

        /// <summary>
        /// Creates a new credential within the specified project.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        /// <param name="credentialRequest">The request payload containing the credential details.</param>
        /// <returns>The newly created credential.</returns>
        Task<Credential> CreateCredentialAsync(int projectId, CredentialRequest credentialRequest);

        /// <summary>
        /// Updates an existing credential.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        /// <param name="credentialId">The ID of the credential to update.</param>
        /// <param name="credentialRequest">The request payload containing updated credential details.</param>
        Task UpdateCredentialAsync(int projectId, int credentialId, CredentialRequest credentialRequest);

        /// <summary>
        /// Deletes a credential by ID.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        /// <param name="credentialId">The ID of the credential to delete.</param>
        Task DeleteCredentialAsync(int projectId, int credentialId);
    }
}
