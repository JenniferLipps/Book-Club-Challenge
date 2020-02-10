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
        [HttpGet("{goodReadsBookId}")]
        public IEnumerable<BookReview> GetAllReviewsByBook (int goodReadsBookId)
        {
            var repo = new BookReviewRepository();
            return repo.GetAllReviewsByBook(goodReadsBookId);
        }

        [HttpGet("{UserId}")]
        public IEnumerable<BookReview> GetAllReviewsByUser (int UserId)
        {
            var repo = new BookReviewRepository();
            return repo.GetAllReviewsByUser(UserId);
        }
    }
}