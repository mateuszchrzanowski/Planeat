using FluentValidation;
using Planeat.Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Validators
{
    public class ChangeUserRoleValidator : AbstractValidator<ChangeUserRole>
    {
        public ChangeUserRoleValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.RoleName)
                .NotEmpty()
                .NotNull();
        }
    }
}
