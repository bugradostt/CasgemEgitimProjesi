using CasgemEgitim.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CasgemEgitim.PresentationLayer.ViewComponents.Course
{
    public class _CourseDetailCourseName:ViewComponent
    {
        readonly ICourseDetailService _courseDetailService;

        public _CourseDetailCourseName(ICourseDetailService courseDetailService)
        {
            _courseDetailService = courseDetailService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _courseDetailService.TGetCoursesWithById(id);
            return View(values);
        }
    }
}
