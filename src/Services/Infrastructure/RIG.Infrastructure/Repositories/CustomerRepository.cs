using RIG.Application.Contracts.Persistence;
using RIG.Domain.Entities;
using RIG.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Infrastructure.Repositories
{
    public class CustomerRepository: RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RigContext dbContext) : base(dbContext)
        {

        }
    }
}
