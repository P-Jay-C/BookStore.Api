using AutoMapper; 
using BookStore.Api.Data;
using BookStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync( )
        {
            var result = await _context.Books.ToListAsync();

            return _mapper.Map<List<BookModel>>(result);
        }

        public async Task<BookModel> GetBookByIdAsync(int id)
        {

            //    var result = await _context.Books.Where(x => x.id == id).Select(x => new BookModel()
            //    {
            //        description = x.description,
            //        id = x.id,
            //        title = x.title 
            //    }).FirstOrDefaultAsync();

            //    return result;

            var book = await _context.Books.FindAsync(id);

            return _mapper.Map<BookModel>(book);

        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                title = bookModel.title,
                description = bookModel.description,
            };

            _context.Add(book);
            await _context.SaveChangesAsync();

            return book.id;
        }

        public async Task UpdateBookAsync(int id, BookModel bookModel)
        {
            //var book = await _context.Books.FindAsync(id);

            //if (book != null)
            //{
            //    book.title = bookModel.title;
            //    book.description = bookModel.description;

            //    await _context.SaveChangesAsync();
            //}

            var book = new Books()
            {
                id = id,
                title = bookModel.title,
                description = bookModel.description
            };

            _context.Update(book);
            await _context.SaveChangesAsync();      
            
        }

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {

            var book = new Books()
            {
                id = bookId
            };

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

        }


    }
}

