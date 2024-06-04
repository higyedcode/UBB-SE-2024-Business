using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public class PriceDropAlert : IAlert
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("User")]
        [Required] public int UserId { get; set; }
        public User User { get; set; } = null!;

        [ForeignKey("Product")]
        [Required] public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required][Column(TypeName = "decimal(18,2)")] public decimal OldPrice { get; set; }

        [Required][Column(TypeName = "decimal(18,2)")] public decimal NewPrice { get; set; }

        /*
        [NotMapped] public virtual IAlert IAlert { get; set; } = null!;
        [NotMapped] public virtual IAlert IAlert1 { get; set; } = null!;
        */

        public bool Equals(PriceDropAlert other)
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

            PriceDropAlert other = obj as PriceDropAlert;
            return Equals(other);
        }
        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
