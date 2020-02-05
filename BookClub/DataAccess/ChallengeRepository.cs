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

        public IEnumerable<Challenge> GetChallengesByUser(int userId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select * from [UserChallenge] where UserId = @userid";

                var parameters = new
                {
                    UserId = userId
                };

                var challenges = db.Query<Challenge>(sql, parameters);

                return challenges;
            }
        }

    }
}
