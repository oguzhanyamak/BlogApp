using BlogApp.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "BlogID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int blogCount = 2;
                foreach (var item in BlogList())  
                {
                    worksheet.Cell(blogCount, 1).Value = item.Id;
                    worksheet.Cell(blogCount, 2).Value = item.BlogName;
                    blogCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma.xml");
                }
            }
        }

        public List<BlogModel> BlogList()
        {
            List<BlogModel> bm = new List<BlogModel>();
            using (var c = new Context())
            {
                bm = c.Blogs.Select(X => new BlogModel
                {
                    Id = X.Id,
                    BlogName = X.BlogTitle
                }).ToList();
            }
            return bm;
        }

        public IActionResult BlogListExcel() { 
            
            return View(); 
        }
        
    }
}
