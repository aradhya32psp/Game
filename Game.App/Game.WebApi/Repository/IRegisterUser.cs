using Game.WebApi.Models;

namespace Game.WebApi.Repository
{
    public interface IRegisterUser
    {
        void Add(RegisterUser registeruser);
        bool ValidateRegisteredUser(RegisterUser registeruser);
        bool ValidateUsername(RegisterUser registeruser);
        string GetLoggedUserID(RegisterUser registeruser);
    }
}
