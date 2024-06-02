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

using NamespaceGPT.Data.Models;
using NamespaceGPT_ASP.NET_Repository.Models.SpartacusModels;

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
        public DbSet<Product> Product { get; set; }
        public DbSet<ReviewClass> Review { get; set; }

        // CELEBRATION OF CAPITALISM
        public DbSet<COCUser> COCUser { get; set; } = null!;
        public DbSet<COCAdRecommendation> COCAdRecommendation { get; set; } = null!;
        public DbSet<COCBackInStockAlert> COCBackInStockAlerts { get; set; } = null!;
        public DbSet<COCFavouriteProduct> COCFavouriteProduct { get; set; } = null!;
        public DbSet<COCListing> COCListing { get; set; } = null!;
        public DbSet<COCMarketplace> COCMarketplace { get; set; } = null!;
        public DbSet<COCNewProductAlert> COCNewProductAlerts { get; set; } = null!;
        public DbSet<COCPriceDropAlert> COCPriceDropAlerts { get; set; } = null!;
        public DbSet<COCProduct> COCProduct { get; set; } = null!;
        public DbSet<COCReview> COCReview { get; set; } = null!;
        public DbSet<COCUserActivity> COCUserActivity { get; set; } = null!;
        public DbSet<COCSale> COCSale { get; set; } = default!;

        // SPARTACUS
        public DbSet<SpartacusAccount> SpartacusAccount { get; set; } = null!;
        public DbSet<SpartacusBusiness> SpartacusBusiness { get; set; } = null!;
        public DbSet<SpartacusComment> SpartacusComment { get; set; } = null!;
        public DbSet<SpartacusFAQ> SpartacusFAQ { get; set; } = default!;
        public DbSet<SpartacusPost> SpartacusPost { get; set; } = null!;
        public DbSet<SpartacusReview> SpartacusReview { get; set; } = null!;

        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; Initial Catalog = db_ISS; Integrated Security = True; TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-MAIN;Initial Catalog=FinalVersionDatabase;Integrated Security=true;TrustServerCertificate=Yes;Encrypt=False;");
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
    }
}