
using CasgemEgitim.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class VitrinHomeController : Controller
    {
        readonly ICourseService _courseService;

        public VitrinHomeController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var endCourseList = _courseService.TGetCoursesWithTeacher().OrderByDescending(x => x.CourseId).Take(6).ToList(); 
            return View(endCourseList);
       
        }
    }
}
