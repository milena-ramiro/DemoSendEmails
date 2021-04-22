using System.ComponentModel;

namespace DemoSendEmails.Models
{
    public class Email
    {
        [DefaultValue("teste.nova.plataforma@gmail.com")]
        public string From { get; set; }

        [DefaultValue("smtp.gmail.com")] public string Host { get; set; }
        [DefaultValue(587)] public int Port { get; set; }

        [DefaultValue("Rodobens2020")] public string Password { get; set; }
        [DefaultValue(true)] public bool EnableSSL { get; set; }
        [DefaultValue("Enviando e-mail através da API")] public string Subject { get; set; }
        [DefaultValue("Testando o envio de email")] public string Body { get; set; }
    }
}