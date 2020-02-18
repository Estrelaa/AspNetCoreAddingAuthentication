using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;

namespace WishList.Controllers
{
    [Authorize]
    public class AccountController : Controller 
    {
        public readonly AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager) 
        {
            
        }
        private readonly UserManager<ApplicationUser> _userManager()
        {
            
        }

        private readonly SignInManager<ApplicationUser> _signInManager()
        {
            
        }
    }
}
