using AutoMapper;
using BLL.Interfaces;
using Common.DTO.Trains;
using DAL.Entities;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TrainService : ITrainService
    {
        private readonly ITrainRepository trainRepository;
        private readonly IMapper mapper;
        public TrainService(ITrainRepository trainRepository, IMapper mapper)
        {
            this.trainRepository = trainRepository;
            this.mapper = mapper;
        }

        public async Task<TrainDTO> Add(NewTrain newTrain)
        {
            var train = mapper.Map<Train>(newTrain);
            var newtrain = await trainRepository.Add(train);
            return mapper.Map<TrainDTO>(newtrain);
        }

        public async Task<List<TrainDTO>> GetAll()
        {
            var dbTrains = await trainRepository.GetAll();

            List<TrainDTO> trains = new List<TrainDTO>();
            foreach(var item in dbTrains)
            {
                var train = mapper.Map<TrainDTO>(item);
                var dict = item.Carriages.GroupBy(x => x.Type).ToDictionary(x=>x.Key, x => x.Sum(g=> g.Seats.Where(q => q.Order == null).Count()));
                train.TypesPlace = dict;
                trains.Add(train);
            }
            return trains;
        }
        public async Task<FullTrainDTO> GetTrainById(int id)
        {
            var train = await this.trainRepository.GetById(id);
            var fullTrain = mapper.Map<FullTrainDTO>(train);

            return fullTrain;
        }
        public async Task DeleteTrain(int id)
        {
            var train = await this.trainRepository.GetById(id);
            if(train != null)
            {
                await trainRepository.Delete(train);
            }
        }
        public async Task<List<TrainDTO>> FindByKeyWord(string word)
        {
            var trains = await trainRepository.FindByKeyWord(word);
            var trainsDto = mapper.Map<List<TrainDTO>>(trains);
            return trainsDto;
        }
    }
}
