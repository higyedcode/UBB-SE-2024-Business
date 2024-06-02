using System.Net.Mail;
using System.Net;
using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public class PaymentFormService : IPaymentFormService
    {
        private readonly IBankAccountService bankAccountService;
        private readonly IProductService productService;

        public PaymentFormService(IBankAccountService bankAccountService, IProductService productService)
        {
            this.productService = productService;
            this.bankAccountService = bankAccountService;
        }
        
        //private readonly AccountRepository accountRepository;
        //private readonly INterfaceProductRepository productRepository;

        //public PaymentFormService(AccountRepository repositoryAccount, INterfaceProductRepository repositoryProduct)
        //{
        //    this.accountRepository = repositoryAccount;
        //    this.productRepository = repositoryProduct;
        //}

        public Task SendPaymentConfirmationMailAsync()
        {
            var sender = "osvathrobert03@gmail.com";
            var receiver = this.bankAccountService.GetBankAccounts()[0].Email;
            var password = "daes ndml ukpj qvuj";

            var product = this.productService.GetProducts()[0];
            // var product = this.productRepository.Product;
            var subject = "Running tests im sorry";

            // var subject = "Payment Confirmation For " + product.Name;
            var message = "Description: " + product.Description + "\nPrice: " + product.Price;

            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(sender, password),
                EnableSsl = true,
            };

            if (string.IsNullOrWhiteSpace(receiver))
            {
                throw new InvalidOperationException("Receiver email cannot be null or empty.");
            }

            var mail = new MailMessage(
                from: sender,
                to: receiver,
                subject: subject,
                body: message);
            return client.SendMailAsync(mail);
        }

        public Product GetProduct()
        {
            return this.productService.GetProducts()[0];
        }
    }
}
