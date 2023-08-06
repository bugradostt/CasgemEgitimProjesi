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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetMessagesByStudentID(int studentID)
        {
            return _messageDal.GetMessagesByStudentID(studentID);
        }

        public List<Message> GetMessagesByTeacherID(int teacherID)
        {
            return _messageDal.GetMessagesByTeacherID(teacherID);
        }

        public void TDelete(Message t)
        {
           _messageDal.Delete(t);
        }

        public Message TGetById(int id)
        {
           return _messageDal.GetById(id);
        }

        public List<Message> TGetList()
        {
            return _messageDal.GetList();
        }

        public void TInsert(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TUpdate(Message t)
        {
            _messageDal.Update(t);
        }
    }
}
