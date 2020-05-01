using Fox.Common.Models;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Fox.MailServices
{
    public class MailService : IMailService
    {
        public async Task SendMail(PurchaseModel pm)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            try
            {
                using (SmtpServer)
                {
                    mail.From = new MailAddress(pm.Email);
                    mail.To.Add("nikolamilicevic16@gmail.com");
                    mail.Subject = pm.Name + pm.Address + pm.City; //eventualno dodati datum  i vreme porudzbine
                    mail.Body = "Informacije za dostavu:" + pm.Name + pm.Address + pm.City + pm.Phone +
                                "OVDE IDE SPISAK PROIZVODA ODNOSNO STA JOS BUDE TREBALO DA IDE U TAJ MAIL";

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("nikolamilicevic16@gmail.com", "sifra123");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    //MessageBox.Show("mail Send");
                    Console.WriteLine("Mail Sent");
                }
            }
            finally
            {
                //if  (SmtpServer is IDisposable) myObject.Dispose();
                SmtpServer.Dispose();
            }

        }
    }
}