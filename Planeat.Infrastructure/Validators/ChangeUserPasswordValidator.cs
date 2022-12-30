using FluentValidation;
using Planeat.Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Validators
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPassword>
    {
        public ChangeUserPasswordValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CurrentPassword)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8)
                .WithMessage("{PropertyName} must be at least 8 characters long.");

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8)
                .WithMessage("{PropertyName} must be at least 8 characters long.")
                .NotEqual(p => p.CurrentPassword)
                .WithMessage("{PropertyName} and Current Password must not be equal.");
        }
    }
}
