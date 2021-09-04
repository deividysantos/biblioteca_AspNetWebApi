using System;
using System.Threading.Tasks;
using biblioteca_AspNetWebApi.Models;
using biblioteca_AspNetWebApi.Models.ViewModels;
using biblioteca_AspNetWebApi.Repository.RepositoryInterfaces;

namespace biblioteca_AspNetWebApi.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookrepository;

        public BookService(IBookRepository bookrepository)
        {
            _bookrepository = bookrepository;
        }

        public bool Equal(BookViewModel bookViewModel)
        {
            var books = _bookrepository.GetByName(bookViewModel.Name);
            foreach (var item in books)
            {
                if(item.Author == bookViewModel.Author || item.Edition == bookViewModel.Edition)
                    return true;
            }         

            return false;
        }
        public async Task<bool> Add(Book book)
        {
            return await _bookrepository.CreateAsync(book);
        }
        public async Task<bool> Update(Book book, Guid id)
        {
            return await _bookrepository.UpdateAsync(book, id);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _bookrepository.DeleteAsync(id);
        }
        
        public async Task<bool> Inactivate(Guid id)
        {
            return await _bookrepository.Inactivate(id);
        }
        
    }
}