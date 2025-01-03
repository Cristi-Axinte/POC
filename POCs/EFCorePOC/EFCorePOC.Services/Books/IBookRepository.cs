﻿using EFCorePOC.Common.DTOs;
using EFCorePOC.Common.Entities;

namespace EFCorePOC.Services.Books
{
    public interface IBookRepository
    {
        public Task<Book> CreateBookAsync(Book book);

        public Task<IEnumerable<Book>> GetBooksAsync();

        public Task<IEnumerable<BookDTO>> GetBooksAsDtoDirectlyAsync();

        public Task<Book> GetBookById(string id);

        public Task<IEnumerable<Book>> GetPagedBooksAsync(int pageIndex, int pageSize);

        public Task<IEnumerable<Book>> SearchBookByCategoryAsync(string categoryName);

        public Task<IEnumerable<KeyValuePair<string, int>>> GetBookCountByCategoryAsync();

        public Task<Book> UpdateBook(Book book);

        public Task<bool> DeleteBookAsync(string id);

        public Task<bool> DeleteBookAsync(Book book);
    }
}
