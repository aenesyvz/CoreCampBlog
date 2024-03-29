﻿using CoreCampBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
  
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            list.Add(new CategoryModel
            {
                CategoryName = "Teknoloji",
                CategoryCount = 10
            });
            list.Add(new CategoryModel
            {
                CategoryName = "Yazılım",
                CategoryCount = 14
            });
            list.Add(new CategoryModel
            {
                CategoryName = "Spor",
                CategoryCount = 11
            });
            return Json(new {jsonList = list});
        }
    }
   
}
