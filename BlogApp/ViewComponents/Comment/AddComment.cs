using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.Comment
{
    public class AddComment:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new CommentRepository());
        public IViewComponentResult Invoke(EntityLayer.Concrete.Comment comment, int id)
        {
            var values = commentManager.GetCommentByBlog(id);
            return View(values);
        }
    }
}
