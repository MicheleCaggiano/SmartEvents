using System;

namespace SmartEvents.Infrastructure.Email.Interfaces
{
    public interface IMailManager
    {
        MailManager To(string address);
        MailManager From(string address);
        MailManager Subject(string subject);
        MailManager Body(string body);
        void Send(Action<MailManager> action);
    }
}
