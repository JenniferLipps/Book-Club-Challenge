using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClub.DataAccess;
using BookClub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            var repo = new UserRepository();
            return repo.GetAllUsers();
        }
    }
}