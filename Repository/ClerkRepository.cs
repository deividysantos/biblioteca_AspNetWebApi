using System.Linq;
using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Data;
using biblioteca_AspNetWebApi.Models;
using biblioteca_AspNetWebApi.Repository.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_AspNetWebApi.Repository
{
    public class ClerkRepository : BaseRepository<Clerk>, IClerkRepository
    {
        public ClerkRepository(BibliotecaContext _context) : base(_context)
        {
        }

        public async Task<Clerk> GetByEmailAsync(string email)
        {
            Clerk clerk = await _context.Clerks.FirstOrDefaultAsync(x => x.Email == email);

            if(clerk is null) return null;

            if(clerk.Email == email) return clerk;

            return null;
        }
    }
}