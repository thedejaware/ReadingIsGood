using RIG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Domain.Entities
{
    public class Order: EntityBase
    {
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }

        // Address Information
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        // Payment
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }

        public Customer Customer { get; set; }


    }

}
