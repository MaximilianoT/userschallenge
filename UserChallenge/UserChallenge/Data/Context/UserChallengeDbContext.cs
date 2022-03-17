using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserChallenge.Models;

namespace UserChallenge.Data.Context
{
    public class UserChallengeDbContext : DbContext
    {
        public UserChallengeDbContext(DbContextOptions<UserChallengeDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
