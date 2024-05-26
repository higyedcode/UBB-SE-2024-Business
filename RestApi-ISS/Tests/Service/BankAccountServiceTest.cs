// <copyright file="BankAccountControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.ControllerTests
{
    using System;
    using Backend.Models;
    using Iss.Repository;
    using Iss.Service;
    using NUnit.Framework;
    using RestApi_ISS.Controllers;

    [TestFixture]
    internal class BankAccountServiceTest
    {
        [TestCase("", "Surname", "testAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        public void UpdateBankAccount_InvalidNameField_ThrowsException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            InterfaceBankAccountService bankAccountController = new BankAccountService(accountRepository);

            var exception_thrown = Assert.Catch<Exception>(() => bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));

            Assert.That(exception_thrown.Message, Does.Contain("Invalid bank account data!"));
        }

        [TestCase("Name", "", "testAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        public void UpdateBankAccount_InvalidSurnameField_ThrowsException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            InterfaceBankAccountService bankAccountController = new BankAccountService(accountRepository);

            var exception_thrown = Assert.Catch<Exception>(() => bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));

            Assert.That(exception_thrown.Message, Does.Contain("Invalid bank account data!"));
        }

        [TestCase("Name", "Surname", "", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        public void UpdateBankAccount_InvalidDataEmailField_ThrowsException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            InterfaceBankAccountService bankAccountController = new BankAccountService(accountRepository);

            var exception_thrown = Assert.Catch<Exception>(() => bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));

            Assert.That(exception_thrown.Message, Does.Contain("Invalid bank account data!"));
        }

        [TestCase("Name", "Surname", "testAccount@gmail.com", "aaa", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        public void UpdateBankAccount_InvalidDataPhoneNumberField_ThrowsException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            InterfaceBankAccountService bankAccountController = new BankAccountService(accountRepository);

            var exception_thrown = Assert.Catch<Exception>(() => bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));

            Assert.That(exception_thrown.Message, Does.Contain("Invalid bank account data!"));
        }

        [TestCase("Name", "Surname", "testAccount@gmail.com", "0740123456", "", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        public void UpdateBankAccount_InvalidDataCountyField_ThrowsException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            InterfaceBankAccountService bankAccountController = new BankAccountService(accountRepository);

            var exception_thrown = Assert.Catch<Exception>(() => bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));

            Assert.That(exception_thrown.Message, Does.Contain("Invalid bank account data!"));
        }

        [TestCase("Name", "Surname", "testAccount@gmail.com", "0740123456", "Cluj", "", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        public void UpdateBankAccount_InvalidDataCityField_ThrowsException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            InterfaceBankAccountService bankAccountController = new BankAccountService(accountRepository);

            var exception_thrown = Assert.Catch<Exception>(() => bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));

            Assert.That(exception_thrown.Message, Does.Contain("Invalid bank account data!"));
        }

        [TestCase("Name", "Surname", "testAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "", "123456789", "Name Surname", "12/23")]
        public void UpdateBankAccount_InvalidDataAddressField_ThrowsException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            InterfaceBankAccountService bankAccountController = new BankAccountService(accountRepository);

            var exception_thrown = Assert.Catch<Exception>(() => bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));

            Assert.That(exception_thrown.Message, Does.Contain("Invalid bank account data!"));
        }

        [TestCase("Name", "Surname", "testAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "aaa", "Name Surname", "12/23")]
        public void UpdateBankAccount_InvalidDataNumberField_ThrowsException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            InterfaceBankAccountService bankAccountController = new BankAccountService(accountRepository);

            var exception_thrown = Assert.Catch<Exception>(() => bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));

            Assert.That(exception_thrown.Message, Does.Contain("Invalid bank account data!"));
        }

        [TestCase("Name", "Surname", "testAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "", "12/23")]
        public void UpdateBankAccount_InvalidDataHolderNameField_ThrowsException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            InterfaceBankAccountService bankAccountController = new BankAccountService(accountRepository);

            var exception_thrown = Assert.Catch<Exception>(() => bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));

            Assert.That(exception_thrown.Message, Does.Contain("Invalid bank account data!"));
        }

        [TestCase("Name", "Surname", "testAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "")]
        public void UpdateBankAccount_InvalidDataExpiryDateField_ThrowsException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            InterfaceBankAccountService bankAccountController = new BankAccountService(accountRepository);

            var exception_thrown = Assert.Catch<Exception>(() => bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));

            Assert.That(exception_thrown.Message, Does.Contain("Invalid bank account data!"));
        }

        [TestCase("NewName", "NewSurname", "NewTestAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        public void UpdateBankAccount_ValidData_NoException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            InterfaceBankAccountService bankAccountController = new BankAccountService(accountRepository);

            Assert.DoesNotThrow(() => bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));
        }

        [Test]
        public void GetBankAccount_IsCorrect_ReturnsBankAccount()
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            InterfaceBankAccountService bankAccountController = new BankAccountService(accountRepository);

            var result = bankAccountController.GetBankAccount();

            Assert.That(result, Is.EqualTo(bankAccount));
        }
    }
}