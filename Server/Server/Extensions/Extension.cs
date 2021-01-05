using AutoMapper;
using BLL.Interfaces;
using BLL.MappingsProfile;
using BLL.Services;
using DAL.IRepository;
using DAL.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public static class Extensions
    {
        public static  void AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITrainService, TrainService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRailWayCarriageService, RailWayCarriageService>();
            services.AddScoped<ISeatService, SeatService>();
        }
        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRailWayCarriageRepository, RailWayCarriageRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<ITrainRepository, TrainRepository>();
        }
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
           services.AddAutoMapper(typeof(TrainProfile).Assembly);
        }
    }
}
