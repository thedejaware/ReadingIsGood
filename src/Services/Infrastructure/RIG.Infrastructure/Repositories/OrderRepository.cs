using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RigContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId)
        {
            return await _dbContext.Orders
                                .Where(p => p.CustomerId == customerId)
                                .ToListAsync();

        }
    }
}
