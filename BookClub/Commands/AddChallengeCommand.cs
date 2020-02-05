using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Commands
{
    public class AddChallengeCommand
    {
        public IEnumerable<int> userIds { get; set; }
        public int creatorId { get; set; }
    }
}
