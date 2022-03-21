using NUnit.Framework;
using System.Threading.Tasks;

namespace UserTest
{
    public class Tests
    {
        
        //public Tests(UserChallenge.Data.Context.UserChallengeDbContext context)
        //{
        //    this._context = context;
        //}

        [SetUp]
        public void Setup()
        {

            UserChallenge.Data.Context.UserChallengeDbContext ctx;
            UserChallenge.Data.DAL.Repository.UserRepository userRepo = new UserChallenge.Data.DAL.Repository.UserRepository();
            UserChallenge.Models.User user = new UserChallenge.Models.User { Email = "", Nombre = "", Telefono = "123456", Username = "" };
        }

        [Test]
        public async Task AddUser()
        {
            try
            {
                //UserChallenge.Data.DAL.Repository.UserRepository userRepo = new UserChallenge.Data.DAL.Repository.UserRepository(_context);
                //UserChallenge.Models.User user = new UserChallenge.Models.User { Email = "", Nombre = "", Telefono = "123456", Username = "" };
                //await userRepo.Create(user);
            }
            catch (System.Exception)
            {

                throw;
            }
           
            
        }
    }
}