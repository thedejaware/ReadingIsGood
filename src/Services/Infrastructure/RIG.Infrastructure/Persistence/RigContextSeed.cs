using Microsoft.Extensions.Logging;
using RIG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Infrastructure.Persistence
{
    public class RigContextSeed
    {
        public static async Task SeedAsync(RigContext rigContext, ILogger<RigContextSeed> logger)
        {
            if (!rigContext.Customers.Any())
            {
                rigContext.Customers.AddRange(GetPreconfiguredOrders());
                await rigContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(RigContext).Name);
            }
        }

        private static IEnumerable<Customer> GetPreconfiguredOrders()
        {
            return new List<Customer>
            {
                new Customer() { FirstName = "Mehmet", LastName = "Akın", Email = "mehmet@gmail.com", Username = "mma", Password= "123"}
            };
        }
    }
}
