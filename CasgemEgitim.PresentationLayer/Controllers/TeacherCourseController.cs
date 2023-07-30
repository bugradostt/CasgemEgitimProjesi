using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.EntityLayer.Concrete;
using CasgemEgitim.ModelViewLayer.ModelView.Course;
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
            //var values = _courseService.TGetList().OrderByDescending(x => x.CourseId).ToList();
            var values = _courseService.TGetCoursesWithUserTeacher().OrderByDescending(x => x.CourseId).ToList();
            return View(values);
        }

        public IActionResult DeleteCourse(int id)
        {
            var foundId = _courseService.TGetById(id);
            _courseService.TDelete(foundId);
            return RedirectToAction("ListCourse");
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCourse(Course p)
        {
            p.TeacherId = 1;
            _courseService.TInsert(p);
            return RedirectToAction("ListCourse");
        }

        [HttpGet]
        public IActionResult UpdateCourse(int id)
        {
            var values = _courseService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCourse(Course p)
        {
            p.TeacherId = 1;
            _courseService.TUpdate(p);
            return RedirectToAction("ListCourse");
        }
    }
}
