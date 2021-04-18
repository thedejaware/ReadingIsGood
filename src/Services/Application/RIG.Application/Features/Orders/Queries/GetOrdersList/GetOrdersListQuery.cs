using MediatR;
using RIG.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrdersVm>>
    {
        public int CustomerId { get; set; }

        public GetOrdersListQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
