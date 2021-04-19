using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIG.API.Model;
using RIG.Application.Features.Customers.Commands.AddCustomer;
using RIG.Application.Features.Customers.Commands.DeleteCustomer;
using RIG.Application.Features.Customers.Commands.UpdateCustomer;
using RIG.Application.Features.Customers.Queries.GetAllCustomer;
using RIG.Application.Features.Customers.Queries.GetCustomer;
using RIG.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RIG.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        [ProducesResponseType(typeof(IEnumerable<CustomerVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomerVm>>> GetCustomer(int id)
        {
            var query = new GetCustomerQuery(id);
            var customer = await _mediator.Send(query);
            if (customer != null)
                return new JsonResult(new ResponseModel
                {
                    Success = true,
                    Data = customer
                });
            else
                return new JsonResult(new ResponseModel
                {
                    Success = false,
                    ErrorMessage = "No records found"
                });

        }

        [HttpGet]
        [Route("[action]", Name = "GetAllCustomers")]
        [ProducesResponseType(typeof(IEnumerable<CustomerVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomerVm>>> GetAllCustomers()
        {
            var query = new GetAllCustomerQuery();
            var customers = await _mediator.Send(query);
            if (customers != null)
                return new JsonResult(new ResponseModel
                {
                    Success = true,
                    Data = customers
                });
            else
                return new JsonResult(new ResponseModel
                {
                    Success = false,
                    ErrorMessage = "Unable to get customers"
                });
        }

        [AllowAnonymous]
        [HttpPost(Name = "AddCustomer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerVm>> AddCustomer([FromBody] AddCustomerCommand command)
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
                    ErrorMessage = "Unable to add customer"
                });

        }

        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            if(result)
                return new JsonResult(new ResponseModel
                {
                    Success = true
                });
            else
                return new JsonResult(new ResponseModel
                {
                    Success = false,
                    ErrorMessage = "Unable to update customer"
                });
        }

        [HttpDelete("{id}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var command = new DeleteCustomerCommand() { Id = id };
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
                    ErrorMessage = "Unable to delete customer"
                });
        }
    }
}
