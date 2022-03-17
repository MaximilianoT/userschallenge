using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserChallenge.Data.Context;
using UserChallenge.Models;

namespace UserChallenge.Controllers
{
    public class UserController : Controller
    {
        private readonly UserChallengeDbContext _context;
        public UserController(UserChallengeDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<User> usuarios = _context.Users;
            return View();
        }

    }
}
