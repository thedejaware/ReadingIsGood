using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(p => p.Id)
           .NotEmpty().WithMessage("{Id} is required.")
           .NotNull();

            RuleFor(p => p.FirstName)
               .NotEmpty().WithMessage("{FirstName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{FirstName} must not exceed 50 characters.");

            RuleFor(p => p.LastName)
               .NotEmpty().WithMessage("{LastName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{LastName} must not exceed 50 characters.");

            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("{Email} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{Email} must not exceed 50 characters.");
        }
    }
}
