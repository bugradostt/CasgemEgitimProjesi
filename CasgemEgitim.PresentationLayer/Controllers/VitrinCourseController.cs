using CasgemEgitim.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class VitrinCourseController : Controller
    {
        readonly ICourseService _courseService;

        public VitrinCourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            var values = _courseService.TGetCoursesWithTeacher().OrderByDescending(x => x.CourseId).ToList();
            return View(values);
        }
    }
}
