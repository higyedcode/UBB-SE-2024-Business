using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.DTOs
{
    public class PriceDropAlertDTO : IAlert
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }

        /*
        [NotMapped] public virtual IAlert IAlert { get; set; } = null!;
        [NotMapped] public virtual IAlert IAlert1 { get; set; } = null!;
        */

        public bool Equals(PriceDropAlertDTO other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id &&
                this.UserId == other.UserId &&
                this.ProductId == other.ProductId &&
                this.OldPrice == other.OldPrice &&
                this.NewPrice == other.NewPrice;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            PriceDropAlertDTO other = obj as PriceDropAlertDTO;
            return Equals(other);
        }
        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
