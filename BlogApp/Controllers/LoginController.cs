using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Author author)
        {
            using (Context c = new Context())
            {
                var value = c.Authors.FirstOrDefault(x => x.AuthorMail == author.AuthorMail && x.AuthorPassword == author.AuthorPassword);
                if (value != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,author.AuthorMail)
                    };
                    var userIdentity = new ClaimsIdentity(claims,"a");
                    ClaimsPrincipal principal = new(userIdentity);
                    await HttpContext.SignInAsync(principal);
                 //   HttpContext.Session.SetString("username", author.AuthorMail);
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    return View();
                }
            }

        }
    }
}
