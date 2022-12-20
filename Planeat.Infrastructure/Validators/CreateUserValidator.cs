using FluentValidation;
//using Planeat.Core.Repositories;
using Planeat.Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .EmailAddress();
            //.MustAsync(async (email, cancelation) =>
            // {
            //     var user = await userRepository.GetAsync(email);

            //     if (user != null)
            //     {
            //         return false;
            //     }

            //     return true;

            // }).WithMessage("User with email: '{PropertyValue}' already exist.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8)
                .WithMessage("{PropertyName} must be at least 8 characters long.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .NotNull()
                .Equal(e => e.Password)
                .WithMessage("Password and {PropertyName} must be equal.");
        }
    }
}
