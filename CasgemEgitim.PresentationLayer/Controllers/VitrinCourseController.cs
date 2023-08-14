using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Concrete;

using CasgemEgitim.EntityLayer.Concrete;
using CasgemEgitim.ModelViewLayer.ModelView.Movement;

using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class VitrinCourseController : Controller
    {
        readonly ICourseService _courseService;
        readonly ICourseDetailService _courseDetailService;

        readonly IMovementService _movementService;


        public VitrinCourseController(ICourseService courseService, ICourseDetailService courseDetailService, IMovementService movementService)
        {
            _courseService = courseService;
            _courseDetailService = courseDetailService;
            _movementService = movementService;
        }

        [HttpGet]
        public IActionResult Index(string search = "-")
        {
            if (search == "-")
            {
                var values = _courseService.TGetCoursesWithTeacher().OrderByDescending(x => x.CourseId).ToList();
                return View(values);

            }
            else
            {
				var values = _courseService.TGetCoursesWithTeacher().Where(x=>x.CourseName.Contains(search));
				return View(values);

			}
        }

        public IActionResult CourseDetail(int id)
        {
            var teacher = _courseService.TGetCoursesByIdWithTeacher(id);
            ViewBag.teacherName = teacher.Teacher.TeacherName + " " + teacher.Teacher.TeacherSurname;
            var foundId = _courseService.TGetById(id);
            return View(foundId);
        }

        [HttpGet]
        public IActionResult CourseBuy(int id)
        {
         
            var studentId = HttpContext.Session.GetString("studentId");
           
            ViewBag.BuyIsTrue = _movementService.TGetCoursesByIdWithStudentId(id,Convert.ToInt32(studentId));
			var foundId = _courseService.TGetById(id);
            return View(foundId);
        }

        [HttpPost]
        public IActionResult CourseBuy(CreateMovementMV p)
        {
            var studentId = HttpContext.Session.GetString("studentId");
            Movement model = new Movement()
            {
                StudentId = Convert.ToInt32(studentId),
                CourseId = p.CourseId
            };

            _movementService.TInsert(model);
            return RedirectToAction("ListUserCourse", "Student");
        }



      
    }
}
