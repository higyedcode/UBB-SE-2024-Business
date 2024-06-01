using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ISS_Frontend.Models;
using ISS_Frontend.Service;
using Microsoft.EntityFrameworkCore;

namespace ISS_Frontend.Controllers
{
    public class ExportRequestsController : Controller
    {
        private readonly IExportRequestService _exportRequestService;

        public ExportRequestsController(IExportRequestService exportRequestService)
        {
            _exportRequestService = exportRequestService;
        }

        // GET: ExportRequests
        public async Task<IActionResult> Index()
        {
            var exportRequests = await _exportRequestService.GetAllExportRequestsAsync();
            return View(exportRequests);
        }

        // GET: ExportRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportRequest = await _exportRequestService.GetExportRequestByIdAsync(id.Value);
            if (exportRequest == null)
            {
                return NotFound();
            }

            return View(exportRequest);
        }

        // GET: ExportRequests/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AdvertisementStatisticsId"] = new SelectList(await _exportRequestService.GetAdStatisticsAsync(), "Id", "Id");
            ViewData["UserId"] = new SelectList(await _exportRequestService.GetUsersAsync(), "Id", "Id");
            return View();
        }

        // POST: ExportRequests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdvertisementStatisticsId,UserId,FontSize,FontIndex,ColorIndex,ImpressionsChecked,ClicksChecked,BuysChecked,TimeChecked,CtrChecked,DateChecked,SignatureChecked,RecipientChecked,RecipientInput,EmailButtonChecked,DownloadButtonChecked,OutputPath,EmailRecipient,SenderEmail,SenderPassword,SmtpServer,SmtpPort,EnableSsl,Subject,Message")] ExportRequest exportRequest)
        {
            if (ModelState.IsValid)
            {
                await _exportRequestService.AddExportRequestAsync(exportRequest);

                // Check if PDF or CSV export is required
                if (exportRequest.DownloadButtonChecked)
                {
                    if (exportRequest.EmailButtonChecked)
                    {
                        await _exportRequestService.ExportPDFAsync(exportRequest);
                    }
                    else
                    {
                        await _exportRequestService.ExportCSVAsync(exportRequest);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["AdvertisementStatisticsId"] = new SelectList(await _exportRequestService.GetAdStatisticsAsync(), "Id", "Id", exportRequest.AdvertisementStatisticsId);
            ViewData["UserId"] = new SelectList(await _exportRequestService.GetUsersAsync(), "Id", "Id", exportRequest.UserId);
            return View(exportRequest);
        }

        // GET: ExportRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportRequest = await _exportRequestService.GetExportRequestByIdAsync(id.Value);
            if (exportRequest == null)
            {
                return NotFound();
            }
            ViewData["AdvertisementStatisticsId"] = new SelectList(await _exportRequestService.GetAdStatisticsAsync(), "Id", "Id", exportRequest.AdvertisementStatisticsId);
            ViewData["UserId"] = new SelectList(await _exportRequestService.GetUsersAsync(), "Id", "Id", exportRequest.UserId);
            return View(exportRequest);
        }

        // POST: ExportRequests/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdvertisementStatisticsId,UserId,FontSize,FontIndex,ColorIndex,ImpressionsChecked,ClicksChecked,BuysChecked,TimeChecked,CtrChecked,DateChecked,SignatureChecked,RecipientChecked,RecipientInput,EmailButtonChecked,DownloadButtonChecked,OutputPath,EmailRecipient,SenderEmail,SenderPassword,SmtpServer,SmtpPort,EnableSsl,Subject,Message")] ExportRequest exportRequest)
        {
            if (id != exportRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _exportRequestService.UpdateExportRequestAsync(exportRequest);

                    // Check if PDF or CSV export is required
                    if (exportRequest.DownloadButtonChecked)
                    {
                        if (exportRequest.EmailButtonChecked)
                        {
                            await _exportRequestService.ExportPDFAsync(exportRequest);
                        }
                        else
                        {
                            await _exportRequestService.ExportCSVAsync(exportRequest);
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_exportRequestService.ExportRequestExists(exportRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdvertisementStatisticsId"] = new SelectList(await _exportRequestService.GetAdStatisticsAsync(), "Id", "Id", exportRequest.AdvertisementStatisticsId);
            ViewData["UserId"] = new SelectList(await _exportRequestService.GetUsersAsync(), "Id", "Id", exportRequest.UserId);
            return View(exportRequest);
        }

        // GET: ExportRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportRequest = await _exportRequestService.GetExportRequestByIdAsync(id.Value);
            if (exportRequest == null)
            {
                return NotFound();
            }

            return View(exportRequest);
        }

        // POST: ExportRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _exportRequestService.DeleteExportRequestAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
