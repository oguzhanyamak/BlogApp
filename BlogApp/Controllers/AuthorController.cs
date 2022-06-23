using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    
    public class AuthorController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        { 
            return View();
        }

        
    }
}
