using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogApp.Controllers
{
    public class CommentController : Controller
    {

        CommentManager commentManager = new CommentManager(new CommentRepository());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial_AddComment()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult Partial_AddComment(Comment comment,int id)
        {
            comment.CommentDate = DateTime.Parse(DateTime.UtcNow.ToShortDateString());
            return RedirectToAction("Index");
        }

        public PartialViewResult Partial_CommentList(int id)
        {
            var values = commentManager.GetList();
            return PartialView(values);
        }
    }
}
