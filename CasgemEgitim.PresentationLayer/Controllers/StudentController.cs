using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly ICourseDetailService _courseDetailService;

        public StudentController(IStudentService studentService, ICourseService courseService = null, ICourseDetailService courseDetailService = null)
        {
            _studentService = studentService;
            _courseService = courseService;
            _courseDetailService = courseDetailService;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("username");
            var s = _studentService.TGetStudentByUsername(userName);
            ViewBag.st = s;
            var values = _studentService.TGetList();
            return View(values);
        }


        public IActionResult ListUserCourse()
        {
            var values = _courseService.TGetCoursesWithUserStudent(1);
            return View(values);
        }


        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _studentService.TInsert(student);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteStudent(int id)
        {
            var values = _studentService.TGetById(id);
            _studentService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            var values = _studentService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            var values = _studentService.TGetById(student.StudentId);
            values.StudentName = student.StudentName;
            values.StudentSurname = student.StudentSurname;
            values.Username = student.Username;
            values.ImageUrl = student.ImageUrl;
            values.Password = student.Password;
            _studentService.TUpdate(values);
            return RedirectToAction("Index");
        }

        //kurs Detay işlemleri

        public IActionResult ListCourseDetail(int id)
        {
            ViewBag.CourseName = _courseDetailService.TGetCourseByIdWithCourseName(id);
            var values = _courseDetailService.TGetCoursesWithById(id);
            return View(values);
        }
    }
}
