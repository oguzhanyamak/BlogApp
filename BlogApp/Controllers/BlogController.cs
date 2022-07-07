using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogApp.Controllers
{
    
    public class BlogController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new BlogRepository());
        private CategoryManager categoryManager = new(new CategoryRepository());


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

        [HttpGet]
        public IActionResult BlogAdd()
        {
           
            List<SelectListItem> CategoryValues = (from x in categoryManager.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.Id.ToString() }).ToList();
            ViewBag.cv = CategoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog b)
        {
            BlogValidator blogValidator = new ();
            ValidationResult vr = blogValidator.Validate(b);

            if (vr.IsValid)
            {
                b.Status = true;
                b.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                b.Author.Id = 1;
                b.Category.Id = 1;
                _blogManager.Add(b);
                return RedirectToAction("GetBlogsByAuthor", "Author");
            }
            else
            {
                foreach (var item in vr.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                
            }
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteBlog(int Id)
        {
            var blog = _blogManager.GetById(Id);
            _blogManager.Delete(blog);
            return RedirectToAction("GetBlogsByAuthor", "Author");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            List<SelectListItem> CategoryValues = (from x in categoryManager.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.Id.ToString() }).ToList();
            ViewBag.cv = CategoryValues;
            var blog = _blogManager.GetById(id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            blog.Status = true;
            blog.AuthorId = 1;
            _blogManager.Update(blog);
            return RedirectToAction("GetBlogsByAuthor", "Author");
        }
    }


}
