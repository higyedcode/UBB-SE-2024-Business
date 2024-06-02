using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace NamespaceGPT.Data.Models
{
    public class COCMarketplace
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required][MaxLength(64)] public string MarketplaceName { get; set; }
        [Required] public string WebsiteURL { get; set; }
        [Required] public string Country { get; set; }

        public ICollection<COCListing> Listings { get; } = new List<COCListing>();

        public ICollection<COCNewProductAlert> NewProductAlerts { get; } = new List<COCNewProductAlert>();
        public ICollection<COCBackInStockAlert> BackInStockAlerts { get; } = new List<COCBackInStockAlert>();
        public ICollection<COCPriceDropAlert> PriceDropAlerts { get; } = new List<COCPriceDropAlert>();
    }
}
