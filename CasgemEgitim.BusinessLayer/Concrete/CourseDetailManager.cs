using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Abstract;
using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.BusinessLayer.Concrete
{
    public class CourseDetailManager : ICourseDetailService
    {
        readonly ICourseDetailDal _courseDetailDal;

        public CourseDetailManager(ICourseDetailDal courseDetailDal)
        {
            _courseDetailDal = courseDetailDal;
        }

        public string TGetCourseByIdWithCourseName(int id)
        {
            return _courseDetailDal.GetCourseByIdWithCourseName(id);
        }

        public void TDelete(Video t)
        {
            _courseDetailDal.Delete(t);
        }

        public Video TGetById(int id)
        {
            return _courseDetailDal.GetById(id);
        }

        public List<Video> TGetCoursesWithById(int id)
        {
            return _courseDetailDal.GetCoursesWithById(id);
        }

        public List<Video> TGetList()
        {
            return _courseDetailDal.GetList();
        }

        public void TInsert(Video t)
        {
            _courseDetailDal.Insert(t);
        }

        public void TUpdate(Video t)
        {
            _courseDetailDal.Update(t);
        }

      
    }
}
