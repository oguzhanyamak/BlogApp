using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.Blog
{
    public class LastBlogsByAuthor :ViewComponent
    {
        BlogManager blogManager = new BlogManager(new BlogRepository());
        
        public IViewComponentResult Invoke(int id)
        {
            var values = blogManager.GetBlogWith("Author", id);
            return View(values);
        }
    }
}
