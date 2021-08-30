using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Data;
using biblioteca_AspNetWebApi.Models;

namespace biblioteca_AspNetWebApi.Repository
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(BibliotecaContext _context) : base(_context)
        {
        }

        public List<Book> GetByName(string name)
        {
            var book = _context.Books.Where(x => x.Name == name).ToList();

            return book;
        }
    }
}