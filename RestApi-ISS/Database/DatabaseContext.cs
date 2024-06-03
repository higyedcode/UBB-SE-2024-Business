using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Models;
using Iss.Entity;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using RestApi_ISS.Entity;
using Iss.User;

namespace Iss.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Ad> Ad { get; set; }
        public DbSet<AdAccount> AdAccount { get; set; }
        public DbSet<AdSet> AdSet { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Collaboration> Collaboration { get; set; }
        public DbSet<Influencer> Influencer { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<FAQ> FAQ { get; set; }

        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }

        public DbSet<ReviewClass> Review { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; Initial Catalog = db_ISS; Integrated Security = True; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Ad>()
                .Property(a => a.AdId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Ad>()
                .Property(a => a.AdSetId)
                .IsRequired(false);

            modelBuilder.Entity<AdAccount>()
                .Property(a => a.AdAccountId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AdSet>()
                .Property(a => a.AdSetId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AdSet>()
                .Property(a => a.CampaignId)
                .IsRequired(false);

            modelBuilder.Entity<Campaign>()
                .Property(c => c.CampaignId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Collaboration>()
                .Property(c => c.CollaborationId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Influencer>()
                .Property(i => i.InfluencerId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Request>()
                .Property(r => r.RequestId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<FAQ>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Campaign>()
                .HasOne(campaign => campaign.AdAccount)
                .WithMany(adAccount => adAccount.Campaigns)
                .HasForeignKey(campaign => campaign.AdAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReviewClass>()
                .HasNoKey();

            modelBuilder.Entity<ReviewClass>()
                .Property(a => a.User);

            modelBuilder.Entity<BankAccount>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();
        }
        public DbSet<Iss.User.User> User { get; set; } = default!;
        public DbSet<Iss.User.User> Users { get; set; } = default!;
    }
}