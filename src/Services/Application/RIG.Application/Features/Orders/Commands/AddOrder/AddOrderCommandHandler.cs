using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RIG.Application.Contracts.Persistence;
using RIG.Application.ViewModels;
using RIG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RIG.Application.Features.Orders.Commands.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, OrdersVm>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddOrderCommandHandler> _logger;

        public AddOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<AddOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<OrdersVm> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);

            var newOrder = await _orderRepository.AddAsync(orderEntity);

            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");

            return _mapper.Map<OrdersVm>(newOrder);
        }
    }
}
