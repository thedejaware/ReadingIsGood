using AutoMapper;
using MediatR;
using RIG.Application.Contracts.Persistence;
using RIG.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RIG.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrdersVm>>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OrdersVm>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {

            var ordersList = await _repository.GetListAsync(p => p.Id > 0, null, "OrderDetails");

            return _mapper.Map<List<OrdersVm>>(ordersList);
        }
    }
}
