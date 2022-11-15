using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Planeat.Api;
using Planeat.Infrastructure.Commands.User;
using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Planeat.Tests.EndToEnd.Controllers
{
    public class UserControllerTests : ControllerTestsBase
    {
        //private readonly TestServer _server;
        //private readonly HttpClient _client;

        //public UserControllerTests()
        //{
        //    var path = Assembly.GetAssembly(typeof(UserControllerTests)).Location;

        //    var hostBuilder = new WebHostBuilder().UseContentRoot(Path.GetDirectoryName(path))
        //        .ConfigureServices(services => services.AddAutofac())
        //        .UseStartup<Startup>();

        //    _server = new TestServer(hostBuilder);
        //    _client = _server.CreateClient();
        //}

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
            var response = await Client.GetAsync($"user/{email}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task ForUniqueEmail_UserShouldBeCreated()
        {
            var command = new CreateUser
            {
                Email = "testUser@user.com",
                Password = "testSecret",
                Username = "testUser"
            };
            var payload = GetPayload(command);
            var response = await Client.PostAsync("user", payload);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal($"user/{command.Email}", response.Headers.Location.ToString());
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            //var email = "user1@user.com";
            var response = await Client.GetAsync($"user/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}
