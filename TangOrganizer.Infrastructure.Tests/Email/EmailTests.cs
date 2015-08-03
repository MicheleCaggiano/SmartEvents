using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartEvents.Infrastructure.Email;

namespace SmartEvents.Infrastructure.Tests.Email
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void Should_Send_Email()
        {
            MailManager.Send((mail) => mail
                .From("michele.caggiano@finconsgroup.com")
                .To("michele.caggiano@finconsgroup.com")
                .Subject("Pirelli Bond System - Code sample")
                .Body("Pirelli Bond System web application: this is an the email body!"));
        }
    }
}
