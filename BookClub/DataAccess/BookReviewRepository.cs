using BookClub.Models;
using BookClub.Commands;
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

        public IEnumerable<BookReviewDTO> GetAllReviewsByBook (int GoodReadsBookId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select b.Title, br.Review, br.UserId, u.FirstName, u.LastName
                            from BookReview br
                            join Book b on b.GoodReadsBookId = br.GoodReadsBookId
                            join [User] u on u.Id = br.UserId
                            where b.GoodReadsBookId = @GoodReadsBookId";

                var parameters = new
                {
                    GoodReadsBookId = GoodReadsBookId
                };

                var allReviews = db.Query<BookReviewDTO>(sql, parameters);

                return allReviews;

            }
        }

        public IEnumerable<BookReviewDTO> GetAllReviewsByUser(int UserId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select b.Title, br.Review, br.UserId, u.FirstName, u.LastName
	                        from BookReview br
	                        join Book b on b.GoodReadsBookId = br.GoodReadsBookId
	                        join [User] u on u.Id = br.UserId
	                        where u.Id = @userId;";

                var parameters = new
                {
                    userId = UserId
                };

                var allReviewsByAUser = db.Query<BookReviewDTO>(sql, parameters);

                return allReviewsByAUser;

            }
        }

        public BookReviewDTO GetUserReviewForBook(int UserId, int BookId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select b.Title, br.Review, br.UserId, u.FirstName, u.LastName, b.Id
	                        from BookReview br
	                        join [User] u on u.Id = br.UserId
	                        join Book b on b.Id = br.BookId
	                        where u.Id = @userId and br.BookId = @bookId";

                var parameters = new
                {
                    userId = UserId,
                    bookId = BookId
                };

                var userReviewForSingleBook = db.QueryFirstOrDefault<BookReviewDTO>(sql, parameters);

                return userReviewForSingleBook;
            }
        }

        public BookReview AddBookReview(AddBookReviewCommand newReview)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"insert into [dbo].[BookReview]
	                        ([Review]
	                        ,[Rating]
	                        ,[BookId]
	                        ,[UserId]
	                        ,[GoodReadsBookId])
                            output inserted.*
                            values (
                            @Review
                            ,@Rating
                            ,@BookId
                            ,@UserId
                            ,@GoodReadsBookId)";

                return db.QueryFirst<BookReview>(sql, newReview);
            }
        }
    }
}
