﻿using CasgemEgitim.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.ViewComponents.Layout
{
    public class _Teacher : ViewComponent
    {
      
        public IViewComponentResult Invoke()
        {
            ViewBag.teacherUsername = HttpContext.Session.GetString("teacherUsername");
            return View();
        }
    }
}
