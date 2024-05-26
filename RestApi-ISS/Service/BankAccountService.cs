// <copyright file="BankAccountController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using Backend.Models;
using Iss.Repository;

namespace Iss.Service
{
    public class BankAccountService : InterfaceBankAccountService
    {
        private readonly IAccountRepository accountRepository;
        public BankAccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public void UpdateBankAccount(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            BankAccount updatedAccount = new ()
            {
                    Email = email,
                    Name = name,
                    Surname = surname,
                    PhoneNumber = phoneNumber,
                    County = county,
                    City = city,
                    Address = address,
                    Number = number,
                    HolderName = holderName,
                    ExpiryDate = expiryDate,
                };

                if (!Validate(updatedAccount))
                {
                    throw new Exception("Invalid bank account data!");
                }
                else
                {
                    accountRepository.EditBankAccount(updatedAccount);
                }
            }

            public BankAccount GetBankAccount()
            {
                return accountRepository.GetBankAccount();
            }

            public static bool Validate(BankAccount bankAccount)
        {
            // validate email
            var emailAttribute = new EmailAddressAttribute();
            if (bankAccount.Email == null || !emailAttribute.IsValid(bankAccount.Email))
            {
                return false;
            }

            // validate name
            if (bankAccount.Name == null || bankAccount.Name.Length < 2)
            {
                return false;
            }

            // validate surname
            if (bankAccount.Surname == null || bankAccount.Surname.Length < 2)
            {
                return false;
            }

            // validate phone number
            if (bankAccount.PhoneNumber == null)
            {
                return false;
            }

            if (bankAccount.PhoneNumber.Length < 9)
            {
                foreach (char currentCharacter in bankAccount.PhoneNumber)
                {
                    if (!char.IsDigit(currentCharacter))
                    {
                        return false;
                    }
                }
            }

            // validate county
            if (bankAccount.County == null || bankAccount.County.Length < 2)
            {
                return false;
            }

            // validate city
            if (bankAccount.City == null || bankAccount.City.Length < 2)
            {
                return false;
            }

            // validate address
            if (bankAccount.Address == null || bankAccount.Address.Length < 2)
            {
                return false;
            }

            // validate number
            if (bankAccount.Number == null)
            {
                return false;
            }

            if (bankAccount.Number.Length < 16)
            {
                foreach (char currentCharacter in bankAccount.Number)
                {
                    if (!char.IsDigit(currentCharacter))
                    {
                        return false;
                    }
                }
            }

            // validate holder name
            if (bankAccount.HolderName == null || bankAccount.HolderName.Length < 2)
            {
                return false;
            }

            // validate expiry date
            if (bankAccount.ExpiryDate == null || bankAccount.ExpiryDate.Length < 5)
            {
                return false;
            }

            return true;
        }
    }
}
