using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PTP.Gateway.Business.Models;
using System;
using System.Net.Http.Json;

namespace PTP.Gateway.Tests.IntegrationTests
{
    public class AccountControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;

        public AccountControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Login_Success()
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = "/v1/account/login";
            var request = new LoginRequest { EmailAddress = "test@test.test", Password = "password" };

            // Act
            var response = await client.PostAsJsonAsync<LoginRequest>(url, request);
            var responseJson  = await response.Content.ReadAsStringAsync();
            var loginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(responseJson);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.NotEmpty(loginResponse.Token);
        }

        [Fact]
        public async Task Login_Invalid_Request()
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = "/v1/account/login";
            var request = new LoginRequest { EmailAddress = "test", Password = "password" };

            // Act
            var response = await client.PostAsJsonAsync<LoginRequest>(url, request);
            var responseJson = await response.Content.ReadAsStringAsync();
            var objResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponse[]>(responseJson);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Single(objResponse);
            Assert.Equal(1001, int.Parse(objResponse[0].ErrorSubCode)); 
        }
    }
}