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
    public class OrderRepository: IOrderRepository
    {
        private readonly RailwayContext context;
        public OrderRepository(RailwayContext context)
        {
            this.context = context;
        }
        public async Task<Order> Add(Order order)
        {
            var neworder = await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            return neworder.Entity;
        }
        public async Task<List<Order>> GetAll()
        {
            return await context.Orders.Include(x => x.Seat).ThenInclude(x => x.RailwayCarriage).ThenInclude(x => x.Train).ToListAsync();
        }
        public async Task<Order> GetById(int id)
        {
            return await context.Orders.Include(x => x.Seat).ThenInclude(x => x.RailwayCarriage).ThenInclude(x => x.Train).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Delete(Order order)
        {
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }
        public async Task Update(Order order)
        {
            context.Update(order);
            await context.SaveChangesAsync();
        }
        public async Task<List<Order>> FindByDate(DateTime date)
        {
            return await context.Orders.Include(x => x.Seat).ThenInclude(x => x.RailwayCarriage).ThenInclude(x => x.Train).Where(x => x.OrderDate.Year == date.Year && x.OrderDate.Month == date.Month && x.OrderDate.Day == date.Day).ToListAsync();
        }
    }
}
