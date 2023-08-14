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
    public class EfCommentRepository : GenericRepositoriy<Comment>, ICommentDal
    {
        Context c = new Context();
        public List<Comment> GetCommentCoursesWithUserStudent(int id)
        {
            return c.Comments.Include(x => x.Student).Where(x => x.CourseId == id).ToList();
        }
    }
}
