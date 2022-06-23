using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.Author
{
    public class AuthorNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
