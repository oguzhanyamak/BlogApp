using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Views.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {

        CommentManager commentManager = new CommentManager(new CommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = commentManager.GetById(id);
            return View(values);
        }
    }
}
