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
        public DbSet<User> AppUser { get; set; } = null!;
        public DbSet<AdRecommendation> AdRecommendation { get; set; } = null!;
        public DbSet<BackInStockAlert> BackInStockAlerts { get; set; } = null!;
        public DbSet<FavouriteProduct> FavouriteProduct { get; set; } = null!;
        public DbSet<Listing> Listing { get; set; } = null!;
        public DbSet<Marketplace> Marketplace { get; set; } = null!;
        public DbSet<NewProductAlert> NewProductAlerts { get; set; } = null!;
        public DbSet<PriceDropAlert> PriceDropAlerts { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<Review> Review { get; set; } = null!;
        public DbSet<UserActivity> UserActivity { get; set; } = null!;
        public DbSet<Sale> Sale { get; set; } = default!;

        // SPARTACUS
        public DbSet<Account> Account { get; set; } = null!;
        public DbSet<Business> Business { get; set; } = null!;
        public DbSet<Comment> Comment { get; set; } = null!;
        public DbSet<FAQ> FAQ { get; set; } = default!;
        public DbSet<Post> Post { get; set; } = null!;
        public DbSet<SpartacusReview> SpartacusReview { get; set; } = null!;
    }
}
