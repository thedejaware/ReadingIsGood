using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(p => p.Id)
             .NotEmpty().WithMessage("{Id} is required.")
             .NotNull();

            RuleFor(p => p.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is required.")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");
        }
    }
}
