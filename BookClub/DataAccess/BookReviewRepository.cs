using BookClub.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace BookClub.DataAccess
{
    public class BookReviewRepository
    {
        string _connectionString = "Server=localhost; Database=BookClubChallenge; Trusted_Connection=True;";

        public IEnumerable<BookReview> GetAllReviewsByBook (int GoodReadsBookId)
        {
            using (var db = new SqlConnection(_connectionString))
            {

            }
        }

        internal IEnumerable<BookReview> GetAllReviewsByUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
