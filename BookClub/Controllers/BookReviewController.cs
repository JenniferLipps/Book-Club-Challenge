using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClub.Models;
using BookClub.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookClub.Controllers
{
    [Route("api/bookreview")]
    [ApiController]
    public class BookReviewController : ControllerBase
    {
        [HttpGet("book/{goodReadsBookId}")]
        public IEnumerable<BookReviewDTO> GetAllReviewsByBook (int goodReadsBookId)
        {
            var repo = new BookReviewRepository();
            return repo.GetAllReviewsByBook(goodReadsBookId);
        }

        [HttpGet("user/{UserId}")]
        public IEnumerable<BookReviewDTO> GetAllReviewsByUser (int UserId)
        {
            var repo = new BookReviewRepository();
            return repo.GetAllReviewsByUser(UserId);
        }

        [HttpGet("review/{UserId}/{BookId}")]
        public BookReviewDTO GetUserReviewForBook (int UserId, int BookId)
        {
            var repo = new BookReviewRepository();
            return repo.GetUserReviewForBook(UserId, BookId);
        }

    }
}