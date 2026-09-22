using AutoMapper;
using CodeAlpha_RestaurantManagementSystem.Business.DTOs.InventoryDtos;
using CodeAlpha_RestaurantManagementSystem.Business.DTOs.MenuItemDtos;
using CodeAlpha_RestaurantManagementSystem.Business.DTOs.OrderDtos;
using CodeAlpha_RestaurantManagementSystem.Business.DTOs.OrderItemDtos;
using CodeAlpha_RestaurantManagementSystem.Business.DTOs.ReservationDtos;
using CodeAlpha_RestaurantManagementSystem.Business.DTOs.TableDtos;
using CodeAlpha_RestaurantManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Helpers.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<MenuItem, MenuItemGetDto>().ReverseMap();
            CreateMap<MenuItemCreateDto, MenuItem>();
            CreateMap<MenuItemUpdateDto, MenuItem>();

            
            CreateMap<Table, TableGetDto>().ReverseMap();
            CreateMap<TableCreateDto, Table>();
            CreateMap<TableUpdateDto, Table>();

            
            CreateMap<Reservation, ReservationGetDto>()
                .ForMember(dest => dest.TableNumber, opt => opt.MapFrom(src => src.Table.TableNumber));
            CreateMap<ReservationCreateDto, Reservation>();

            
            CreateMap<Order, OrderGetDto>()
                .ForMember(dest => dest.TableNumber, opt => opt.MapFrom(src => src.Table.TableNumber));
            CreateMap<OrderCreateDto, Order>();

            CreateMap<OrderItem, OrderItemGetDto>()
                .ForMember(dest => dest.MenuItemName, opt => opt.MapFrom(src => src.MenuItem.Name));
            CreateMap<OrderItemCreateDto, OrderItem>();

           
            CreateMap<InventoryItem, InventoryItemGetDto>().ReverseMap();
            CreateMap<InventoryItemCreateDto, InventoryItem>();
        }
    }
}
