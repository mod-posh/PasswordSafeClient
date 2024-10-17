using ModPosh.PasswordSafeClient.Services;
using ModPosh.PasswordSafeClient.Models;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ModPosh.PasswordSafeClient.Tests
{
    [TestFixture]
    public class CredentialsServiceTests : IDisposable
    {
        private Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private HttpClient _httpClient;
        private CredentialsService _credentialsService;
        private const string ValidAuthToken = "valid-auth-token";
        private const int TestProjectId = 12345;
        private const int TestCredentialId = 67890;

        [SetUp]
        public void Setup()
        {
            // Mock HttpMessageHandler to simulate HttpClient responses
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            // Allow Dispose to be called without throwing an exception
            _httpMessageHandlerMock.Protected().Setup("Dispose", ItExpr.IsAny<bool>());

            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://pwdsafe.rackspace.net")
            };

            // Initialize CredentialsService with mocked HttpClient and auth token
            _credentialsService = new CredentialsService(_httpClient, ValidAuthToken);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of _httpClient to release resources after each test
            _httpClient?.Dispose();
        }

        [Test]
        public async Task GetCredentialAsync_ReturnsValidCredential()
        {
            // Arrange: Create a mock response
            var expectedCredential = new Credential
            {
                Id = TestCredentialId,
                Description = "Test Description",
                Username = "test-user"
            };

            var jsonResponse = JsonSerializer.Serialize(new { credential = expectedCredential });

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",  // Mock the protected SendAsync method
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonResponse)
                });

            // Act: Call GetCredentialAsync
            var result = await _credentialsService.GetCredentialAsync(TestProjectId, TestCredentialId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(TestCredentialId));
            Assert.That(result.Description, Is.EqualTo("Test Description"));
        }

        // Other test methods...

        public void Dispose()
        {
            // Ensure that resources are properly disposed of
            _httpClient?.Dispose();
        }
    }
}
