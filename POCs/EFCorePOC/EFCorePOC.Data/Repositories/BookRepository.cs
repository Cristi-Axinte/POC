using EFCorePOC.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePOC.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public Task<Book> CreateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBookAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
