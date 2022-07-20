using BlogApp.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserLoginModel appUserLoginModel)
        {

            if (ModelState.IsValid)
            {
                AppUser user =await _userManager.FindByEmailAsync(appUserLoginModel.mail);
                var result = await _signInManager.PasswordSignInAsync(user.UserName, appUserLoginModel.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Author");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
    }
}
