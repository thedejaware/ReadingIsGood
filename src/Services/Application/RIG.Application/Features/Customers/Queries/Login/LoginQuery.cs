using MediatR;
using RIG.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Features.Customers.Queries.Login
{
    public class LoginQuery: IRequest<CustomerVm>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
