using biblioteca_AspNetWebApi.Data;
using biblioteca_AspNetWebApi.Models;

namespace biblioteca_AspNetWebApi.Repository
{
    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(BibliotecaContext context) : base(context)
        {
        }
    }
}