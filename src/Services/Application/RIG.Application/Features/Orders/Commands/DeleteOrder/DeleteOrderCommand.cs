using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
