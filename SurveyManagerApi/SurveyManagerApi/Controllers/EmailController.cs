using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Get()
        {
            var message = new Message(new string[] { "surveymanagerservice@gmail.com" }, "Test email", "This is the content from our email.");
            _emailSender.SendEmail(message);
            return Ok() ;
        }
    }
}
