using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SWP_template.Service;

public class SendMailServices
{
    MailSettings _mailSettings { set; get; }
    public void SendMailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }
    public async Task<string> SendMail(MailContent mailContent)
    {
        var email = new MimeMessage();
        email.Sender = new MailboxAddress("Bookeng", "bookengswp@gmail.com");
        email.From.Add(new MailboxAddress("Bookeng", "bookengswp@gmail.com"));
        email.To.Add(new MailboxAddress(mailContent.To, mailContent.To));
        email.Subject = mailContent.Subject;

        var builder = new BodyBuilder();
        builder.HtmlBody = mailContent.Body;
        email.Body = builder.ToMessageBody();
        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        try
        {
            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("bookengswp@gmail.com", "yezupmezkcyrbjvs");

            await smtp.SendAsync(email);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "Error: " + ex.Message;
        }
        smtp.Disconnect(true);
        return "An email has been sent. Check your mail-box to reset password";
    }

}

public class MailContent
{
    public string To { get; set; }              // Địa chỉ gửi đến
    public string Subject { get; set; }         // Chủ đề (tiêu đề email)
    public string Body { get; set; }            // Nội dung (hỗ trợ HTML) của email

}

