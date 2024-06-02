using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public interface IPaymentFormService
    {
        Task SendPaymentConfirmationMailAsync();
        Product GetProduct();
    }
}