using System.Threading.Tasks;
using secretsVaul.Models;

namespace secretsVaul.Services
{
    public interface IUserService {
        Task<UserSession> SignUp(User nUser);
        Task<UserSession> SignIn(User user);
        Task<bool> IsSigned(string token);
        Task<Person> GetHumanData(string uid);
    }
}