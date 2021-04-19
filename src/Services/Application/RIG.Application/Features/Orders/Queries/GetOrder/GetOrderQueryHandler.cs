using AutoMapper;
using MediatR;
using RIG.Application.Contracts.Persistence;
using RIG.Application.Exceptions;
using RIG.Application.ViewModels;
using RIG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RIG.Application.Features.Orders.Queries.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrdersVm>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OrdersVm> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var orderInDb = await _repository.GetByIdAsync(p => p.Id == request.Id, null, "OrderDetails");

            return _mapper.Map<OrdersVm>(orderInDb);
        }
    }
}
