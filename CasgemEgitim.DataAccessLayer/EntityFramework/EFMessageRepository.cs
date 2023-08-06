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
    public class EFMessageRepository : GenericRepositoriy<Message>, IMessageDal
    {
        Context c = new Context();
       
        public List<Message> GetMessagesByStudentID(int studentID)
        {
            return c.Messages.Where(m => m.ReceiverID == studentID).ToList();
        }

        public List<Message> GetMessagesByTeacherID(int teacherID)
        {
            return c.Messages.Where(m => m.ReceiverID == teacherID).ToList();
        }
    }
}