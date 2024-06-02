using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public class COCNewProductAlert : IAlert
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("COCProduct")]
        [Required] public int ProductId { get; set; }
        public COCProduct Product { get; set; } = null!;

        [ForeignKey("User")]
        [Required] public int UserId { get; set; }
        public COCUser User { get; set; } = null!;

        /*
        [NotMapped] public virtual IAlert IAlert { get; set; } = null!;
        */

        public bool Equals(COCNewProductAlert other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id &&
                this.UserId == other.UserId &&
                this.ProductId == other.ProductId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            COCNewProductAlert other = obj as COCNewProductAlert;
            return Equals(other);
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
