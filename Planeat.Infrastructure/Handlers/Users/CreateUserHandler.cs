using FluentValidation;
using FluentValidation.Results;
using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.Commands.Users;
using Planeat.Infrastructure.Extensions;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(
                command.Email, command.FirstName, command.LastName, command.Password, command.RoleName);
        }
    }
}
