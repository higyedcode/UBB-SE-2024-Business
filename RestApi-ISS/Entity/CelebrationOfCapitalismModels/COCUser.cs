using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NamespaceGPT.Data.Models
{
    public class COCUser
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [Required] [MaxLength(64)] public string Username { get; set; }
        [Required] [MaxLength(64)] public string Password { get; set; }

        public ICollection<COCSale> Sales { get; } = new List<COCSale>();
        public ICollection<COCUserActivity> UserActivities { get; } = new List<COCUserActivity>();
        public ICollection<COCReview> Review { get; } = new List<COCReview>();
        public ICollection<COCFavouriteProduct> FavouriteProducts { get; } = new List<COCFavouriteProduct>();

        public ICollection<COCNewProductAlert> NewProductAlerts { get; } = new List<COCNewProductAlert>();
        public ICollection<COCBackInStockAlert> BackInStockAlerts { get; } = new List<COCBackInStockAlert>();
        public ICollection<COCPriceDropAlert> PriceDropAlerts { get; } = new List<COCPriceDropAlert>();
    }
}
