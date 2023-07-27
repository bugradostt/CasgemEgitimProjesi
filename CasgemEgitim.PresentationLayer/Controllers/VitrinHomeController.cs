using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class VitrinHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
