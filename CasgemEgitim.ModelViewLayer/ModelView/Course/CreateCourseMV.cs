using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.ModelViewLayer.ModelView.Course
{
    public class CreateCourseMV
    {
      
        public string CourseName { get; set; }
        public string CourseImgUrl { get; set; }
        public string CourseDes { get; set; }
        public decimal CoursePrice { get; set; }
        public int CourseStudent { get; set; }
        public List<Video> Videos { get; set; }
        public List<Student> Students { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
