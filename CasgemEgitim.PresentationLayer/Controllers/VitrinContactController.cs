using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class VitrinContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
