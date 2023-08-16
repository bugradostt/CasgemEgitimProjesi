using CasgemEgitim.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.ViewComponents.Layout
{
    public class _Student : ViewComponent
    {

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.imageUrl = HttpContext.Session.GetString("imageUrl");
            return View();
        }
    }
}
