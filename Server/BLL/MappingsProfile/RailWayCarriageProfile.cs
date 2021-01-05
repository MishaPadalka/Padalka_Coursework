using AutoMapper;
using Common.DTO.Carriages;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.MappingsProfile
{
    public class RailWayCarriageProfile : Profile
    {
        public RailWayCarriageProfile()
        {
            CreateMap<NewRailwayCarriage, RailwayCarriage>();
            CreateMap<RailwayCarriage, RailwayCarriageDTO>();
        }
    }
}
