using ISS_Frontend.Models;

namespace ISS_Frontend.Service
{
    public interface ICSVExporter
    {
        Task ExportCSVAsync(ExportRequest request);
    }
}
