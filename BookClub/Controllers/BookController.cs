using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClub.Commands;
using BookClub.DataAccess;
using BookClub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookClub.Controllers
{
    [Route("book/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet("user/{userId}")]
        public IEnumerable<Book> GetBooks(int userId)
        {
            var repo = new BookRepository();
            return repo.GetAllBooks(userId);
        }

        [HttpGet("{bookId}")]
        public Book GetSingleBook(int bookId)
        {
            var repo = new BookRepository();
            return repo.GetSingleBook(bookId);
        }

        [HttpPost]
        public IActionResult AddBook(AddBookCommand newBook)
        {
            var repo = new BookRepository();
            var bookAdded = repo.AddBook(newBook);
            if (bookAdded != null)
            {
                return Ok(newBook);
            }
            return BadRequest($"Unable to add book with title: {newBook.Title}.");
        }
    }
}