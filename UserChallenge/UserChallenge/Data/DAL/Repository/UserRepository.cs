using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserChallenge.Data.Context;
using UserChallenge.Data.DAL.Interfaces;
using UserChallenge.Models;

namespace UserChallenge.Data.DAL.Repository
{
    public class UserRepository : IUser
    {
        private readonly UserChallengeDbContext _context;
        public UserRepository(UserChallengeDbContext context)
        {
            this._context = context;
        }
        public async Task Create(User user)
        {
            await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task Edit(User user)
        {
            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync();
            return;
        }


        public async Task Delete(int id)
        {
            var userToDelete = _context.Usuarios.Where(x => x.IdUsuario == id).First();
            _context.Usuarios.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return;
        }

        public User GetUserById(int? id)
        {
            return  _context.Usuarios.Where(x => x.IdUsuario == id).First();
        }

        public Task Dispose()
        {
            throw new NotImplementedException();
        }

       
    }
}
