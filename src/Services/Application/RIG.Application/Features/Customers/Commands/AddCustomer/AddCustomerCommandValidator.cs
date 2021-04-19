﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Features.Customers.Commands.AddCustomer
{
    public class AddCustomerCommandValidator: AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidator()
        {
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
