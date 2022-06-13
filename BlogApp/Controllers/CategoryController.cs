using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new CategoryRepository());

        public IActionResult Index()
        {
            var Categories = cm.GetList();
            return View(Categories);
        }
    }
}
