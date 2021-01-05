using AutoMapper;
using BLL.Interfaces;
using Common.DTO.Orders;
using Common.DTO.Seats;
using DAL.Entities;
using DAL.IRepository;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;
        private readonly ITrainRepository trainRepository;
        public OrderService(IOrderRepository orderRepository, IMapper mapper, ITrainRepository trainRepository)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.trainRepository = trainRepository;
        }
        public async Task Add(NewOrder newOrder)
        {
            var order = mapper.Map<Order>(newOrder);
            order.OrderDate = DateTime.Now;

            var neworder = await orderRepository.Add(order);
            var newOrderTrain = await this.orderRepository.GetById(neworder.Id);
            var train = newOrderTrain.Seat.RailwayCarriage.Train;
            train.OccupiedPlaces = train.OccupiedPlaces + 1;
            train.FreePlaces = train.FreePlaces - 1;
            await trainRepository.Update(train);
        }
        public async Task<List<OrderDTO>> GetAll()
        {
            var orders = await orderRepository.GetAll();
            return mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetById(int id)
        {
            var orderDTO = await orderRepository.GetById(id);
            var order = mapper.Map<OrderDTO>(orderDTO);
            return order;
        }
        public async Task Delete(int id)
        {
            var order = await orderRepository.GetById(id);
            if(order != null)
            {
                await orderRepository.Delete(order);
            }
        }

        public async Task Update(UpdateOrder updateOrder)
        {
            var order = await orderRepository.GetById(updateOrder.Id);
            if( order != null)
            {
                order.BuyerFirstName = updateOrder.FirstName;
                order.BuyerLastName = updateOrder.LastName;
                await orderRepository.Update(order);
            }
        }
        public async Task<List<OrderDTO>> FindByDate(DateTime date)
        {
            var dbOrders = await orderRepository.FindByDate(date);
            var orders = mapper.Map<List<OrderDTO>>(dbOrders);
            return orders;
        }
    }
}
