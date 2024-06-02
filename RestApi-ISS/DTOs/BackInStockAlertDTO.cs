using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.DTOs
{
    public class BackInStockAlertDTO : IAlert
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int MarketplaceId { get; set; }

        /*
        [NotMapped] public virtual IAlert IAlert { get; set; } = null!;
        [NotMapped] public virtual IAlert IAlert1 { get; set; } = null!;
        */

        public bool Equals(BackInStockAlertDTO other)
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

            BackInStockAlertDTO other = obj as BackInStockAlertDTO;
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
