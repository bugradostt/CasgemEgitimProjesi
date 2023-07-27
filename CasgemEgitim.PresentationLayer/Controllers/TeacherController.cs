using CasgemEgitim.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class TeacherController : Controller
    {
        readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        //Kurs
        public IActionResult ListCourse()
        {
            var values = _teacherService.TGetList().OrderByDescending(x => x.TeachertId).ToList();
            return View(values);
        }

        public IActionResult DeleteCourse(int id)
        {
            var foundId = _teacherService.TGetById(id);
            _teacherService.TDelete(foundId);
            return RedirectToAction("ListCourse");
        }
    }
}