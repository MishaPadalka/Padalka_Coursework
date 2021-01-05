using DAL.Context;
using DAL.Entities;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Common.Exceptions;

namespace DAL.Repository
{
    public class RailWayCarriageRepository : IRailWayCarriageRepository
    {
        private readonly RailwayContext context;
        public RailWayCarriageRepository(RailwayContext context)
        {
            this.context = context;
        }
        public async Task<RailwayCarriage> Add(RailwayCarriage railWayCarriage)
        {
            var carriage = await this.context.RailwayCarriages.AddAsync(railWayCarriage);
            await context.SaveChangesAsync();
    
            return carriage.Entity;
        }
        public async Task<RailwayCarriage> GetById(int id)
        {
            return await context.RailwayCarriages.Include(x=>x.Seats).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> GetNumberCarriage(int trainId)
        {
            var train = await context.RailwayCarriages.Where(x=>x.TrainId == trainId).ToListAsync();

            if(train.Count == 0)
            {
                return 1;
            }
            var max = train.Max(x => x.Number);
            return ++max;
        }
        public async Task DeleteCarriage(int id)
        {
            var carriage = await context.RailwayCarriages.Include(x=>x.Seats).ThenInclude(x=>x.Order).FirstOrDefaultAsync(x => x.Id == id);

            if(carriage.Seats.Any(x => x.Order != null))
            {
                throw new ExceptionDeletingCarriage();
            }
            context.RailwayCarriages.Remove(carriage);
            await context.SaveChangesAsync();
        }
    }
}
