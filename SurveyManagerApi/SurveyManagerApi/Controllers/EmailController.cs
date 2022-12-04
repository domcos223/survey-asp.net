using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyManagerApi.Models;

namespace SurveyManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public IActionResult SendEmailFromForm([FromBody] EmailTemplate emailData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var toEmail = emailData.Emails;
            var sub = emailData.Subject;
            var content = emailData.Content;

            var message = new Message(toEmail,sub, content);
            _emailSender.SendEmail(message);
            return Ok() ;
        }
    }
}
