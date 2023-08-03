using CasgemEgitim.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CasgemEgitim.PresentationLayer.Controllers
{
    public class MessageController:Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public ActionResult GetInboxTeacher()
        {
            return View();
        }
    }
}
