using ISS_Frontend.Models;

namespace ISS_Frontend.Service
{
    public interface IPDFExporter
    {
        Task ExportPDFAsync(ExportRequest request);
    }
}
