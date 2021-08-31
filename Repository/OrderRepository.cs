using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Data;
using biblioteca_AspNetWebApi.Models;

namespace biblioteca_AspNetWebApi.Repository
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(BibliotecaContext _context) : base(_context)
        {
        }

        public IEnumerable<Order> GetAllByIdClient(int id)
        {
            var entities = _context.Orders.Where(x => x.IdClient == id);

            return entities;
        }
    }
}