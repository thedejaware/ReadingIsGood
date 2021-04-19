using MediatR;
using Microsoft.Extensions.Logging;
using RIG.Application.Contracts.Persistence;
using RIG.Application.Exceptions;
using RIG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RIG.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repository;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;

        public DeleteCustomerCommandHandler(ICustomerRepository repository, ILogger<DeleteCustomerCommandHandler> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _repository.GetByIdAsync(request.Id);

            if (customerToDelete == null)
                throw new NotFoundException(nameof(Customer), request.Id);

            await _repository.DeleteAsync(customerToDelete);

            _logger.LogInformation($"Customer {customerToDelete.Id} is successfully deleted.");

            return true;

        }
    }
}
