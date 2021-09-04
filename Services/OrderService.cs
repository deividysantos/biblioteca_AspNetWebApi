using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Models;
using biblioteca_AspNetWebApi.Repository.RepositoryInterfaces;

namespace biblioteca_AspNetWebApi.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IPunishmentRepository _punishmentRepository;

        public OrderService(IOrderRepository orderRepository, 
                            IClientRepository clientRepository, 
                            IPunishmentRepository punishmentRepository)
        {
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
            _punishmentRepository = punishmentRepository;
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<bool> Add(Order order)
        {
            return await _orderRepository.CreateAsync(order);
        }

        public async Task<bool> UpdateAsync(Order order, Guid id)
        {
            return await _orderRepository.UpdateAsync(order, id);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _orderRepository.DeleteAsync(id);
        }

        public IEnumerable<Order> GetAllByIdClient(Guid id)
        {
            return _orderRepository.GetAllByIdClient(id);
        }

        public bool FitClient(Guid id)
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

        public async Task<bool> Inactivate(Guid id)
        {
            return await _orderRepository.Inactivate(id);
        }
    }
}