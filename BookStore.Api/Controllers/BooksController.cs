using AutoMapper;
using BookStore.Api.Data;
using BookStore.Api.Models;
using BookStore.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookRepository.GetAllBooksAsync();
             
            return Ok(books);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await bookRepository.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel bookModel)
        {
            var id = await bookRepository.AddBookAsync(bookModel);


            return CreatedAtAction(nameof(GetBookById), new {id = id, controller="books"},id);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookModel,[FromRoute] int id)
        {
            await bookRepository.UpdateBookAsync(id, bookModel);
            
            return Ok();

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument bookModel,[FromRoute] int id)
        {
            await bookRepository.UpdateBookPatchAsync(id, bookModel);
            
            return Ok();

        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int bookId)
        {
            await bookRepository.DeleteBookAsync(bookId);
            
            return Ok();

        }

       
    }
}
