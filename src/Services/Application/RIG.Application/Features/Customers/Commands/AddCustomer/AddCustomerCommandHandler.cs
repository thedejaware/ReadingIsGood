using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RIG.Application.Contracts.Persistence;
using RIG.Application.ViewModels;
using RIG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RIG.Application.Features.Customers.Commands.AddCustomer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, CustomerVm>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddCustomerCommandHandler> _logger;

        public AddCustomerCommandHandler(ICustomerRepository repository, IMapper mapper, ILogger<AddCustomerCommandHandler> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CustomerVm> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);

            var newCustomer = await _repository.AddAsync(customer);

            _logger.LogInformation($"Customer {newCustomer.FirstName} {newCustomer.LastName} is successfully created.");

            return _mapper.Map<CustomerVm>(newCustomer);
        }
    }
}
