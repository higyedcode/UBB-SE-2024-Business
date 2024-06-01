namespace ISS_Frontend.Models
{
    public class ExportRequest
    {
        // Primary key
        public int Id { get; set; }

        // Foreign keys
        public int AdvertisementStatisticsId { get; set; }
        public int UserId { get; set; }
        public AdvertisementStatistics Stats { get; set; }
        public User User { get; set; }
        public int FontSize { get; set; }
        public int FontIndex { get; set; }
        public int ColorIndex { get; set; }
        public bool ImpressionsChecked { get; set; }
        public bool ClicksChecked { get; set; }
        public bool BuysChecked { get; set; }
        public bool TimeChecked { get; set; }
        public bool CtrChecked { get; set; }
        public bool DateChecked { get; set; }
        public bool SignatureChecked { get; set; }
        public bool RecipientChecked { get; set; }
        public string RecipientInput { get; set; }
        public bool EmailButtonChecked { get; set; }
        public bool DownloadButtonChecked { get; set; }
        public string OutputPath { get; set; }
        public string EmailRecipient { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public bool EnableSsl { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
