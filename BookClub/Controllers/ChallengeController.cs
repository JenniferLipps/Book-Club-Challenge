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
    [Route("api/challenge")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddChallenge(AddChallengeCommand addChallengeCommand)
        {
            //create Challenge
            var repo = new ChallengeRepository();
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddMonths(1);
            var newChallenge = repo.AddChallenge(startDate, endDate, addChallengeCommand.creatorId);

            var usersToAdd = addChallengeCommand.userIds.Distinct().ToList();

            if (!usersToAdd.Contains(addChallengeCommand.creatorId))
            {
                usersToAdd.Add(addChallengeCommand.creatorId);
            } 

            //add users to Challenge
            foreach (var userId in usersToAdd)
            {
                repo.AddUserToChallenge(newChallenge.Id, userId);
            }


            return Ok();
        }

        [HttpGet("user/{userId}")]
        public IEnumerable<ChallengeDTO> GetChallengesByUser(int userId)
        {
            var repo = new ChallengeRepository();
            var challengeIds = repo.GetChallengeIdsByUser(userId);
            var myChallenges = new List<ChallengeDTO>();
            foreach (var challengeId in challengeIds)
            {
                var challenge = repo.GetChallege(challengeId);
                myChallenges.Add(challenge);
            }

            return myChallenges;
        }

        [HttpGet("{challengeId}")]
        public ChallengeDTO GetChallenge(int challengeId)
        {
            var repo = new ChallengeRepository();
            return repo.GetChallege(challengeId);
        }

       /*[HttpPost("{challengeId}")]
        public IActionResult AddUserToExistingChallenge(UpdateChallengeCommand updateChallengeCommand, int challengeId)
        {

            var repo = new ChallengeRepository();
            foreach (var userId in updateChallengeCommand.userIds)
            {
                repo.AddUserToChallenge(challengeId, userId);
            }
        }*/
    }
}