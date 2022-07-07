using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new BlogRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = blogManager.GetBlogWith("Category", id);
            return View(values);
        }
    }
}
