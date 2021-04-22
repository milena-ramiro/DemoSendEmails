using System;
using DemoSendEmails.Interfaces;
using DemoSendEmails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemoSendEmails.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendEmailController : ControllerBase
    {
        private readonly ISendEmailService _service;
        
        public SendEmailController(ISendEmailService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult SendEmail(
            int port = 587,
            bool enableSSL = true,
            string password = "@Teste123",
            string from = "demo.send.emails@gmail.com",
            string to = "milena-ramiro@outlook.com",
            string host = "smtp.gmail.com",
            string subject = "Enviando e-mail através da API",
            string body = "Testando o envio de email")
        {
            try
            {
                Email model = new Email
                {
                    Port  = port,
                    EnableSSL = enableSSL,
                    Password = password,
                    From = from,
                    Host = host,
                    Subject = subject,
                    Body = body
                };
                
                _service.SendEmail(to, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex));
            }
        }
        
    }
}