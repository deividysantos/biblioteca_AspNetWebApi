using System;
using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Models;
using biblioteca_AspNetWebApi.Repository.RepositoryInterfaces;

namespace biblioteca_AspNetWebApi.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> GetById(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            return client;
        }

        public async Task<bool> AddAsync(Client cliente)
        {
            if(await _clientRepository.CreateAsync(cliente)) return true;

            return false;
        }

        public async Task<bool> UpdateAsync(Client client, Guid id)
        {
            if(await _clientRepository.UpdateAsync(client, id)) return true;

            return false;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if(await _clientRepository.DeleteAsync(id)) return true;

            return false;
        }

        public async Task<bool> ExistingEmailAsync(string email) 
        {
            Client client = await _clientRepository.GetByEmailAsync(email);

            if(client is null) return false;

            return true;
        }
    }
}