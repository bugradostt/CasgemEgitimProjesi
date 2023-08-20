using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Concrete;
using CasgemEgitim.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class MessageController:Controller
    {
        private readonly IMessageService _messageService;
        private readonly Context _context;

        public MessageController(IMessageService messageService, Context context)
        {
            _messageService = messageService;
            _context = context;
        }


        public ActionResult GetInboxTeacher()
        {
            var receiverName = HttpContext.Session.GetString("teacherUsername");
            var values = _messageService.TGetMessageWithReceiverName(receiverName).OrderByDescending(x => x.MessageDate).ToList();
            return View(values);
        }
        public ActionResult MessageDetails(int id)
        {
            var values = _messageService.TGetById(id);
            ViewBag.subject = values.Subject;
            //ViewBag.sender = values.SenderID;
            ViewBag.message = values.MessageDetails;
            ViewBag.date = values.MessageDate;
            return View(values);
        }

        public ActionResult GetInboxStudent() 
        {

            var receiverName = HttpContext.Session.GetString("username");
            var values = _messageService.TGetMessageWithReceiverName(receiverName).OrderByDescending(x=>x.MessageDate).ToList();
            return View(values);
        }


        public ActionResult GetUnreadStudent()
        {

            var receiverName = HttpContext.Session.GetString("username");
            var values = _messageService.TGetMessageWithReceiverName(receiverName).Where(x=>x.MessageStatus==true).OrderByDescending(x => x.MessageDate).ToList();
            return View(values);
        }

        public ActionResult GetSentStudent()
        {

            var senderName = HttpContext.Session.GetString("username");
            var values = _messageService.TGetMessageWithSenderName(senderName).OrderByDescending(x => x.MessageDate).ToList();
            return View(values);
        }
        public ActionResult MessageStudentDetails(int id) {
            var values = _messageService.TGetById(id);
            if (values.MessageStatus==true)
            {
                values.MessageStatus = false;
                _messageService.TUpdate(values);

            }
            return View(values);
        }

        public ActionResult DeleteStudentMessage(int id)
        {
            var foundId = _messageService.TGetById(id);
            _messageService.TDelete(foundId);
            return RedirectToAction("GetInboxStudent");
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();   
        }
        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            var senderName = HttpContext.Session.GetString("username");
            message.SenderName = senderName;
            message.ReceiverName = message.ReceiverName;
            message.MessageDate = DateTime.Now;
            message.MessageStatus = true;
            _messageService.TInsert(message);
            return RedirectToAction("GetInboxStudent");
        } 
        
        
        [HttpGet]

        public ActionResult SendMessageTeacher()
        {
            return View();   
        }
        [HttpPost]
        public ActionResult SendMessageTeacher(Message message)
        {
            var senderName = HttpContext.Session.GetString("teacherUsername");
            message.SenderName = senderName;
            message.ReceiverName = message.ReceiverName;
            message.MessageDate = DateTime.Now;
            message.MessageStatus = true;
            _messageService.TInsert(message);
            return RedirectToAction("GetInboxTeacher");
        }

        public ActionResult GetUnreadTeacher()
        {

            var receiverName = HttpContext.Session.GetString("teacherUsername");
            var values = _messageService.TGetMessageWithReceiverName(receiverName).Where(x => x.MessageStatus == true).OrderByDescending(x => x.MessageDate).ToList();
            return View(values);
        }

        public ActionResult GetSentTeacher()
        {

            var senderName = HttpContext.Session.GetString("teacherUsername");
            var values = _messageService.TGetMessageWithSenderName(senderName).OrderByDescending(x => x.MessageDate).ToList();
            return View(values);
        }

        public ActionResult DeleteTeacherMessage(int id)
        {
            var foundId = _messageService.TGetById(id);
            _messageService.TDelete(foundId);
            return RedirectToAction("GetInboxTeacher");
        }

        public ActionResult MessageTeacherDetails(int id)
        {
            var values = _messageService.TGetById(id);
            if (values.MessageStatus == true)
            {
                values.MessageStatus = false;
                _messageService.TUpdate(values);

            }
            return View(values);
        }


    }
}
