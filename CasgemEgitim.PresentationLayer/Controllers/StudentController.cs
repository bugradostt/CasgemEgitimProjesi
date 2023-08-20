using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.EntityLayer.Concrete;
using CasgemEgitim.ModelViewLayer.ModelView.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly ICourseDetailService _courseDetailService;
        private readonly ICommentService _commentService;

        public StudentController(IStudentService studentService, ICourseService courseService, ICourseDetailService courseDetailService, ICommentService commentService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _courseDetailService = courseDetailService;
            _commentService = commentService;
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
          
            var studentId = HttpContext.Session.GetString("studentId");
            var values = _courseService.TGetCoursesWithUserStudent(Convert.ToInt32(studentId));
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
        public IActionResult UpdateStudent()
        {
            var studentId = HttpContext.Session.GetString("studentId");
            var values = _studentService.TGetById(Convert.ToInt32(studentId));
            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateGetStudent()
        {
            var studentId = HttpContext.Session.GetString("studentId");
            var values = _studentService.TGetById(Convert.ToInt32(studentId));
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
            return RedirectToAction("UpdateGetStudent");
        }

        //kurs Detay işlemleri

        public IActionResult ListCourseDetail(int id)
        {
            ViewBag.Id = id;
            ViewBag.CourseName = _courseDetailService.TGetCourseByIdWithCourseName(id);
            var values = _courseDetailService.TGetCoursesWithById(id);
            return View(values);
        }


        [HttpPost]
        public IActionResult Comment(CreateCommentMV p)
        {
          
            var studentId = HttpContext.Session.GetString("studentId");
          
            Comment model = new Comment()
            {
               CourseId = p.CourseId,
               StudentId = Convert.ToInt32(studentId),
               CommentMessage = p.CommentMessage,
               CommentDate = DateTime.Now

        };
            _commentService.TInsert(model);
            return RedirectToAction("ListUserCourse");
        }
    }
}
