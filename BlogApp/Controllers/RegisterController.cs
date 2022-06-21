using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class RegisterController : Controller
    {
        AuthorManager authorManager = new AuthorManager(new AuthorRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Author author)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult result = authorValidator.Validate(author);
            if (result.IsValid)
            {
                if (author.AuthorPassword == author.AuthorRePassword)
                {
                    author.Status = true;
                    author.AuthorAbout = "";
                    author.AuthorImage = "";
                    authorManager.AuthorAdd(author);
                    return RedirectToAction("Index", "Register");
                }
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
