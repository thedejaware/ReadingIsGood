using RIG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId);

        Task<IReadOnlyList<Order>> GetOrdersByCustomer(Expression<Func<Order, bool>> predicate = null,
                                        Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true);
    }
}
