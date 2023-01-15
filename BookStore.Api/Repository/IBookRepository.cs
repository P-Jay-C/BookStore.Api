
using BookStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStore.Api.Repository
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBooksAsync();
        public Task<BookModel> GetBookByIdAsync(int id);
        public Task<int> AddBookAsync(BookModel bookModel);

        public Task UpdateBookAsync(int id, BookModel bookModel);

        public Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel);

        public Task DeleteBookAsync(int bookId);
    }
}
