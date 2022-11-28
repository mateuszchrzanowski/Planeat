using Microsoft.AspNetCore.Mvc;
using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        public AccountController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put(ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}
