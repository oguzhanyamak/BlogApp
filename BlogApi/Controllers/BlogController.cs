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
    public class BlogController : ControllerBase
    {
        public readonly BlogManager blogManager = new BlogManager(new BlogRepository());

        [HttpGet]
        public List<Blog> getBlogs()
        {
            return blogManager.GetList();
        }

        [HttpPost]
        public void addBlog(Blog blog)
        {
            blogManager.Add(blog);
        }

        [HttpDelete]
        public void deleteBlog(Blog blog)
        {
            blogManager.Delete(blog);
        }

        [HttpPut]
        public void updateBlog(Blog blog)
        {
            blogManager.Update(blog);
        }
    }
}
