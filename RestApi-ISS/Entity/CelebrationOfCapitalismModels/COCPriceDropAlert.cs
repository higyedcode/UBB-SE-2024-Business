using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public class COCPriceDropAlert : IAlert
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("User")]
        [Required] public int UserId { get; set; }
        public COCUser User { get; set; } = null!;

        [ForeignKey("COCProduct")]
        [Required] public int ProductId { get; set; }
        public COCProduct Product { get; set; } = null!;

        [Required][Column(TypeName = "decimal(18,2)")] public decimal OldPrice { get; set; }

        [Required][Column(TypeName = "decimal(18,2)")] public decimal NewPrice { get; set; }

        /*
        [NotMapped] public virtual IAlert IAlert { get; set; } = null!;
        [NotMapped] public virtual IAlert IAlert1 { get; set; } = null!;
        */

        public bool Equals(COCPriceDropAlert other)
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

            COCPriceDropAlert other = obj as COCPriceDropAlert;
            return Equals(other);
        }
        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
