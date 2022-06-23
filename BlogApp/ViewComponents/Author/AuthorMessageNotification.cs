using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.Author
{
    public class AuthorMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
