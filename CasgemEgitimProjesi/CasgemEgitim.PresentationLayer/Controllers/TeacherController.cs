using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
