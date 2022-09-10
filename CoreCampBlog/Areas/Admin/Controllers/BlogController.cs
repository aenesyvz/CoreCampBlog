using ClosedXML.Excel;
using CoreCampBlog.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportDynamicExcelBlogList()
        {
            using(var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach(var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    worksheet.Cell(BlogRowCount, 1).Value = item.BlogName;
                    BlogRowCount++;
                }

                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
     
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new List<BlogModel>();
            using(var context = new Context())
            {
                blogModels = context.Blogs.Select(x => new BlogModel
                {
                    Id = x.BlogId,
                    BlogName = x.BlogTitle
                }).ToList();
            }
            return blogModels;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }
    }
}
