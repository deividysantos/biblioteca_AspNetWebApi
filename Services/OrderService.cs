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
        private readonly ClientRepository _clientRepository;
        private readonly PunishmentRepository _punishmentRepository;

        public OrderService(OrderRepository orderRepository, ClientRepository clientRepository, PunishmentRepository punishmentRepository)
        {
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
            _punishmentRepository = punishmentRepository;
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

        public bool FitClient(int id)
        {
            var punishments =  _punishmentRepository.GetAllByClientId(id);
            var orders = _orderRepository.GetAllByIdClient(id);

            bool havePunishment = false;
            int quantityBooksRequest = 0;

            foreach (var item in punishments)
            {
                if(item.InitialDate.AddDays(7) > DateTime.Now) 
                    havePunishment = true;
            }

            foreach (var item in orders)
            {
                if(item.DeliveryDate == DateTime.UnixEpoch)
                    quantityBooksRequest += 1;
            }

            if(havePunishment == false && quantityBooksRequest <= 1) return true;

            return false;
        }
    }
}