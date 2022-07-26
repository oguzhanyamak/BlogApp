using BlogApp.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private AuthorManager authorManager = new(new AuthorRepository());

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterModel appUserRegisterModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = appUserRegisterModel.mail,
                    Name = appUserRegisterModel.name,
                    Surname = appUserRegisterModel.surname,
                    UserName = appUserRegisterModel.mail.Split('@')[0]
                };
                var result = await _userManager.CreateAsync(user, appUserRegisterModel.password);
                if (result.Succeeded)
                {
                    addAuthorDb(appUserRegisterModel);
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(appUserRegisterModel);
        }


        private void addAuthorDb(AppUserRegisterModel appUserRegisterModel)
        {
            Author author = new Author()
            {
                AuthorName = appUserRegisterModel.name,
                AuthorAbout = "",
                AuthorMail = appUserRegisterModel.mail,
                AuthorPassword = appUserRegisterModel.password,
                Status = true,
                AuthorImage = "/AuthorLayout/images/faces/face10.jpg"
            };
            authorManager.Add(author);
        }
    }
}
