using BookClub.Models;
using Goodreads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodReadsAPIController : ControllerBase
    {
        [HttpGet("{isbn}")]
        public async Task<ActionResult<IEnumerable<string>>> Get(string isbn)
        {
            const string apiKey = "hG8Baz6PR4BYmKheAD3qg";
            const string apiSecret = "0nyS2sEH9JKSWil0j5xOBdcB6BzLmxscoo8yAIk";

            var client = GoodreadsClient.Create(apiKey, apiSecret);

            var book = await client.Books.GetByIsbn(isbn);

            return Ok(book);
        }

        [HttpGet("search/{title}")]
        public async Task<List<GoodReadsBookDTO>> SearchByTitle(string title)
        {
            const string apiKey = "hG8Baz6PR4BYmKheAD3qg";
            const string apiSecret = "0nyS2sEH9JKSWil0j5xOBdcB6BzLmxscoo8yAIk";

            var client = GoodreadsClient.Create(apiKey, apiSecret);

            var books = await client.Books.Search(title, 1, Goodreads.Models.Request.BookSearchField.Title);

            var goodReadsBooks = new List<GoodReadsBookDTO>();

            foreach (var book in books.List)
            {
                var goodReadsBook = new GoodReadsBookDTO()
                {
                    Author = book.BestBook.AuthorName,
                    Title = book.BestBook.Title,
                    ImageURL = book.BestBook.ImageUrl,
                    GoodReadsBookId = book.BestBook.Id
                };

                goodReadsBooks.Add(goodReadsBook);
            }

            return goodReadsBooks;
        }
    }
}