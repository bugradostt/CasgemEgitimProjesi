using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.BusinessLayer.Abstract
{
    public interface ICourseService :IGenericService<Course>
    {
        public List<Course> TGetCoursesWithTeacher();

        public List<Course> TGetCoursesWithUserTeacher(int id);

        public List<Course> TGetCoursesWithUserStudent(int id);
    }
}
