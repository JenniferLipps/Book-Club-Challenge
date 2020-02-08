using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Models
{
    public class ChallengeUserData
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int ChallengeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
