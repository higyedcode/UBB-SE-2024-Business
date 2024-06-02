using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT.Data.Models
{
    public class Product
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required][MaxLength(64)] public string Name { get; set; } = string.Empty;
        [Required][MaxLength(64)] public string Category { get; set; } = string.Empty;
        [Required][MaxLength(64)] public string Brand { get; set; } = string.Empty;
        [Required] public string Description { get; set; } = string.Empty;
        [Required] public string ImageURL { get; set; } = string.Empty;
        [Required] public string Attributes { get; set; } = string.Empty;
        [NotMapped] public IDictionary<string, string> AttributesDict { get; set; } = new Dictionary<string, string>();

        public ICollection<Review> Reviews { get; } = new List<Review>();
        public ICollection<FavouriteProduct> FavouriteProducts { get; } = new List<FavouriteProduct>();
        public ICollection<Listing> Listings { get; } = new List<Listing>();

        public ICollection<NewProductAlert> NewProductAlerts { get; } = new List<NewProductAlert>();
        public ICollection<BackInStockAlert> BackInStockAlerts { get; } = new List<BackInStockAlert>();
        public ICollection<PriceDropAlert> PriceDropAlerts { get; } = new List<PriceDropAlert>();
    }
}
