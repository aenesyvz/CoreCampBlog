﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Dal());
        public IViewComponentResult Invoke()
        {
            int id = 1;
            var value = messageManager.GetAllByWriter(id);
            return View(value);
        }
    }
}
