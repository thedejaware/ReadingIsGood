using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Features.Orders.Commands.AddOrder
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderCommandValidator()
        {
            RuleFor(p => p.CustomerId)
              .NotEmpty().WithMessage("{CustomerId} is required.")
              .NotNull();

            RuleFor(p => p.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is required.")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");
        }
    }
}
