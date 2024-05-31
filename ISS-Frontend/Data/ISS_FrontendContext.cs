using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ISS_Frontend.Models;
using ISS_Frontend.Entity;

namespace ISS_Frontend.Data
{
    public class ISS_FrontendContext : DbContext
    {
        public ISS_FrontendContext (DbContextOptions<ISS_FrontendContext> options)
            : base(options)
        {
        }

        public DbSet<ISS_Frontend.Models.BankAccount> BankAccount { get; set; } = default!;
        public DbSet<ISS_Frontend.Entity.Product> Product { get; set; } = default!;
        public DbSet<ISS_Frontend.Entity.AdAccount> AdAccount { get; set; } = default!;
        public DbSet<ISS_Frontend.Entity.Ad> Ad { get; set; } = default!;
        public DbSet<ISS_Frontend.Entity.ReviewClass> ReviewClass { get; set; } = default!;
    }
}
