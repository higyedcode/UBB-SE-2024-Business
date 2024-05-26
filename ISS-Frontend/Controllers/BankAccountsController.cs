using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISS_Frontend.Data;
using ISS_Frontend.Models;
using ISS_Frontend.Service;

namespace ISS_Frontend.Controllers
{
    public class BankAccountsController : Controller
    {
        private readonly ISS_FrontendContext _context;
        public IBankAccountService bankAccountService;

        public BankAccountsController(ISS_FrontendContext context)
        {
            _context = context;
            HttpClient httpClient = new HttpClient();
            bankAccountService = new BankAccountService(httpClient);
            httpClient.BaseAddress = new Uri("http://localhost:5049/");
        }

        // GET: BankAccounts
        public async Task<IActionResult> Index()
        {
            var bankAccounts = bankAccountService.GetBankAccounts();
            return View(bankAccounts);
        }

        // GET: BankAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bankAccount = bankAccountService.GetBankAccountById((int)id);            
            if (bankAccount == null)
            {
                return NotFound();
            }

            return View(bankAccount);
        }

        // GET: BankAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Name,Surname,PhoneNumber,County,City,Address,Number,HolderName,ExpiryDate")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                bankAccountService.AddBankAccount(bankAccount);
                //_context.Add(bankAccount);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var bankAccount = await _context.BankAccount.FindAsync(id);
            var bankAccount = bankAccountService.GetBankAccountById((int)id);
            if (bankAccount == null)
            {
                return NotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Name,Surname,PhoneNumber,County,City,Address,Number,HolderName,ExpiryDate")] BankAccount bankAccount)
        {
            if (id != bankAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(bankAccount);
                    //await _context.SaveChangesAsync();
                    bankAccountService.EditBankAccount(bankAccount);
                }
                catch (Exception)
                {
                    if (bankAccountService.GetBankAccountById(bankAccount.Id) != null)
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
            return View(bankAccount);
        }

        // GET: BankAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            //var bankAccount = await _context.BankAccount
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var bankAccount = bankAccountService.GetBankAccountById((int)id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankAccount = bankAccountService.GetBankAccountById((int)id);
            if (bankAccount != null)
            {
                bankAccountService.RemoveBankAccount((int)id);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankAccountExists(int id)
        {
            return _context.BankAccount.Any(e => e.Id == id);
        }
    }
}
