using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new BlogRepository());


        public IActionResult Index()
        {
            var values = _blogManager.GetBlockListWithCategory();
            return View(values);
        }

        public IActionResult BlogDetails([FromRoute]int id)
        {
            ViewBag.i = id;
            var values = _blogManager.GetById(id);
            return View(values);
        }
    }
}
