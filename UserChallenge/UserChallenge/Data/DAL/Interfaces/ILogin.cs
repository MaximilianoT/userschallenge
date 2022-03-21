using System.Threading.Tasks;

namespace UserChallenge.Data.DAL.Interfaces
{
    public interface ILogin
    {
        Task<bool> GetUserLogin(UserChallenge.Models.UserLogin userLogin);
    }
}
