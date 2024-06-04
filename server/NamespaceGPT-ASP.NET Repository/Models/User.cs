using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NamespaceGPT.Data.Models
{
    public class User
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [Required] [MaxLength(64)] public string Username { get; set; }
        [Required] [MaxLength(64)] public string Password { get; set; }

        public ICollection<Sale> Sales { get; } = new List<Sale>();
        public ICollection<UserActivity> UserActivities { get; } = new List<UserActivity>();
        public ICollection<Review> Review { get; } = new List<Review>();
        public ICollection<FavouriteProduct> FavouriteProducts { get; } = new List<FavouriteProduct>();

        public ICollection<NewProductAlert> NewProductAlerts { get; } = new List<NewProductAlert>();
        public ICollection<BackInStockAlert> BackInStockAlerts { get; } = new List<BackInStockAlert>();
        public ICollection<PriceDropAlert> PriceDropAlerts { get; } = new List<PriceDropAlert>();
    }
}
