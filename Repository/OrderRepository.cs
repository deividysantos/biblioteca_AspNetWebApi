using biblioteca_AspNetWebApi.Data;
using biblioteca_AspNetWebApi.Models;

namespace biblioteca_AspNetWebApi.Repository
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(BibliotecaContext _context) : base(_context)
        {
        }
    }
}