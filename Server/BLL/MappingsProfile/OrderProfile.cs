using AutoMapper;
using Common.DTO.Seats;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.MappingsProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<NewOrder, Order>();
            CreateMap<Order, OrderDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(g => g.Id))
                .ForMember(x => x.OrderDate, opt => opt.MapFrom(g => g.OrderDate))
                .ForMember(x => x.NumberSeat, opt => opt.MapFrom(g => g.Seat.NumberSeat))
                .ForMember(x => x.NumberCarriage, opt => opt.MapFrom(g => g.Seat.RailwayCarriage.Number))
                .ForMember(x => x.NameTrain, opt => opt.MapFrom(g => g.Seat.RailwayCarriage.Train.Name))
                .ForMember(x => x.WhereGoes, opt => opt.MapFrom(g => g.Seat.RailwayCarriage.Train.WhereGoes))
                .ForMember(x => x.WhereFrom, opt => opt.MapFrom(g => g.Seat.RailwayCarriage.Train.WhereFrom))
                .ForMember(x => x.Departure, opt => opt.MapFrom(g => g.Seat.RailwayCarriage.Train.Departure))
                .ForMember(x => x.Arrival, opt => opt.MapFrom(g => g.Seat.RailwayCarriage.Train.Arrival))
                .ForMember(x => x.Price, opt => opt.MapFrom(g => g.Price))
                .ForMember(x => x.BuyerFirstName, opt => opt.MapFrom(g => g.BuyerFirstName))
                .ForMember(x => x.BuyerLastName, opt => opt.MapFrom(g => g.BuyerLastName));
        }
    }
}
