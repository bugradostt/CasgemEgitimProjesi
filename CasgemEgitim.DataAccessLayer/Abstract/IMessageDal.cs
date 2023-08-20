using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.DataAccessLayer.Abstract
{
    public interface IMessageDal:IGenericDal<Message>
    {
        public List<Message> GetMessageWithReceiverName(string receiverName);
        public List<Message> GetMessageWithSenderName(string senderName);

    }
}
