using MediatR;
using RIG.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Features.Customers.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<CustomerVm>
    {
        public int Id { get; set; }

        public GetCustomerQuery(int id)
        {
            Id = id;
        }
    }
}
