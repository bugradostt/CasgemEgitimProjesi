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

        public Course GetCoursesByIdWithTeacher(int id)
        {

            return c.Courses.Include(x => x.Teacher).Where(x=>x.CourseId==id).FirstOrDefault();

        }

        public List<Course> GetCoursesWithTeacher()
        {

            return c.Courses.Include(x => x.Teacher).ToList();
        }

        public List<Course> GetCoursesWithUserStudent(int id)
        {
            // Öğrencinin aldığı tüm kurslar geliyor
            var movements = c.Movements.Where(m => m.StudentId == id).ToList();

            // Kursları saklayacak bir liste oluşturuyoruz.
            var courses = new List<Course>();

            //  her bir kursu ekliyoruz eğer aynı kurs birden fazla harekette varsa tekrar eklemeyecek
             foreach (var movement in movements)
             {
                var foundCourse= c.Courses.Find(movement.CourseId);

                 if (foundCourse!= null)
                 {
                     courses.Add(foundCourse);
                 }
             }
           

            return courses;

        }
        public List<Course> GetCoursesWithUserTeacher(int id)
        {
            return c.Courses.Where(x=>x.TeacherId==id).ToList();
        }
    }
}
