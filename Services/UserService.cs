
using System;
using System.Linq;
using System.Threading.Tasks;
using secretsVaul.Models;

namespace secretsVaul.Services
{
    public class UserService : IUserService
    {
        private Fetch fetch = new Fetch();
        private DataContext db = new DataContext();
        private ITokenService token = new TokenService();
        
        public Task<Person> GetHumanData(string uid){
            Guid _uid = Guid.Parse(uid);
            Person human = db.People.Where( u => u.UserId.Equals(_uid)).FirstOrDefault();
            
            return Task.FromResult(human);
        }
        public Task<bool> IsSigned(string _token)
        {
            Token validToken = token.ValidateToken(_token);
            Console.WriteLine(validToken.message);
            bool isValid = validToken.status? true : false ;
            return Task.FromResult(isValid);
        }

        public Task<UserSession> SignIn(User user)
        {
            User userSigned = new User();
            userSigned = db.Users
            .Where(u => u.Document.Equals(user.Document))
            .FirstOrDefault();
            bool validPassword = BCrypt.Net.BCrypt.Verify(user.Password, userSigned.Password);

            UserSession newSession;

            if(validPassword){
            newSession = new UserSession{
                userId = userSigned.Id,
                token = token.CreateToken(userSigned.Id)
            };

            }else{
                newSession = new UserSession{
                    error = "Usuario No Registrado"
                };
            }

            return Task.FromResult(newSession);
        }

        public async Task<UserSession> SignUp(User nUser)
        {
            nUser.Password = EncryptPassword(nUser.Password);
            Person UserData = await fetch.GetDataByDocument(nUser);
            //string hasToken = token.CreateToken(nUser);
            UserSession session = new UserSession{
                userId = UserData.UserId,
                token = token.CreateToken(nUser.Id)
            };

            //guardar en base de datos
            db.Users.Add(nUser);
            db.People.Add(UserData);
            db.SaveChanges();

            return await Task.FromResult(session);
        }

        private string EncryptPassword (string pass){
            return BCrypt.Net.BCrypt.HashPassword(pass);
        }


    }

    public class UserSession {
        public Guid userId {get; set;}
        public string token {get; set;}
        public string error {get; set;}
    }
}

