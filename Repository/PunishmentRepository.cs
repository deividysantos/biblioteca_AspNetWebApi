using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Data;
using biblioteca_AspNetWebApi.Models;

namespace biblioteca_AspNetWebApi.Repository
{
    public class PunishmentRepository : BaseRepository<Punishment>
    {
        public PunishmentRepository(BibliotecaContext _context) : base(_context)
        {
        }

        public IEnumerable<Punishment> GetAllByClientId(int id)
        {
            var entities = _context.Punishments.Where(x => x.IdClient == id);

            return entities;
        }
    }
}