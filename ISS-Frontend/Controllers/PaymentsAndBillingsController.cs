using ISS_Frontend.Data;
using ISS_Frontend.Models;
using ISS_Frontend.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ISS_Frontend.Controllers
{
    public class PaymentsAndBillingsController : Controller
    {
        private readonly ISS_FrontendContext _context;
        public IProductService productService;
        public IBankAccountService bankAccountService;
        public IPaymentFormService paymentFormService;

        public PaymentsAndBillingsController(ISS_FrontendContext context)
        {
            _context = context;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5049/");
            productService = new ProductService(httpClient);
            bankAccountService = new BankAccountService(httpClient);
            paymentFormService = new PaymentFormService(bankAccountService, productService);
        }

        // GET: PaymentsAndBillingsMainPage
        public ActionResult MainPage()
        {
            return View();
        }

        // GET: PaymentsAndBillings/Index
        public ActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }

        public ActionResult BankAccountsList()
        {
            var bankAccounts = bankAccountService.GetBankAccounts();
            return View(bankAccounts);
        }

        // GET: PaymentsAndBillings/ConfirmPayment/5
        public ActionResult ConfirmPayment(int id)
        {
            var product = productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: PaymentsAndBillings/ConfirmPayment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmPayment(int id, IFormCollection collection)
        {
            try
            {
                var product = productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                paymentFormService.SendPaymentConfirmationMailAsync();
                return View("PaymentSuccess", product);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }        
    }
}
