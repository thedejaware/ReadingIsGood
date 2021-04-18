using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RIG.Application.Contracts.Persistence;
using RIG.Application.Exceptions;
using RIG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RIG.Application.Features.Orders.Commands.UpdateOrder
{
    class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToUpdate == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            // Client'tan glen veriler (request) ile veritabnındaki veriler (orderToUpdate) Map'leniyor
            _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order));

            await _orderRepository.UpdateAsync(orderToUpdate);

            _logger.LogInformation($"Order {orderToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
