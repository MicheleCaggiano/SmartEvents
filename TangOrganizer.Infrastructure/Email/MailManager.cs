using System;
using System.Linq;
using System.Net.Mail;
using System.Text;
using SmartEvents.Infrastructure.Email.Interfaces;

namespace SmartEvents.Infrastructure.Email
{
    public enum SendingResult
    {
        Success = 0,
        RecipientEmailNotExists = 1,
        ServerError = 2
    }

    public class MailManager : IMailManager
    {
        private static string _addressTo;
        private static string _addressFrom;
        private static string _addressCc;
        private static string _subject;
        private static string _body;

        public MailManager To(string address)
        {
            if (string.IsNullOrEmpty(address)) throw new Exception("Address 'To' cannot be null or empty.");
            _addressTo = address;
            return this;
        }

        public MailManager From(string address)
        {
            if (string.IsNullOrEmpty(address)) throw new Exception("Address 'From' cannot be null or empty.");
            _addressFrom = address;
            return this;
        }

        public MailManager Cc(string address)
        {
            _addressCc = address;
            return this;
        }

        public MailManager Subject(string subject)
        {
            _subject = subject;
            return this;
        }

        public MailManager Body(string body)
        {
            if (string.IsNullOrEmpty(body)) throw new Exception("Message Body cannot be null or empty.");
            _body = body;
            return this;
        }

        void IMailManager.Send(Action<MailManager> action)
        {
            Send(action);
        }

        public static SendingResult Send(Action<MailManager> action)
        {
            action(new MailManager());
            var email = new MailMessage(_addressFrom, _addressTo);

            // Checks for Cc recipients
            if (!string.IsNullOrEmpty(_addressCc))
            {
                foreach (var emailCc in _addressCc.Split(';').Select(address => new MailAddress(address)))
                {
                    email.CC.Add(emailCc);
                }
            }

            email.Subject = _subject;
            email.Body = _body;
            email.IsBodyHtml = true;
            email.BodyEncoding = Encoding.UTF8;

            // Creates SmtpClient object
            var smtp = new SmtpClient { Timeout = 20000 };
            // Set smtp credentials by stmp web config, otherwise set programmatically
            // smtp.Credentials = new System.Net.NetworkCredential(username, password);
            try
            {
                smtp.Send(email);
                return SendingResult.Success;
            }
            catch (SmtpFailedRecipientsException)
            {
                return SendingResult.RecipientEmailNotExists;
            }
            catch (Exception)
            {
                return SendingResult.ServerError;
            }
        }
    }
}
