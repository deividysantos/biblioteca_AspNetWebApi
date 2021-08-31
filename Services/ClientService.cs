using System;
using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Models;
using biblioteca_AspNetWebApi.Repository;

namespace biblioteca_AspNetWebApi.Services
{
    public class ClientService
    {
        private ClientRepository _clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> AddAsync(Client cliente)
        {
            if(await _clientRepository.CreateAsync(cliente)) return true;

            return false;
        }

        public async Task<bool> UpdateAsync(Client client, int id)
        {
            if(await _clientRepository.UpdateAsync(client, id)) return true;

            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if(await _clientRepository.DeleteAsync(id)) return true;

            return false;
        }

        public async Task<bool> ExistingEmailAsync(string email) 
        {
            Client client = await _clientRepository.GetByEmailAsync(email);

            if(client.Email is null) return false;

            return true;
        }
    }
}