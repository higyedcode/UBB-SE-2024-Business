// <copyright file="BankAccount.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    [PrimaryKey(nameof(Id))]
    public class BankAccount
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }

        public string? County { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        public string? Number { get; set; }

        public string? HolderName { get; set; }

        public string? ExpiryDate { get; set; }

        /*

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + (Email?.GetHashCode() ?? 0);
                hash = (hash * 23) + (Name?.GetHashCode() ?? 0);
                hash = (hash * 23) + (Surname?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is BankAccount other)
            {
                return this.Email == other.Email &&
                       this.Name == other.Name &&
                       this.Surname == other.Surname &&
                       this.PhoneNumber == other.PhoneNumber &&
                       this.County == other.County &&
                       this.City == other.City &&
                       this.Address == other.Address &&
                       this.Number == other.Number &&
                       this.HolderName == other.HolderName &&
                       this.ExpiryDate == other.ExpiryDate;
            }

            return false;
        }
        */
    }
}
