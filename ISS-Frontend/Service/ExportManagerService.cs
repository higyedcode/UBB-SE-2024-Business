using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CsvHelper;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using ISS_Frontend.Models;

namespace ISS_Frontend.Service
{
    public class ExportManagerService : IPDFExporter, ICSVExporter, IEmailSender
    {
        public async Task ExportPDFAsync(ExportRequest request)
        {
            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                PdfBrush color = new PdfSolidBrush(Color.Black);
                int height = 20;
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, request.FontSize);
                switch (request.FontIndex)
                {
                    case 1:
                        font = new PdfStandardFont(PdfFontFamily.Helvetica, request.FontSize);
                        break;
                    case 2:
                        font = new PdfStandardFont(PdfFontFamily.Courier, request.FontSize);
                        break;
                }

                switch (request.ColorIndex)
                {
                    case 1:
                        color = new PdfSolidBrush(Color.Gray);
                        break;
                    case 2:
                        color = new PdfSolidBrush(Color.Red);
                        break;
                }

                graphics.DrawString("Advertisement Statistics Report", font, color, new PointF((page.Size.Width / 2f) - 100, 10));

                if (request.ImpressionsChecked) height = DrawText(graphics, font, color, "\nAmount of Impressions: " + request.Stats.Views, height);
                if (request.ClicksChecked) height = DrawText(graphics, font, color, "\nAmount of Clicks: " + request.Stats.Clicks, height);
                if (request.BuysChecked) height = DrawText(graphics, font, color, "\nAmount of Purchases: " + request.Stats.Buys, height);
                if (request.TimeChecked) height = DrawText(graphics, font, color, "\nTotal Time Viewed: " + request.Stats.Time, height);
                if (request.CtrChecked) height = DrawText(graphics, font, color, "\nClick Through Ratio: " + ((float)request.Stats.Clicks / request.Stats.Views), height);
                if (request.DateChecked)
                {
                    graphics.DrawString("Created on:", font, color, new PointF(20, page.Size.Height - 120));
                    graphics.DrawString(DateTime.Now.ToString(), font, color, new PointF(20, page.Size.Height - 100));
                }
                if (request.SignatureChecked)
                {
                    graphics.DrawString("Signature:", font, color, new PointF(page.Size.Width - 200, page.Size.Height - 120));
                    graphics.DrawString(request.User.Username, font, color, new PointF(page.Size.Width - 200, page.Size.Height - 100));
                }
                if (request.RecipientChecked)
                {
                    graphics.DrawString("Intended Recipient:", font, color, new PointF((page.Size.Width / 2f) - 50, page.Size.Height - 120));
                    graphics.DrawString(request.RecipientInput, font, color, new PointF((page.Size.Width / 2f) - 50, page.Size.Height - 100));
                }
                SaveDocument(document, request.EmailButtonChecked, request.DownloadButtonChecked, request.RecipientInput, request.SenderEmail, request.SenderPassword, request.SmtpServer, request.SmtpPort, request.EnableSsl, request.Subject, request.Message);
            }
        }


        private int DrawText(PdfGraphics graphics, PdfFont font, PdfBrush color, string text, int height)
        {
            graphics.DrawString(text, font, color, new PointF(10, height));
            return height + 20;
        }

        private void SaveDocument(PdfDocument document, bool emailButtonChecked, bool downloadButtonChecked, string recipientInput, string senderEmail, string senderPassword, string smtpServer, int smtpPort, bool enableSsl, string subject, string message)
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "output.pdf");
            if (emailButtonChecked || downloadButtonChecked)
            {
                using (var memoryStream = new MemoryStream())
                {
                    document.Save(memoryStream);
                    memoryStream.Position = 0;
                    SendDocEmailAsync(recipientInput, memoryStream, senderEmail, senderPassword, smtpServer, smtpPort, enableSsl, subject, message).Wait();
                }
            }
            document.Close(true);
        }

        public async Task ExportCSVAsync(ExportRequest request)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                using (var csvWriter = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    if (request.ImpressionsChecked) csvWriter.WriteField(request.Stats.Views);
                    if (request.ClicksChecked) csvWriter.WriteField(request.Stats.Clicks);
                    if (request.BuysChecked) csvWriter.WriteField(request.Stats.Buys);
                    if (request.CtrChecked) csvWriter.WriteField((float)request.Stats.Clicks / request.Stats.Views);
                    if (request.TimeChecked) csvWriter.WriteField(request.Stats.Time);
                    csvWriter.NextRecord();
                }

                memoryStream.Position = 0;

                if (!string.IsNullOrEmpty(request.EmailRecipient))
                {
                    SendDocEmailAsync(request.EmailRecipient, memoryStream, request.SenderEmail, request.SenderPassword, request.SmtpServer, request.SmtpPort, request.EnableSsl, request.Subject, request.Message).Wait();
                }
            }
        }

        public async Task SendDocEmailAsync(string recipient, Stream stream, string senderEmail, string senderPassword, string smtpServer, int smtpPort, bool enableSsl, string subject, string message)
        {
            using (var client = new SmtpClient(smtpServer))
            {
                client.Port = smtpPort;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                client.EnableSsl = enableSsl;

                using (var mail = new MailMessage(senderEmail, recipient, subject, message))
                {
                    mail.Attachments.Add(new Attachment(stream, "StatisticsReport.pdf"));
                    await client.SendMailAsync(mail);
                }
            }
        }
    }
}
