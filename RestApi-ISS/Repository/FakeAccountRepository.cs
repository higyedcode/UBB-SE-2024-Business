using System;
using Backend.Models;
using Iss.Service;
using Newtonsoft.Json.Linq;

namespace Iss.Repository
{
    public class FakeAccountRepository : IAccountRepository
    {
        private readonly IDataEncryptionService encryptionService;
        private BankAccount bankAccount;

        public FakeAccountRepository(BankAccount account, IDataEncryptionService encryptionService)
        {
            this.encryptionService = encryptionService ?? throw new ArgumentNullException(nameof(encryptionService));
            bankAccount = account ?? throw new ArgumentNullException(nameof(account));
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            if (bankAccount == null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }
            bankAccount = bankAccount;
        }

        public void EditBankAccount(BankAccount bankAccount)
        {
            if (bankAccount == null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }
            bankAccount = bankAccount;
        }

        public BankAccount GetBankAccount()
        {
            return bankAccount;
        }
    }
}
