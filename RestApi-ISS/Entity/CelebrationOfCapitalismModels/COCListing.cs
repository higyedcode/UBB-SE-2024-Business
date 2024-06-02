using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public class COCListing
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("COCProduct")]
        [Required] public int ProductId { get; set; }
        public COCProduct Product { get; set; } = null!;

        [ForeignKey("COCMarketplace")]
        [Required] public int MarketplaceId { get; set; }
        public COCMarketplace Marketplace { get; set; } = null!;

        public int Price { get; set; } = 0;

        public ICollection<COCSale> Sales { get; } = new List<COCSale>();
        public ICollection<COCAdRecommendation> AdRecommendations { get; } = new List<COCAdRecommendation>();
    }
}
