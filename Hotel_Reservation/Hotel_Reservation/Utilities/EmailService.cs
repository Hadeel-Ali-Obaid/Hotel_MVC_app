using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

public class EmailService
{
    public async Task SendEmailWithAttachmentAsync(string toEmail, byte[] pdfBytes, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Your Name", "your-email@example.com"));
        message.To.Add(new MailboxAddress("Recipient Name", toEmail));
        message.Subject = subject;

        var bodyBuilder = new BodyBuilder
        {
            TextBody = body
        };

        bodyBuilder.Attachments.Add("invoice.pdf", pdfBytes);

        message.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.example.com", 587, false);
            await client.AuthenticateAsync("your-email@example.com", "your-password");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
