using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        readonly CategoryManager categoryManager = new(new CategoryRepository());
        readonly CategoryValidator validator = new();

        
        public IActionResult Index(int page =1,int pageSize = 3)
        {
            var value = categoryManager.GetList().ToPagedList(page,pageSize);
            return View(value);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category C)
        {
            ValidationResult result = validator.Validate(C);
            if (result.IsValid)
            {
                C.Status = true;
                categoryManager.Add(C);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        
        public IActionResult CategoryDelete(int id)
        {
            var cat = categoryManager.GetById(id);
            categoryManager.Delete(cat);
            return RedirectToAction("Index");
        }
    }
}
