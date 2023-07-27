using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.ModelViewLayer.ModelView.Course
{
    public class ResultCourseMV
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseImgUrl { get; set; }
        public string CourseDes { get; set; }
        public decimal CoursePrice { get; set; }
        public int CourseStudent { get; set; }
    }
}
