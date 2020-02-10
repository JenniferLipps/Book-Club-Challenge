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
                var sql = @"select b.Title, br.Review, br.UserId, u.FirstName
                            from BookReview br
                            join Book b on b.GoodReadsBookId = br.GoodReadsBookId
                            join [User] u on u.Id = br.UserId
                            where b.GoodReadsBookId = @GoodReadsBookId";

                var parameters = new
                {
                    GoodReadsBookId = GoodReadsBookId
                };

                var allReviews = db.Query<BookReview>(sql, parameters);

                return allReviews;

            }
        }

        internal IEnumerable<BookReview> GetAllReviewsByUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
