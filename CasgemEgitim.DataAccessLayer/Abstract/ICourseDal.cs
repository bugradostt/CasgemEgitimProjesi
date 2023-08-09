using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.DataAccessLayer.Abstract
{
    public interface ICourseDal : IGenericDal<Course>
    {
        public List<Course> GetCoursesWithTeacher();
        public List<Course> GetCoursesWithUserTeacher(int id);
        public List<Course> GetCoursesWithUserStudent(int id);

        public Course GetCoursesByIdWithTeacher(int id);
    }

}
