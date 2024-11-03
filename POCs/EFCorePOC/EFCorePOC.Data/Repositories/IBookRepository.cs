﻿using EFCorePOC.Common.Entities;

namespace EFCorePOC.Data.Repositories
{
    public interface IBookRepository
    {
        public Task<Book> CreateBookAsync(Book book);

        public Task<IEnumerable<Book>> GetBooksAsync();
        
        public Task<Book> UpdateBook(Book book);

        public Task<bool> DeleteBookAsync(string id);

        public Task<bool> DeleteBookAsync(Book book);
    }
}
