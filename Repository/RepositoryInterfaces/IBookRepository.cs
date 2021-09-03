using System.Collections.Generic;
using biblioteca_AspNetWebApi.Models;

namespace biblioteca_AspNetWebApi.Repository.RepositoryInterfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        List<Book> GetByName(string name);
    }
}