using System;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BooksController : ControllerBase
	{
		private readonly LibraryDbContext _dbContext;

		public BooksController(LibraryDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
		{
			return await _dbContext.Books.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Book>> AddBook(Book book)
		{
			_dbContext.Books.Add(book);
			await _dbContext.SaveChangesAsync();
			return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
		}

		[HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null) return NotFound();

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

