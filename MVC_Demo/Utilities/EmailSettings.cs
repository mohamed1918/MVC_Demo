using System.Net;
using System.Net.Mail;

namespace MVC_Demo.Utilities
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
           client.EnableSsl = true;
           client.Credentials = new NetworkCredential("memoohossam2004@gmail.com", "pmptcyswwykkbqhs");
           client.Send("memoohossam2004@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}
