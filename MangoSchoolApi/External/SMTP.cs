using System.Net.Mail;
using System.Net;

namespace MangoSchoolApi.External
{
    public class SMTP : ISMTP
    {
        public async Task<bool> SendEmail(string email, Guid guid)
        {
            try
            {
                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("email", "senha");
                    client.EnableSsl = true;

                    var from = new MailAddress("Email", "Seu Nome");
                    var to = new MailAddress(email, "");

                    using (var message = new MailMessage(from, to))
                    {
                        message.Subject = "Mango School Access";
                        message.Body = $"Access password: {guid}";

                        client.Send(message);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar o email: {ex.Message}");
                return false;
            }
        }
    }
}
