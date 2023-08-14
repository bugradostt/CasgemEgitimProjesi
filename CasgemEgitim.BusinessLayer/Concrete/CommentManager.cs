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
    public class CommentManager : ICommentService
    {
        readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TDelete(Comment t)
        {
            throw new NotImplementedException();
        }

        public Comment TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

        public void TInsert(Comment t)
        {
           _commentDal.Insert(t);
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
