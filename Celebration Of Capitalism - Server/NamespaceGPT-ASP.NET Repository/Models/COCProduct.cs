using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT.Data.Models
{
    public class COCProduct
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required][MaxLength(64)] public string Name { get; set; } = string.Empty;
        [Required][MaxLength(64)] public string Category { get; set; } = string.Empty;
        [Required][MaxLength(64)] public string Brand { get; set; } = string.Empty;
        [Required] public string Description { get; set; } = string.Empty;
        [Required] public string ImageURL { get; set; } = string.Empty;
        [Required] public string Attributes { get; set; } = string.Empty;
        [NotMapped] public IDictionary<string, string> AttributesDict { get; set; } = new Dictionary<string, string>();

        public ICollection<COCReview> Reviews { get; } = new List<COCReview>();
        public ICollection<COCFavouriteProduct> FavouriteProducts { get; } = new List<COCFavouriteProduct>();
        public ICollection<COCListing> Listings { get; } = new List<COCListing>();

        public ICollection<COCNewProductAlert> NewProductAlerts { get; } = new List<COCNewProductAlert>();
        public ICollection<COCBackInStockAlert> BackInStockAlerts { get; } = new List<COCBackInStockAlert>();
        public ICollection<COCPriceDropAlert> PriceDropAlerts { get; } = new List<COCPriceDropAlert>();
    }
}
