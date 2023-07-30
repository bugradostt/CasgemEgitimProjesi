using CasgemEgitim.DataAccessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Concrete;
using CasgemEgitim.DataAccessLayer.Repositories;
using CasgemEgitim.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.DataAccessLayer.EntityFramework
{
    public class EfCourseRepository : GenericRepositoriy<Course>, ICourseDal
    {
        Context c = new Context();
        public List<Course> GetCoursesWithTeacher()
        {

            return c.Courses.Include(x => x.Teacher).ToList();
        }

        public List<Course> GetCoursesWithUserTeacher()
        {
            return c.Courses.Where(x=>x.TeacherId==1).ToList();
        }
    }
}
