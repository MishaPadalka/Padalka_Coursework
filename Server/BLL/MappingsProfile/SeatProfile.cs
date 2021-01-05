using AutoMapper;
using Common.DTO.Seats;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.MappingsProfile
{
    public class SeatProfile : Profile
    {
        public SeatProfile()
        {
            CreateMap<Seat, SeatDTO>()
                .ForMember(x => x.Free, opt => opt.MapFrom(g => g.Order == null));
        }
    }
}
