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
    public class Marketplace
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required][MaxLength(64)] public string MarketplaceName { get; set; }
        [Required] public string WebsiteURL { get; set; }
        [Required] public string Country { get; set; }

        public ICollection<Listing> Listings { get; } = new List<Listing>();

        public ICollection<NewProductAlert> NewProductAlerts { get; } = new List<NewProductAlert>();
        public ICollection<BackInStockAlert> BackInStockAlerts { get; } = new List<BackInStockAlert>();
        public ICollection<PriceDropAlert> PriceDropAlerts { get; } = new List<PriceDropAlert>();
    }
}
