using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserChallenge.Models;

namespace UserChallenge.Data.DAL.Interfaces
{
    public interface IUser 
    {
        public IEnumerable<User> GetUsers();
        public Task Create(User user);
        public Task Edit(User user);
        public Task Delete(int? id);

        public User GetUserById(int? id);

    }
}
