using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace SimpleSmtp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SmtpClient("smtp-relay.gmail.com", 587)
            {
                EnableSsl = true,
            };

            var from = new MailAddress("StatementService@apexedi.com", "StatementServices");
            var to = new MailAddress("cwilliams@apexedi.com");
            var msg = new MailMessage(from, to)
            {
                Body = "This is a test",
                Subject = "Statement Test",
            };

            client.Send(msg);
        }
    }
}
