using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class VitrinAboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
