using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogApp.Controllers
{
    
    public class AuthorController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new BlogRepository());



        [AllowAnonymous]
        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult GetBlogsByAuthor(int id=1) 
        {
            //Gerçekten özür dilerim :D 
            List<Blog> res = _blogManager.GetBlogWith("Category");
            res = res.Where(x => x.AuthorId == id).ToList();
            return View(res);
        }

        
    }
}
