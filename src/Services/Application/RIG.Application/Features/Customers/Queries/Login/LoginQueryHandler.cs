using AutoMapper;
using MediatR;
using RIG.Application.Contracts.Persistence;
using RIG.Application.Exceptions;
using RIG.Application.ViewModels;
using RIG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RIG.Application.Features.Customers.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, CustomerVm>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public LoginQueryHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CustomerVm> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var customerInDb = await _repository.GetAsync(p => p.Username == request.Username && p.Password == request.Password);

            if (customerInDb == null)
                throw new NotFoundException(nameof(Customer), request.Username);

            return _mapper.Map<CustomerVm>(customerInDb);
        }
    }
}
