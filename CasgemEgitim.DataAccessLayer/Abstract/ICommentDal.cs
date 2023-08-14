using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        public List<Comment> GetCommentCoursesWithUserStudent(int id);
    }
}
