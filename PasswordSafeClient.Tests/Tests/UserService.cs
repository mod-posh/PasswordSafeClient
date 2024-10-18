using ModPosh.PasswordSafeClient.Services;
using ModPosh.PasswordSafeClient.Models;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ModPosh.PasswordSafeClient.Tests
{
    [TestFixture]
    public class UsersServiceTests : IDisposable
    {
        private Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private HttpClient _httpClient;
        private UsersService _usersService;
        private const string ValidAuthToken = "valid-auth-token";
        private const int TestProjectId = 12345;

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

            // Initialize UsersService with mocked HttpClient and auth token
            _usersService = new UsersService(_httpClient, ValidAuthToken);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of _httpClient to release resources after each test
            _httpClient?.Dispose();
        }

        [Test]
        public async Task GetAllUsersAsync_ReturnsListOfUsers()
        {
            // Arrange
            var expectedUsers = new List<User>
            {
                new User { Id = 1, Username = "john", Description = "Developer" },
                new User { Id = 2, Username = "jane", Description = "Manager" }
            };

            var jsonResponse = JsonSerializer.Serialize(expectedUsers);

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonResponse)
                });

            // Act
            var result = await _usersService.GetAllUsersAsync(TestProjectId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Username, Is.EqualTo("john"));
        }

        [Test]
        public async Task SearchUsersAsync_ReturnsMatchingUsers()
        {
            // Arrange
            var expectedUsers = new List<User>
            {
                new User { Id = 1, Username = "jim", Description = "QA" }
            };

            var jsonResponse = JsonSerializer.Serialize(expectedUsers);

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonResponse)
                });

            // Act
            var result = await _usersService.SearchUsersAsync(TestProjectId, "jim");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Username, Is.EqualTo("jim"));
        }

        [Test]
        public async Task AddUsersAsync_SuccessfullyAddsUsers()
        {
            // Arrange
            var userRequest = new UserRequest
            {
                Users = new List<string> { "alice", "bob" }
            };

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK
                });

            // Act & Assert (No exception means success)
            Assert.DoesNotThrowAsync(() => _usersService.AddUsersAsync(TestProjectId, userRequest));
        }

        [Test]
        public async Task DeleteUserAsync_SuccessfullyDeletesUser()
        {
            // Arrange
            var userId = 42;

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK
                });

            // Act & Assert (No exception means success)
            Assert.DoesNotThrowAsync(() => _usersService.DeleteUserAsync(TestProjectId, userId));
        }

        public void Dispose()
        {
            // Ensure that resources are properly disposed of
            _httpClient?.Dispose();
        }
    }
}
