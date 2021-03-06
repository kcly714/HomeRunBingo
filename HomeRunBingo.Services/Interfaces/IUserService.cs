using HomeRunBingo.Models.Domain;
using HomeRunBingo.Models.Requests;

namespace HomeRunBingo.Services
{
    public interface IUserService
    {
        //int Create(object userModel);
        //IUserAuthData LogIn(string email, string password);
        //bool LogInTest(string email, string password, int id, string[] roles = null);
        //bool LogOut();

        // string GetSalt(string email);
        int CreateUser(RegisterAddRequest registerAddRequest);
        bool UserLogIn(LoginRequest loginRequest);
        UserBase UserLogInWithHash(string email, string passwordHash);
        string UserSelectById(int id);
        //UserBase LoginMapper(IDataReader reader);
    }
}
