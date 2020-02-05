using BookClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using BookClub.Commands;

namespace BookClub.DataAccess
{
    public class BookRepository
    {
        string _connectionString = "Server=localhost; Database=BookClubChallenge; Trusted_Connection=True;";

        public IEnumerable<Book> GetAllBooks(int userId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var sql = @"select *
                            from [Book]
                            where UserId = @UserId";
                var parameters = new
                {
                    UserId = userId
                };
                var books = db.Query<Book>(sql, parameters);

                return books;
            }
        }

        public Book AddBook(AddBookCommand newBook)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();

                var sql = @"insert into [dbo].[Book]
	                        ([Title]
	                        ,[Author]
	                        ,[ImageURL]
	                        ,[GoodReadsBookId]
	                        ,[UserId]
	                        ,[DateCompleted]
	                        )
                           output inserted.*
                           values (
                            @title
                            ,@author
                            ,@imageURL
                            ,@goodReadsBookId
                            ,@userId
                            ,@dateCompleted)";

                return db.QueryFirst<Book>(sql, newBook);
            }
        }

    }
}
