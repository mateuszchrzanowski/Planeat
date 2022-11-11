using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Planeat.Api;
using Planeat.Infrastructure.Commands.Users;
using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Planeat.Tests.EndToEnd.Controllers
{
    public class UserControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserControllerTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ForValidEmail_ReturnsUser()
        {
            var email = "user1@user.com";
            var user = await GetUserAsync(email);

            Assert.Equal(user.Email, email);
        }

        [Fact]
        public async Task ForInvalidEmail_Returns404()
        {
            var email = "fake@user.com";
            var response = await _client.GetAsync($"user/{email}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task ForUniqueEmail_UserShouldBeCreated()
        {
            var request = new CreateUser
            {
                Email = "testUser@user.com",
                Password = "testSecret",
                Username = "testUser"
            };
            var payload = GetPayload(request);
            var response = await _client.PostAsync("user", payload);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal($"user/{request.Email}", response.Headers.Location.ToString());
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            //var email = "user1@user.com";
            var response = await _client.GetAsync($"user/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }


    }
}
