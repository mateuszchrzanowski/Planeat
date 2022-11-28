using Planeat.Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Planeat.Tests.EndToEnd.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task ForValidCurrentPasswordAndNewPassword_PasswordShouldBeChanged()
        {
            var command = new ChangeUserPassword
            {
                CurrentPassword = "secret",
                NewPassword = "secret2",
            };
            var payload = GetPayload(command);
            var response = await Client.PutAsync("account/password", payload);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
