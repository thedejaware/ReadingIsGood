using AutoMapper;
using MediatR;
using RIG.Application.Contracts.Persistence;
using RIG.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RIG.Application.Features.Customers.Queries.GetAllCustomer
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerVm>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCustomerQueryHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CustomerVm>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customerList = await _repository.GetAllAsync();

            return _mapper.Map<List<CustomerVm>>(customerList);
        }
    }
}
