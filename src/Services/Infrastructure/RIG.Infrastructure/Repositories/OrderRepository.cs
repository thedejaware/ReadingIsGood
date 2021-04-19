using Microsoft.EntityFrameworkCore;
using RIG.Application.Contracts.Persistence;
using RIG.Domain.Entities;
using RIG.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IReadOnlyList<Order>> GetOrdersByCustomer(Expression<Func<Order, bool>> predicate = null, Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<Order> query = _dbContext.Set<Order>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }
    }
}
