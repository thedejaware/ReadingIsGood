using AutoMapper;
using RIG.Application.Features.Orders.Commands.AddOrder;
using RIG.Application.Features.Orders.Commands.UpdateOrder;
using RIG.Application.ViewModels;
using RIG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            // Order Mapping
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order, AddOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();


        }
    }
}
