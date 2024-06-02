using Microsoft.EntityFrameworkCore;
using NamespaceGPT.Data.Models;
using NamespaceGPT_ASP.NET_Repository.Models.SpartacusModels;

namespace NamespaceGPT_ASP.NET_Repository.DatabaseContext
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options)
        {
        }

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
    }
}
