using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.Author
{
    public class AuthorNavbar : ViewComponent
    {
        AuthorManager _authorManager = new (new AuthorRepository());
        public IViewComponentResult Invoke()
        {
            int userId = _authorManager.IdCheck(User.Identity.Name);
            var user = _authorManager.GetById(userId);
            return View(user);
        }
    }
}
