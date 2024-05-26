using ISS_Frontend.Models;

namespace ISS_Frontend.Service
{
    public interface IBankAccountService
    {
        public List<BankAccount> GetBankAccounts();
        public BankAccount GetBankAccountById(int bankAccountId);
        public void AddBankAccount(BankAccount bankAccount);
        public void RemoveBankAccount(int bankAccountId);
        public void EditBankAccount(BankAccount bankAccount);

    }
}
