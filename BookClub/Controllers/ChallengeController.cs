using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClub.Commands;
using BookClub.DataAccess;
using BookClub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddChallenge(AddChallengeCommand addChallengeCommand)
        {
            //create Challenge
            var repo = new ChallengeRepository();
            var startDate = DateTime.Now;
            var endDate = DateTime.Now;
            var newChallenge = repo.AddChallenge(startDate, endDate);

            //add users to Challenge
            foreach (var userId in addChallengeCommand.userIds)
            {
                repo.AddUserToChallenge(addChallengeCommand.creatorId, userId, newChallenge.Id);

            }

            return Ok();
        }

        [HttpGet("{userId}")]
        public IEnumerable<Challenge> GetChallengesByUser(int userId)
        {
            var repo = new ChallengeRepository();
            return repo.GetChallengesByUser(userId);
        }

        [HttpPost("{userId}/{challengeId}")]
        public IActionResult AddUserToChallenge(int userId, int challengeId)
        {
            throw new NotImplementedException();
        }
    }
}