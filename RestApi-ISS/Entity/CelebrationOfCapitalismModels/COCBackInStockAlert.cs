using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public class COCBackInStockAlert : IAlert
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("User")]
        [Required] public int UserId { get; set; }
        public COCUser User { get; set; } = null!;

        [ForeignKey("COCProduct")]
        [Required] public int ProductId { get; set; }
        public COCProduct Product { get; set; } = null!;

        [ForeignKey("COCMarketplace")]
        [Required] public int MarketplaceId { get; set; }
        public COCMarketplace Marketplace { get; set; } = null!;

        /*
        [NotMapped] public virtual IAlert IAlert { get; set; } = null!;
        [NotMapped] public virtual IAlert IAlert1 { get; set; } = null!;
        */

        public bool Equals(COCBackInStockAlert other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id &&
                this.UserId == other.UserId &&
                this.ProductId == other.ProductId &&
                this.MarketplaceId == other.MarketplaceId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            COCBackInStockAlert other = obj as COCBackInStockAlert;
            return Equals(other);
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return (Id, UserId, ProductId, MarketplaceId).GetHashCode();
        }
    }
}
