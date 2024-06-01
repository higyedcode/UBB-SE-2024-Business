using System.Collections.Generic;
using System.Threading.Tasks;
using ISS_Frontend.Models;

namespace ISS_Frontend.Service
{
    public interface IExportRequestService
    {
        Task<List<ExportRequest>> GetAllExportRequestsAsync();
        Task<ExportRequest> GetExportRequestByIdAsync(int id);
        Task AddExportRequestAsync(ExportRequest exportRequest);
        Task UpdateExportRequestAsync(ExportRequest exportRequest);
        Task DeleteExportRequestAsync(int id);
        bool ExportRequestExists(int id);
        Task<List<User>> GetUsersAsync();
        Task<List<AdvertisementStatistics>> GetAdStatisticsAsync();
        Task ExportPDFAsync(ExportRequest request);
        Task ExportCSVAsync(ExportRequest request);
        Task SendDocEmailAsync(string recipient, Stream stream, string senderEmail, string senderPassword, string smtpServer, int smtpPort, bool enableSsl, string subject, string message);
    }
}
