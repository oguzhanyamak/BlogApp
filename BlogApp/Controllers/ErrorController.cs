using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error404(int error)
        {
            return View();
        }
    }
}
