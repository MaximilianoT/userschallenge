using UserChallenge.Data.Context;
using UserChallenge.Data.DAL.Interfaces;
using UserChallenge.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace UserChallenge.Data.DAL.Repository
{
    public class LoginRepository : ILogin
    {
        private readonly UserChallengeDbContext _context;
        public LoginRepository(UserChallengeDbContext context)
        {
            this._context = context;
        }
        public Task<bool> GetUserLogin(UserLogin user)
        {
            try
            {
                var loginUser = _context.Usuarios.FindAsync(_context.Usuarios.Where(x=> x.Username == user._username && x.Password == user._password).First().IdUsuario);
                return Task.FromResult(true);
                
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }
}
