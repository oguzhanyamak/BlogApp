using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class CommentController : Controller
    {

        CommentManager commentManager = new CommentManager(new CommentRepository());

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult Partial_AddComment()
        {
            return PartialView();
        }

        public PartialViewResult Partial_CommentList(int id)
        {
            var values = commentManager.GetList(id);
            return PartialView(values);
        }
    }
}
