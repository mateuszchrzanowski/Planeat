using Microsoft.AspNetCore.Mvc;
using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.DTO;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Api.Controllers
{
    public class RoleController : ApiControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(ICommandDispatcher commandDispatcher,
            IRoleService roleService) : base(commandDispatcher)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<RoleDto> roles = await _roleService.GetAllAsync();

            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }
    }
}
