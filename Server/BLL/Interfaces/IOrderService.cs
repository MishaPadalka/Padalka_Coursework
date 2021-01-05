using Common.DTO.Orders;
using Common.DTO.Seats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        Task Add(NewOrder newOrder);
        Task<List<OrderDTO>> GetAll();
        Task<OrderDTO> GetById(int id);
        Task Delete(int id);
        Task Update(UpdateOrder updateOrder);
        Task<List<OrderDTO>> FindByDate(DateTime date);
    }
}
