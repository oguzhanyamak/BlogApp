using BlogApp.Models;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogApp.Controllers
{
    
    public class AuthorController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new BlogRepository());
        private AuthorManager _authorManager = new AuthorManager(new AuthorRepository());


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

        [HttpGet]
        public IActionResult AuthorEditProfile(int id =1)
        {
            var author = _authorManager.GetById(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult AuthorEditProfile(Author author)
        {
            AuthorValidator authorValidator = new();
            ValidationResult result = authorValidator.Validate(author);
            if (result.IsValid)
            {
                _authorManager.Update(author);
                return RedirectToAction("Index", "Author");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}
