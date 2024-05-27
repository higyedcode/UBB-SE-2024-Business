using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISS_Frontend.Data;
using ISS_Frontend.Entity;
using ISS_Frontend.Service;

namespace ISS_Frontend.Controllers
{
    

    public class AdAccountsController : Controller
    {
        private readonly ISS_FrontendContext _context;
        public IAdAccountService adAccountService;

        public AdAccountsController(ISS_FrontendContext context)
        {
            _context = context;
            HttpClient httpClient = new HttpClient();
            adAccountService = new AdAccountServiceRest(httpClient);
            httpClient.BaseAddress = new Uri("http://localhost:5049/");
        }

        // GET: AdAccounts
        public async Task<IActionResult> Index()
        {
            var loggedInAdAccount = adAccountService.GetAccount();
            if(loggedInAdAccount == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var accounts = new List<AdAccount>();
            accounts.Add(loggedInAdAccount);

            ViewBag.Ads = adAccountService.GetAdsForCurrentUser();
                ViewBag.AdSet = adAccountService.GetAdSetsForCurrentUser();
            ViewBag.Campaigns = adAccountService.GetCampaignsForCurrentUser();
            return View(accounts);
        }

        // GET: AdAccounts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adAccount = adAccountService.GetAccount();
            if (adAccount == null)
            {
                return NotFound();
            }

            return View(adAccount);
        }

        // GET: AdAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: AdAccounts/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var loggedInAdAccount = new AdAccount();
            if (ModelState.IsValid)
            {
                adAccountService.Login(model.NameOfCompany, model.Password);
                loggedInAdAccount = adAccountService.GetAccount();
                return RedirectToAction("Index", "AdAccounts");
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: AdAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdAccountId,NameOfCompany,DomainOfActivity,SiteUrl,Password,TaxIdentificationNumber,HeadquartersLocation,AuthorisingInstituion")] AdAccount adAccount)
        {
            
                adAccountService.AddAdAccount(adAccount);
                return RedirectToAction("Index", "AdAccounts");

        }

        // GET: AdAccounts/Edit/5        
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adAccount = adAccountService.GetAccount();
            if (adAccount == null)
            {
                return NotFound();
            }
            return View(adAccount);
        }

        // POST: AdAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AdAccountId,NameOfCompany,DomainOfActivity,SiteUrl,Password,TaxIdentificationNumber,HeadquartersLocation,AuthorisingInstituion")] AdAccount adAccount)
        {
            

           
                try
                {
                adAccountService.EditAdAccount(adAccount.NameOfCompany, adAccount.SiteUrl, adAccount.Password, adAccount.HeadquartersLocation);
                }
                catch (Exception)
                {
                    if (!AdAccountExists(adAccount.AdAccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            return RedirectToAction("Index", "AdAccounts");

        }

       

        private bool AdAccountExists(string id)
        {
            return adAccountService.GetAccount() != null;
        }
    }
}
