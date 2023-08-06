using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.DataAccessLayer.Abstract
{
    public interface ICourseDetailDal : IGenericDal<Video>
    {
        public string GetCourseByIdWithCourseName(int id);
        public List<Video> GetCoursesWithById(int id);
    }
}
