using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Commands
{
    public class UpdateChallengeCommand
    {
        public IEnumerable<int> userIds { get; set; }
    }
}
