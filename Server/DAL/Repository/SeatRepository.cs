using DAL.Context;
using DAL.Entities;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SeatRepository : ISeatRepository
    {
        private readonly RailwayContext context;
        public SeatRepository(RailwayContext context)
        {
            this.context = context;
        }

        public async Task AddRange(IEnumerable<Seat> seats)
        {
            await context.AddRangeAsync(seats);
            await context.SaveChangesAsync();
        }
    }
}
