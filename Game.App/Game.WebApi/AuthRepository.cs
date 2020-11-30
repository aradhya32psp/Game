using Game.WebApi.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;

public class AuthRepository : IDisposable
{
    public DBContext _ctx;

    private UserManager<IdentityUser> _userManager;

    public AuthRepository()
    {
        _ctx = new DBContext();
        _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
    }

    public async Task<IdentityResult> RegisterUser(UserModel userModel)
    {
        IdentityUser user = new IdentityUser
        {
            UserName = userModel.MobileNumber
        };

        var result = await _userManager.CreateAsync(user, userModel.Password);

        return result;
    }

    public async Task<IdentityUser> FindUser(string mobileNumber, string password)
    {
        IdentityUser user = await _userManager.FindAsync(mobileNumber, password);

        return user;
    }

    public void Dispose()
    {
        _ctx.Dispose();
        _userManager.Dispose();

    }
}