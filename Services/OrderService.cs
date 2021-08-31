using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Models;
using biblioteca_AspNetWebApi.Repository;

namespace biblioteca_AspNetWebApi.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<bool> Add(Order order)
        {
            return await _orderRepository.CreateAsync(order);
        }

        public async Task<bool> UpdateAsync(Order order, int id)
        {
            return await _orderRepository.UpdateAsync(order, id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _orderRepository.DeleteAsync(id);
        }

        public IEnumerable<Order> GetAllByIdClient(int id)
        {
            return _orderRepository.GetAllByIdClient(id);
        }
    }
}