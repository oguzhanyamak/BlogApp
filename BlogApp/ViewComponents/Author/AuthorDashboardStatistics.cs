using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApp.ViewComponents.Author
{
    public class AuthorDashboardStatistics : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.v2 = 0;
            ViewBag.v3 = 0;

            using (Context c = new())
            {
                ViewBag.v1 = c.Blogs.Count().ToString();
                ViewBag.v2 = c.Blogs.Where(x => x.AuthorId == id).Count();
                ViewBag.v3 = c.Categories.Count();
            }
                return View();
        }
    }
}
