using Common.DTO.Trains;
using DAL.Context;
using DAL.Entities;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class TrainRepository : ITrainRepository
    {
        private readonly RailwayContext context;
        public TrainRepository(RailwayContext context)
        {
            this.context = context;
        }

        public async Task<Train> Add(Train train)
        {
            var newtrain = await context.Trains.AddAsync(train);
            await context.SaveChangesAsync();
            return newtrain.Entity;
        }

        public async Task Delete(Train train)
        {
            context.Remove(train);
            await context.SaveChangesAsync();
        }

        public async Task<List<Train>> GetAll()
        {
            return await context.Trains.Include(x=>x.Carriages).ThenInclude(g=> g.Seats).ThenInclude(x => x.Order).ToListAsync();
        }

        public async Task<Train> GetById(int id)
        {
            return await context.Trains.Include(x=>x.Carriages).ThenInclude(g => g.Seats).ThenInclude(g=>g.Order).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Train train)
        {
            context.Trains.Update(train);
            await context.SaveChangesAsync();
        }
        public async Task<List<Train>> FindByKeyWord(string word)
        {
            var TrainByName = await context.Trains.Where(x => x.Name.Contains(word)).ToListAsync();
            var TrainByDestination = await context.Trains.Where(x => x.WhereGoes.Contains(word)).ToListAsync();
            var TrainByDeparture = await context.Trains.Where(x => x.WhereFrom.Contains(word)).ToListAsync();
            return TrainByName.Concat(TrainByDeparture).Concat(TrainByDestination).ToList();
        }
    }
}
