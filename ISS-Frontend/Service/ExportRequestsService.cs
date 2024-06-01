using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ISS_Frontend.Data;
using ISS_Frontend.Models;

namespace ISS_Frontend.Service
{
    public class ExportRequestService : ExportManagerService, IExportRequestService
    {
        private readonly ISS_FrontendContext _context;

        public ExportRequestService(ISS_FrontendContext context)
        {
            _context = context;
        }

        public async Task<List<ExportRequest>> GetAllExportRequestsAsync()
        {
            return await _context.ExportRequest.Include(e => e.Stats).Include(e => e.User).ToListAsync();
        }

        public async Task<ExportRequest> GetExportRequestByIdAsync(int id)
        {
            return await _context.ExportRequest.Include(e => e.Stats).Include(e => e.User).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddExportRequestAsync(ExportRequest exportRequest)
        {
            _context.Add(exportRequest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExportRequestAsync(ExportRequest exportRequest)
        {
            _context.Update(exportRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExportRequestAsync(int id)
        {
            var exportRequest = await _context.ExportRequest.FindAsync(id);
            if (exportRequest != null)
            {
                _context.ExportRequest.Remove(exportRequest);
                await _context.SaveChangesAsync();
            }
        }

        public bool ExportRequestExists(int id)
        {
            return _context.ExportRequest.Any(e => e.Id == id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<List<AdvertisementStatistics>> GetAdStatisticsAsync()
        {
            return await _context.AdStatistics.ToListAsync();
        }
    }
}
