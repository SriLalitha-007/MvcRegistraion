using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
namespace MvcRegistraion.Services
{
 public class EmailService
{
    // Method to send an email
    public async Task SendEmailAsync(string from, string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Your Name", from));
        message.To.Add(new MailboxAddress("", to));
        message.Subject = subject;

        var bodyBuilder = new BodyBuilder();
        // bodyBuilder.TextBody = body;
        bodyBuilder.HtmlBody = body; // Set the HTML body here

        message.Body = bodyBuilder.ToMessageBody();
        // Set the Content-Type header to specify that the content is HTML
        message.Headers.Add("Content-Type", "text/html; charset=utf-8");

        using (var client = new SmtpClient())
        {
            // Replace 'smtp.example.com' with your SMTP server address
            await client.ConnectAsync("smtp.gmail.com", 587, false);

            // Replace 'your_username' and 'your_password' with your SMTP credentials
            await client.AuthenticateAsync("kotilalitha7@gmail.com", "qjrgeyqkbibxfhfy");

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
   
}
