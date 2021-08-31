using biblioteca_AspNetWebApi.Data;
using biblioteca_AspNetWebApi.Models;

namespace biblioteca_AspNetWebApi.Repository
{
    public class PunishmentRepository : BaseRepository<Punishment>
    {
        public PunishmentRepository(BibliotecaContext _context) : base(_context)
        {
        }
    }
}