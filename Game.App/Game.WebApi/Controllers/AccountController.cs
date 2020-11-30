using Game.WebApi.Extension;
using Game.WebApi.Models;
using Game.WebApi.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Game.WebApi.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IRegisterUser repository; 
        public AccountController()
        {
            repository = new RegisterUserConcrete();
        }

        // POST api/Account/Register
        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register(RegisterUser registerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validating Username 
            if (repository.ValidateUsername(registerUser))
            {
               return BadRequest("User is Already Registered");
            }
            registerUser.JoiningDate = DateTime.Now;
            registerUser.DecryptPassword = registerUser.Password;
            registerUser.Password=registerUser.Password.Encrypt();
            
            repository.Add(registerUser);

            return Ok();
        }



      


    }
}
