using CasgemEgitim.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CasgemEgitim.PresentationLayer.ViewComponents.Comment
{
    public class _CommentWithCourse : ViewComponent
    {
        readonly ICommentService _commentService;

        public _CommentWithCourse(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetCommentCoursesWithUserStudent(id);
            return View(values);
        }
    }
}
