using AutoMapper;
using Common.DTO.Trains;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.MappingsProfile
{
    public class TrainProfile : Profile
    {
        public TrainProfile()
        {
            CreateMap<Train, TrainDTO>();
            CreateMap<NewTrain, Train>();
            CreateMap<Train, FullTrainDTO>();
        }
    }
}
