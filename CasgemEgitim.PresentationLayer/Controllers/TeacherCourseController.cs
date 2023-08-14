using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.EntityLayer.Concrete;
using CasgemEgitim.ModelViewLayer.ModelView.Course;
using CasgemEgitim.ModelViewLayer.ModelView.Video;
using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class TeacherCourseController : Controller
    {
        readonly ICourseService _courseService;
        readonly ICourseDetailService _courseDetailService;

        public TeacherCourseController(ICourseService courseService, ICourseDetailService courseDetailService)
        {
            _courseService = courseService;
            _courseDetailService = courseDetailService;
        }

        //Kurs
        public IActionResult ListCourse()
        {
            var teachertId = HttpContext.Session.GetString("teachertId");
          

            //var values = _courseService.TGetList().OrderByDescending(x => x.CourseId).ToList();
            var values = _courseService.TGetCoursesWithUserTeacher(Convert.ToInt32(teachertId)).OrderByDescending(x => x.CourseId).ToList();
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
            var teachertId = HttpContext.Session.GetString("teachertId");
            p.TeacherId =  Convert.ToInt32(teachertId);
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
            var teachertId = HttpContext.Session.GetString("teachertId");
            p.TeacherId = Convert.ToInt32(teachertId);
            _courseService.TUpdate(p);
            return RedirectToAction("ListCourse");
        }


        //Kurs detay işlemleri

        public IActionResult ListCourseDetail(int id)
        {
            ViewBag.CourseId = id;
            ViewBag.CourseName = _courseDetailService.TGetCourseByIdWithCourseName(id);
            var values = _courseDetailService.TGetCoursesWithById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult AddCourseDetail(CreateVideoMV p)
        {
            Video v = new Video()
            {
                CourseId = p.CourseId,
                VideoUrl = p.VideoUrl,
                VideoName = p.VideoName
            };
           
            _courseDetailService.TInsert(v);
            return Redirect($"/TeacherCourse/ListCourseDetail/{p.CourseId}");
        }

        public IActionResult DeleteCourseDetail(DeleteVideoMV p)
        {
            Video v = new Video()
            {
                VideoId = p.VideoId,
                CourseId = p.CourseId,
                
            };
            var foundId = _courseDetailService.TGetById(p.VideoId);
            _courseDetailService.TDelete(foundId);
            return Redirect($"/TeacherCourse/ListCourseDetail/{p.CourseId}");
        }


        [HttpPost]
        public IActionResult UpdateCourseDetail(UpdateVideoMV p)
        {
            Video v = new Video()
            {
                VideoId = p.VideoId,
                CourseId = p.CourseId,
                VideoUrl = p.VideoUrl,
                VideoName = p.VideoName
            };
          
            _courseDetailService.TUpdate(v);
            return Redirect($"/TeacherCourse/ListCourseDetail/{p.CourseId}");
        }
    }
}
