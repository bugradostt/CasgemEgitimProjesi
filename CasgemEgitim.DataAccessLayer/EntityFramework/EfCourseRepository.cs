using CasgemEgitim.DataAccessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Repositories;
using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.DataAccessLayer.EntityFramework
{
    public class EfCourseRepository : GenericRepositoriy<Course>, ICourseDal
    {
    }
}
