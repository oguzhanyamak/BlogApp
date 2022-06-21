using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager newsletterManager = new (new NewsletterRepository ());

        [HttpGet]
        public PartialViewResult Subscribe()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Subscribe(NewsLetter N)
        {
            N.Status = true;
            newsletterManager.AddNewsLetter(N);
            return PartialView();

        }
    }
}
