using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Models;

namespace biblioteca_AspNetWebApi.Repository.RepositoryInterfaces
{
    public interface IClerkRepository  : IBaseRepository<Clerk>
    {
        Task<Clerk> GetByEmailAsync(string email);
    }
}