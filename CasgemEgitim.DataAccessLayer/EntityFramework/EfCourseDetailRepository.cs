using CasgemEgitim.DataAccessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Concrete;
using CasgemEgitim.DataAccessLayer.Repositories;
using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.DataAccessLayer.EntityFramework
{
    public class EfCourseDetailRepository : GenericRepositoriy<Video>, ICourseDetailDal
    {
        Context c = new Context();

        public string GetCourseByIdWithCourseName(int id)
        {
            return c.Courses.Where(x => x.CourseId == id).Select(y => y.CourseName).FirstOrDefault();
        }

        public List<Video> GetCoursesWithById(int id)
        {
           return c.Videos.Where(x=>x.CourseId == id).ToList();
        }
    }
}
