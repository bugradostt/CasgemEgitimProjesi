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
            var teachertId = HttpContext.Session.GetString("teachertId");
            var values = _messageService.GetMessagesByTeacherID(Convert.ToInt32(teachertId));
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

        public ActionResult GetInboxStudent(int id) {
            var studentId = HttpContext.Session.GetString("studentId");
        
            var values = _messageService.GetMessagesByStudentID(Convert.ToInt32(studentId));
            return View(values);
        }
        public ActionResult MessageStudentDetails(int id) {
            var values = _messageService.TGetById(id);
            ViewBag.subject = values.Subject;
           // ViewBag.sender = values.SenderID;
            ViewBag.message = values.MessageDetails;
            ViewBag.date = values.MessageDate.ToShortDateString();
            return View(values);
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();   
        }
        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            message.SenderName = "bugra";
            message.ReceiverName = "dost";
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
           // message.SenderID = 2;
            message.MessageDate = DateTime.Now;
            //message.MessageStatus = true;
            _messageService.TInsert(message);
            return RedirectToAction("GetInboxTeacher");
        }

        
    }
}
