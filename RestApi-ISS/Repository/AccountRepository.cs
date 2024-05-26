using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Iss.Service;
using Iss.Database;

namespace Iss.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext databaseContext;
        private readonly DataEncryptionService encryptionService;
        private BankAccount bankAccount;

        public AccountRepository(DatabaseContext databaseContext, DataEncryptionService encryptionService)
        {
            this.databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            this.encryptionService = encryptionService ?? throw new ArgumentNullException(nameof(encryptionService));
        }

        public AccountRepository(BankAccount bankAccount)
        {
            this.bankAccount = bankAccount;
        }

        public BankAccount GetBankAccount()
        {
            var bankAccount = databaseContext.BankAccount.FirstOrDefault();

            if (bankAccount != null)
            {
                return DecryptBankAccount(bankAccount);
            }

            return null;
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            var encryptedBankAccount = EncryptBankAccount(bankAccount);
            databaseContext.BankAccount.Add(encryptedBankAccount);
            databaseContext.SaveChanges();
        }

        public void EditBankAccount(BankAccount bankAccount)
        {
            var encryptedBankAccount = EncryptBankAccount(bankAccount);

            databaseContext.ChangeTracker.Clear();
            databaseContext.BankAccount.Update(encryptedBankAccount);
            databaseContext.SaveChanges();
        }

        private BankAccount EncryptBankAccount(BankAccount bankAccount)
        {
            var encryptedEmail = encryptionService.Encrypt(bankAccount.Email!);
            var encryptedName = encryptionService.Encrypt(bankAccount.Name!);
            var encryptedSurname = encryptionService.Encrypt(bankAccount.Surname!);
            var encryptedPhoneNumber = encryptionService.Encrypt(bankAccount.PhoneNumber!);
            var encryptedCounty = encryptionService.Encrypt(bankAccount.County!);
            var encryptedCity = encryptionService.Encrypt(bankAccount.City!);
            var encryptedAddress = encryptionService.Encrypt(bankAccount.Address!);
            var encryptedNumber = encryptionService.Encrypt(bankAccount.Number!);
            var encryptedHolderName = encryptionService.Encrypt(bankAccount.HolderName!);
            var encryptedExpiryDate = encryptionService.Encrypt(bankAccount.ExpiryDate!);

            return new BankAccount
            {
                Email = encryptedEmail["data"],
                Name = encryptedName["data"],
                Surname = encryptedSurname["data"],
                PhoneNumber = encryptedPhoneNumber["data"],
                County = encryptedCounty["data"],
                City = encryptedCity["data"],
                Address = encryptedAddress["data"],
                Number = encryptedNumber["data"],
                HolderName = encryptedHolderName["data"],
                ExpiryDate = encryptedExpiryDate["data"],
            };
        }

        private BankAccount DecryptBankAccount(BankAccount encryptedBankAccount)
        {
            var decryptedEmail = encryptionService.Decrypt(encryptedBankAccount.Email!, encryptedBankAccount.Email!);
            var decryptedName = encryptionService.Decrypt(encryptedBankAccount.Name!, encryptedBankAccount.Name!);
            var decryptedSurname = encryptionService.Decrypt(encryptedBankAccount.Surname!, encryptedBankAccount.Surname!);
            var decryptedPhoneNumber = encryptionService.Decrypt(encryptedBankAccount.PhoneNumber!, encryptedBankAccount.PhoneNumber!);
            var decryptedCounty = encryptionService.Decrypt(encryptedBankAccount.County!, encryptedBankAccount.County!);
            var decryptedCity = encryptionService.Decrypt(encryptedBankAccount.City!, encryptedBankAccount.City!);
            var decryptedAddress = encryptionService.Decrypt(encryptedBankAccount.Address!, encryptedBankAccount.Address!);
            var decryptedNumber = encryptionService.Decrypt(encryptedBankAccount.Number!, encryptedBankAccount.Number!);
            var decryptedHolderName = encryptionService.Decrypt(encryptedBankAccount.HolderName!, encryptedBankAccount.HolderName!);
            var decryptedExpiryDate = encryptionService.Decrypt(encryptedBankAccount.ExpiryDate!, encryptedBankAccount.ExpiryDate!);

            return new BankAccount
            {
                Email = decryptedEmail,
                Name = decryptedName,
                Surname = decryptedSurname,
                PhoneNumber = decryptedPhoneNumber,
                County = decryptedCounty,
                City = decryptedCity,
                Address = decryptedAddress,
                Number = decryptedNumber,
                HolderName = decryptedHolderName,
                ExpiryDate = decryptedExpiryDate,
            };
        }
    }
}
