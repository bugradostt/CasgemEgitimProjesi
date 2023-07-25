using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class VitrinCourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
