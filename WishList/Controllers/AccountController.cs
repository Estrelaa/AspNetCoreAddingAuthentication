using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;
using WishList.Models.AccountViewModels;
using WishList.Views.Account;

namespace WishList.Controllers
{
    [Authorize]
    public class AccountController : Controller 
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var ApplicationUser = new ApplicationUser()
            {
                UserName = model.Email
            };
            var user = _userManager.CreateAsync(ApplicationUser, model.Password);
            if (!user.Result.Succeeded)
            {
                foreach (var error in user.Result.Errors)
                {
                    ModelState.AddModelError("Password", error.Description);
                }
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var signIn = _signInManager.PasswordSignInAsync(model.Email, model.Password,
                false, false);
            if (!signIn.Result.Succeeded)
            {
                ModelState.AddModelError("", errorMessage: "Invalid Login Attempt");
            }
            return RedirectToAction("Index", "Item");
        }
    }
}
