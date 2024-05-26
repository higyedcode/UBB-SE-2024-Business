using Backend.Models;

namespace Iss.Repository
{
    public interface IAccountRepository
    {
        BankAccount GetBankAccount();
        void AddBankAccount(BankAccount bankAccount);
        void EditBankAccount(BankAccount bankAccount);
    }
}
