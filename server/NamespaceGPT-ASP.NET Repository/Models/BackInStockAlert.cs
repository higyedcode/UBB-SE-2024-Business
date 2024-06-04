using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public class BackInStockAlert : IAlert
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("User")]
        [Required] public int UserId { get; set; }
        public User User { get; set; } = null!;

        [ForeignKey("Product")]
        [Required] public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [ForeignKey("Marketplace")]
        [Required] public int MarketplaceId { get; set; }
        public Marketplace Marketplace { get; set; } = null!;

        /*
        [NotMapped] public virtual IAlert IAlert { get; set; } = null!;
        [NotMapped] public virtual IAlert IAlert1 { get; set; } = null!;
        */

        public bool Equals(BackInStockAlert other)
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

            BackInStockAlert other = obj as BackInStockAlert;
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
