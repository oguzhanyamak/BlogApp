using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        readonly private AuthorManager authorManager = new(new AuthorRepository());
        
        [HttpGet]
        public List<Author> getAuthors()
        {
            return authorManager.GetList();
        }

        [HttpPost]
        public void addAuthor(Author author)
        {
            authorManager.Add(author);
        }

        [HttpDelete]
        public void deleteAuthor(Author author)
        {
            authorManager.Delete(author);
        }

        [HttpPut]
        public void updateAuthor(Author author)
        {
            authorManager.Update(author);
        }

    }
}
