using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public interface IUserManager
    {
        User? Login(string username, string password);
    }

    public class UserManager : IUserManager
    {
        public User? Login(string username, string password)
        {
            var crud = new UserCrud();
            return crud.Login(username, password);
        }
    }
}