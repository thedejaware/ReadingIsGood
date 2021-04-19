using MediatR;
using RIG.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Features.Customers.Queries.GetAllCustomer
{
    public class GetAllCustomerQuery : IRequest<List<CustomerVm>>
    {
    }
}
