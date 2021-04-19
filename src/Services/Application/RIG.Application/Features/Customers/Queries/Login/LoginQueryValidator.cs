using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Features.Customers.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(p => p.Username)
               .NotEmpty().WithMessage("{Username} is required.")
               .NotNull()
               .MaximumLength(20).WithMessage("{Username} must not exceed 50 characters.");

            RuleFor(p => p.Password)
               .NotEmpty().WithMessage("{Password} is required.")
               .NotNull()
               .MaximumLength(20).WithMessage("{Password} must not exceed 50 characters.");
        }
    }
}
