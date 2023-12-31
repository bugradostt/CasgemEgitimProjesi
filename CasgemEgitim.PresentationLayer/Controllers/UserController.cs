﻿using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.EntityLayer.Concrete;
using CasgemEgitim.PresentationLayer.Models.UserVMs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
                HttpContext.Session.SetString("imageUrl", student.ImageUrl);
                HttpContext.Session.SetString("studentId", student.StudentId.ToString());
                ViewBag.s = student.StudentName;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, student.Username),
                    new Claim(ClaimTypes.Role, student.Role),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction("ListUserCourse", "Student");
                //return Redirect($"{student.Role}/Index");
            }
            var teacher = await teacherService.TGetTeacherByUsername(vm.Username);
            if (teacher != null && teacher.TeacherPassword == vm.Password)
            {
                ViewBag.t = teacher.TeacherName;
                HttpContext.Session.SetString("teacherUsername", teacher.TeacherUsername);
                HttpContext.Session.SetString("teacherImageUrl", teacher.TeacherImageUrl);
                HttpContext.Session.SetString("teachertId", teacher.TeachertId.ToString());
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, teacher.TeacherUsername),
                    new Claim(ClaimTypes.Role, teacher.Role),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction("ListCourse", "TeacherCourse");
                // return Redirect($"{teacher.Role}/Index");

            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (vm.Role == "Student")
            {
                Student student = new Student
                {
                    StudentName = vm.Name,
                    StudentSurname = vm.Surname,
                    Username = vm.Username,
                    Password = vm.Password,
                    ImageUrl = "https://static.vecteezy.com/system/resources/previews/008/442/086/original/illustration-of-human-icon-user-symbol-icon-modern-design-on-blank-background-free-vector.jpg",
                    Role = "Student"
                };

                await studentService.AddStudent(student);
            }
            else if (vm.Role == "Teacher")
            {
                Teacher teacher = new Teacher
                {
                    TeacherName = vm.Name,
                    TeacherSurname = vm.Surname,
                    TeacherUsername = vm.Username,
                    TeacherPassword = vm.Password,
                    TeacherImageUrl = "https://static.vecteezy.com/system/resources/previews/008/442/086/original/illustration-of-human-icon-user-symbol-icon-modern-design-on-blank-background-free-vector.jpg",
                    Role = "Teacher"
                };

                await teacherService.AddTeacher(teacher);
            }

            return RedirectToAction("Login", "User");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
