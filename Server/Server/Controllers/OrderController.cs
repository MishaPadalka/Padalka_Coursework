using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Common.DTO.Orders;
using Common.DTO.Seats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public void Add(NewOrder newOrder)
        {
             orderService.Add(newOrder);
        }
        [HttpGet]
        public async Task<List<OrderDTO>> GetAll()
        {
            return await orderService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<OrderDTO> GetById(int id)
        {
            return await orderService.GetById(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await orderService.Delete(id);
        }
        [HttpPut]
        public async Task Update(UpdateOrder updateOrder)
        {
            await orderService.Update(updateOrder);
        }
        [HttpPost("search")]
        public async Task<List<OrderDTO>> FindByDate([FromBody]DateTime date)
        {
            return await orderService.FindByDate(date);
        }
    }
}