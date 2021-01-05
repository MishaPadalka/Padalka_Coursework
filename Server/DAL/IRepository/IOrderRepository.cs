using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IOrderRepository
    {
        Task<Order> Add(Order order);
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
        Task Delete(Order order);
        Task Update(Order order);
        Task<List<Order>> FindByDate(DateTime date);
    }
}
