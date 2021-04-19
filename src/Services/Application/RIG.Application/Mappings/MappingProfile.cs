using AutoMapper;
using RIG.Application.Features.Customers.Commands.AddCustomer;
using RIG.Application.Features.Customers.Commands.UpdateCustomer;
using RIG.Application.Features.Customers.Queries.Login;
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
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Order Mapping
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order, AddOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();

            // Order Detail
            //CreateMap<List<OrderDetailsVm>, AddOrderCommand>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailsVm>().ReverseMap();

            // Customer Mapping
            CreateMap<Customer, CustomerVm>().ReverseMap();
            CreateMap<Customer, AddCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, LoginQuery>().ReverseMap();

        }
    }
}
