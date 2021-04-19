﻿using RIG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Contracts.Persistence
{
    public interface ICustomerRepository: IAsyncRepository<Customer>
    {

    }
}
