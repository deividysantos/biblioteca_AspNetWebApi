using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Data;
using biblioteca_AspNetWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_AspNetWebApi.Repository
{
    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(BibliotecaContext context) : base(context)
        {
        }

        public async Task<Client> GetByEmailAsync(string email)
        {
            Client client = await _context.Clients.FirstOrDefaultAsync(x => x.Email == email);

            if(client is null) return null;
            
            if(client.Email == email) return client;

            return null;
        }
    }
}