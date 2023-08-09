using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class VitrinCourseController : Controller
    {
        readonly ICourseService _courseService;
        readonly ICourseDetailService _courseDetailService;

        public VitrinCourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            var values = _courseService.TGetCoursesWithTeacher().OrderByDescending(x => x.CourseId).ToList();
            return View(values);
        }

        public IActionResult CourseDetail(int id)
        {
            var teacher = _courseService.TGetCoursesByIdWithTeacher(id);
            ViewBag.teacherName = teacher.Teacher.TeacherName + " " + teacher.Teacher.TeacherSurname;
            var foundId = _courseService.TGetById(id);
            return View(foundId);
        }

        public PartialViewResult CourseDetailName(int id)
        {
            var values = _courseDetailService.TGetCoursesWithById(id);
            return PartialView(values);
        }
    }
}
