using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIG.API.Model;
using RIG.Application.Features.Orders.Commands.AddOrder;
using RIG.Application.Features.Orders.Commands.DeleteOrder;
using RIG.Application.Features.Orders.Commands.UpdateOrder;
using RIG.Application.Features.Orders.Queries.GetAllOrders;
using RIG.Application.Features.Orders.Queries.GetOrder;
using RIG.Application.Features.Orders.Queries.GetOrdersList;
using RIG.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RIG.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("[action]/{customerId}", Name = "GetByCustomer")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrdersVm>>> GetByCustomer(int customerId)
        {
            var query = new GetOrdersListQuery(customerId);
            var orders = await _mediator.Send(query);
            if (orders != null)
                return new JsonResult(new ResponseModel
                {
                    Success = true,
                    Data = orders
                });
            else
                return new JsonResult(new ResponseModel
                {
                    Success = false,
                    ErrorMessage = "Unable to get orders"
                });
        }

        [HttpGet]
        [Route("[action]", Name = "GetAllOrders")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrdersVm>>> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();
            var orders = await _mediator.Send(query);
            if (orders != null)
                return new JsonResult(new ResponseModel
                {
                    Success = true,
                    Data = orders
                });
            else
                return new JsonResult(new ResponseModel
                {
                    Success = false,
                    ErrorMessage = "Unable to get orders"
                });
        }

        [HttpGet("{id}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrdersVm>>> GetOrder(int id)
        {
            var query = new GetOrderQuery(id);
            var order = await _mediator.Send(query);
            if (order != null)
                return new JsonResult(new ResponseModel
                {
                    Success = true,
                    Data = order
                });
            else
                return new JsonResult(new ResponseModel
                {
                    Success = false,
                    ErrorMessage = "No records found"
                });
        }

        [HttpPost(Name = "AddOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddOrder([FromBody] AddOrderCommand command)
        {
            var result = await _mediator.Send(command);
            if (result != null)
                return new JsonResult(new ResponseModel
                {
                    Success = true,
                    Data = result
                });
            else
                return new JsonResult(new ResponseModel
                {
                    Success = false,
                    ErrorMessage = "Unable to add order"
                });

        }

        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
                return new JsonResult(new ResponseModel
                {
                    Success = true
                });
            else
                return new JsonResult(new ResponseModel
                {
                    Success = false,
                    ErrorMessage = "Unable to update order"
                });
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var command = new DeleteOrderCommand() { Id = id };
            var result = await _mediator.Send(command);
            if (result)
                return new JsonResult(new ResponseModel
                {
                    Success = true
                });
            else
                return new JsonResult(new ResponseModel
                {
                    Success = false,
                    ErrorMessage = "Unable to delete order"
                });
        }
    }
}
