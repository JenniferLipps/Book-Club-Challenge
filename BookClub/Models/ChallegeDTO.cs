using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Models
{
    public class ChallengeDTO
    {
        public int ChalengeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<UserChallengeDTO> UsersInChallenge { get; set; }
    }
}
