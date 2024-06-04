using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public class Listing
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("Product")]
        [Required] public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [ForeignKey("Marketplace")]
        [Required] public int MarketplaceId { get; set; }
        public Marketplace Marketplace { get; set; } = null!;

        public int Price { get; set; } = 0;

        public ICollection<Sale> Sales { get; } = new List<Sale>();
        public ICollection<AdRecommendation> AdRecommendations { get; } = new List<AdRecommendation>();
    }
}
