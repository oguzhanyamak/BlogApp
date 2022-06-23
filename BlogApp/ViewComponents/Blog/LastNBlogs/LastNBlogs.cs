using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.Blog
{
    public class LastNBlogs :ViewComponent
    {
        BlogManager blogManager = new BlogManager(new BlogRepository());

        public IViewComponentResult Invoke(int count)
        {
            var values = blogManager.getLastBlogs(count);
            return View(values);
        }
    }
}
