using DemoSendEmails.Models;

namespace DemoSendEmails.Interfaces
{
    public interface ISendEmailService
    {
        void SendEmail(string mailTo, Email model);
    }
}