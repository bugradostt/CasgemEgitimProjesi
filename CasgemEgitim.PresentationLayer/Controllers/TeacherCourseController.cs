using CasgemEgitim.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class TeacherCourseController : Controller
    {
        readonly ICourseService _courseService;

        public TeacherCourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        //Kurs
        public IActionResult ListCourse()
        {
            var values = _courseService.TGetList().OrderByDescending(x => x.CourseId).ToList();
            return View(values);
        }

        public IActionResult DeleteCourse(int id)
        {
            var foundId = _courseService.TGetById(id);
            _courseService.TDelete(foundId);
            return RedirectToAction("ListCourse");
        }
    }
}
