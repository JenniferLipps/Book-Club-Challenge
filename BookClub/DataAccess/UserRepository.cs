using BookClub.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.DataAccess
{
    public class UserRepository
    {
        string _connectionString = "Server=localhost; Database=BookClubChallenge; Trusted_Connection=True;";

        public IEnumerable<User> GetAllUsers ()
        {
            using (var db = new SqlConnection(_connectionString))
            {                
                var sql = @"select *
                            from [User]";
                            
              
                var users = db.Query<User>(sql);

                return users;
            }
        }
    }
}
