using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.Author
{
    public class AuthorNotification : ViewComponent
    {
        NotificationManager notificationManager = new(new NotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = notificationManager.GetList();
            return View(values);
        }
    }
}
