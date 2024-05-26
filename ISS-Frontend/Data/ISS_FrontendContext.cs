using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ISS_Frontend.Models;

namespace ISS_Frontend.Data
{
    public class ISS_FrontendContext : DbContext
    {
        public ISS_FrontendContext (DbContextOptions<ISS_FrontendContext> options)
            : base(options)
        {
        }

        public DbSet<ISS_Frontend.Models.BankAccount> BankAccount { get; set; } = default!;
    }
}
