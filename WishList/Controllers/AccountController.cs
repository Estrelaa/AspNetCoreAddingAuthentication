using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;

namespace WishList.Controllers
{
    [Authorize]
    public class AccountController : Controller 
    {
        public  AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager) 
        {
            
        }
        private UserManager<ApplicationUser> _userManager()
        {
            
        }

        private  SignInManager<ApplicationUser> _signInManager()
        {
            
        }
    }
}
