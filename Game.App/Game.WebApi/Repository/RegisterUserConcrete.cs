using Game.WebApi.Context;
using Game.WebApi.Models;
using System.Linq;

namespace Game.WebApi.Repository
{
    public class RegisterUserConcrete:IRegisterUser
    {
        DBContext _context;
        public RegisterUserConcrete()
        {
            _context = new DBContext();
        }

        public void Add(RegisterUser registeruser)
        {
            _context.RegisterUser.Add(registeruser);
            _context.SaveChanges();
        }

        public string GetLoggedUserID(RegisterUser registeruser)
        {
            var usercount = (from User in _context.RegisterUser
                             where User.FullName == registeruser.FullName && User.Password == registeruser.Password
                             select User.MobileNo).FirstOrDefault();

            return usercount;
        }

        public bool ValidateRegisteredUser(RegisterUser registeruser)
        {
            var usercount = (from User in _context.RegisterUser
                             where User.MobileNo == registeruser.MobileNo && User.Password == registeruser.Password
                             select User).Count();
            if (usercount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateUsername(RegisterUser registeruser)
        {
            var usercount = (from User in _context.RegisterUser
                             where User.MobileNo == registeruser.MobileNo
                             select User).Count();
            if (usercount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}