using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var smtpServer = _configuration["EmailSettings:SmtpServer"]; 
        var smtpPort = int.Parse(_configuration["EmailSettings:Port"]); 
        var fromEmail = _configuration["EmailSettings:SenderEmail"]; 
        var password = _configuration["EmailSettings:SenderPassword"]; 


        var message = new MailMessage
        {
            From = new MailAddress(fromEmail),
            Subject = subject,
            Body = body,
            IsBodyHtml = true  
        };

        message.To.Add(new MailAddress(toEmail));

        var smtpClient = new SmtpClient(smtpServer)
        {
            Port = smtpPort,
            Credentials = new NetworkCredential(fromEmail, password),
            EnableSsl = true  // Omogućavanje SSL enkripcije
        };

        try
        {
            await smtpClient.SendMailAsync(message);
        }
        catch (Exception ex)
        {
            // Obradi grešku, npr. logiranje greške
            Console.WriteLine($"Error sending email: {ex.Message}");
        }
    }
}
