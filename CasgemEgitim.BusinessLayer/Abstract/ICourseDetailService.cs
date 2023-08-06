using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.BusinessLayer.Abstract
{
    public interface ICourseDetailService : IGenericService<Video>
    {
        public List<Video> TGetCoursesWithById(int id);

        public string TGetCourseByIdWithCourseName(int id);
    }
}
