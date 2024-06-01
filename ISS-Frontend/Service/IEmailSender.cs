namespace ISS_Frontend.Service
{
    public interface IEmailSender
    {
        Task SendDocEmailAsync(string recipient, Stream fileStream, string senderEmail, string senderPassword, string smtpServer, int smtpPort, bool enableSsl, string subject, string message);
    }
}
