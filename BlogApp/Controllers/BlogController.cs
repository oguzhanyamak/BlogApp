using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new BlogRepository());


        public IActionResult Index()
        {
            var values = _blogManager.GetBlogWith("Category");
            return View(values);
        }

        public IActionResult BlogDetails([FromRoute]int id)
        {
            var values = _blogManager.GetBlogWith("Category",id);
            return View(values);
        }



    }
}
