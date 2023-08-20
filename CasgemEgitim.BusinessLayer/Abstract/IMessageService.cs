using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        public List<Message> TGetMessageWithReceiverName(string receiverName);
        public List<Message> TGetMessageWithSenderName(string senderName);

    }
}
