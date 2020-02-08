using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BookClub.Models;
using Dapper;

namespace BookClub.DataAccess
{
    public class ChallengeRepository
    {
        string _connectionString = "Server=localhost; Database=BookClubChallenge; Trusted_Connection=True;";

        public Challenge AddChallenge(DateTime startDate, DateTime endDate)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"insert into [dbo].[Challenge]
	                        ([StartDate]
	                        ,[EndDate]
	                        )
                            output inserted.*
                            values (
                            @startDate
                            ,@endDate)";

                var parameters = new
                {
                    StartDate = startDate,
                    EndDate = endDate
                };

                var newChallenge = db.QueryFirst<Challenge>(sql, parameters);

                return newChallenge;
            }
        }

        internal void AddUserToChallenge(int creatorId, int userId, int challengeId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"insert into [dbo].[UserChallenge]
                            ([ChallengeId]
                            ,[UserId])
                            values
                            (@challengeId
                            ,@userId)";

                var parameters = new
                {
                    ChallengeId = challengeId,
                    UserId = userId
                };


                db.Execute(sql, parameters);
            }
        }

        internal void AddUserToExistingChallenge(int challengeId, int userId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"insert into [dbo].[UserChallenge]
                            ([ChallengeId]
                            ,[UserId])
                            values
                            (@challengeId
                            ,@userId)";

                var parameters = new
                {
                    ChallengeId = challengeId,
                    UserId = userId
                };

                db.Execute(sql, parameters);
            }
        }

        public IEnumerable<int> GetChallengeIdsByUser(int userId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"
                    select c.Id from Challenge as c
                    join UserChallenge as uc on c.Id = uc.ChallengeId
                    where uc.UserId = @UserId";

                var parameters = new
                {
                    UserId = userId
                };

                var userBooksForAllChallenge = db.Query<int>(sql, parameters);

                return userBooksForAllChallenge;
            }
        }

        public ChallengeDTO GetChallege(int challengeId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select u.Id as UserId, u.FirstName, u.LastName, b.Title, uc.ChallengeId, c.StartDate, c.EndDate
                                from UserChallenge uc
                                join [User] u on u.Id = uc.UserId
                                join Book b on b.UserId = uc.UserId
                                join Challenge c on c.Id = uc.ChallengeId
                                where uc.ChallengeId = @ChallengeId;";

                var parameters = new
                {
                    ChallengeId = challengeId
                };

                var allChallengeBooks = db.Query<ChallengeUserData>(sql, parameters);

                var listOfUsers = new List<UserChallengeDTO>();

                foreach (var challengeBook in allChallengeBooks)
                {
                    var userChallenge = listOfUsers.Where(u => u.UserId == challengeBook.UserId).SingleOrDefault();

                    if (userChallenge == null)
                    {
                        listOfUsers.Add(new UserChallengeDTO
                        {
                            UserId = challengeBook.UserId,
                            FirstName = challengeBook.FirstName,
                            LastName = challengeBook.LastName,
                            BooksCompleted = 1
                        });
                        continue;
                    }

                    userChallenge.BooksCompleted += 1;

                    //if (listOfUsers.Any(user => user.UserId == challengeBook.UserId))
                    //{
                    //    var userChallenge = listOfUsers.Where(u => u.UserId == challengeBook.UserId).SingleOrDefault();
                    //    userChallenge.BooksCompleted += 1;
                    //} else
                    //{
                    //    listOfUsers.Add(new UserChallengeDTO
                    //    {
                    //        UserId = challengeBook.UserId,
                    //        FirstName = challengeBook.FirstName,
                    //        LastName = challengeBook.LastName,
                    //        BooksCompleted = 1
                    //    });
                    //}
                }

                var challengeData = allChallengeBooks.First();

                var challengeDTO = new ChallengeDTO()
                {
                    ChalengeId = challengeData.ChallengeId,
                    StartDate = challengeData.StartDate,
                    EndDate = challengeData.EndDate,
                    UsersInChallenge = listOfUsers
                };

                return challengeDTO;
            }
        }
    }
}
