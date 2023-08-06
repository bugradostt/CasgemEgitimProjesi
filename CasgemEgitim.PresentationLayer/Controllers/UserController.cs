using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.PresentationLayer.Models.UserVMs;
using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private readonly ITeacherService teacherService;
        private readonly IStudentService studentService;

        public UserController(ITeacherService teacherService, IStudentService studentService)
        {
            this.teacherService = teacherService;
            this.studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm vm)
        {
            var student = await studentService.TGetStudentByUsername(vm.Username);
            if (student != null && student.Password == vm.Password)
            {
                HttpContext.Session.SetString("username", student.Username);
                ViewBag.s = student.StudentName;
                return Redirect($"{student.Role}/Index");
            }
            var teacher = await teacherService.TGetTeacherByUsername(vm.Username);
            if (teacher != null && teacher.TeacherPassword == vm.Password)
            {
                ViewBag.t = teacher.TeacherName;
                HttpContext.Session.SetString("username", teacher.TeacherUsername);
                return Redirect($"{teacher.Role}/Index");

            }
            return View();
        }

    }
}
