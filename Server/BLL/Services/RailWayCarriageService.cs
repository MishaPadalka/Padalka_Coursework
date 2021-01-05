using AutoMapper;
using BLL.Interfaces;
using Common.DTO.Carriages;
using Common.DTO.Seats;
using DAL.Entities;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RailWayCarriageService : IRailWayCarriageService
    {
        private readonly IMapper mapper;
        private readonly IRailWayCarriageRepository carriageRepository;
        private readonly ISeatRepository seatRepository;
        private readonly ITrainRepository trainRepository;
        public RailWayCarriageService(IRailWayCarriageRepository carriageRepository, IMapper mapper, ISeatRepository seatRepository, ITrainRepository trainRepository)
        {
            this.carriageRepository = carriageRepository;
            this.mapper = mapper;
            this.seatRepository = seatRepository;
            this.trainRepository = trainRepository;
        }

        public async Task<RailwayCarriageDTO> Add(NewRailwayCarriage newRailway)
        {
            var bdRailWayCarriage = mapper.Map<RailwayCarriage>(newRailway);

            bdRailWayCarriage.Number = await carriageRepository.GetNumberCarriage(newRailway.TrainId);

            var carriage = await carriageRepository.Add(bdRailWayCarriage);


            var ListSeats = Enumerable.Range(1, newRailway.CountSeats).Select(x => new Seat() { RailwayCarriageId = carriage.Id, NumberSeat = x, Price = newRailway.Price });
            await seatRepository.AddRange(ListSeats);

            var train = await trainRepository.GetById(newRailway.TrainId);
            train.FreePlaces += newRailway.CountSeats;
            await trainRepository.Update(train);


            var returnCarriage = await carriageRepository.GetById(carriage.Id);
            var carriageDTO = mapper.Map<RailwayCarriageDTO>(returnCarriage);
            return carriageDTO;
        }
        public async Task DeleteCarriage(int id)
        {
            await carriageRepository.DeleteCarriage(id);
        }
    }
}
