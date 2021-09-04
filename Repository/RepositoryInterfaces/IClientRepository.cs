using System;
using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Models;

namespace biblioteca_AspNetWebApi.Repository.RepositoryInterfaces
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<Client> GetByEmailAsync(string email);
    }
}