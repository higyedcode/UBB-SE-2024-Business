using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public class NewProductAlert : IAlert
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("Product")]
        [Required] public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [ForeignKey("User")]
        [Required] public int UserId { get; set; }
        public User User { get; set; } = null!;

        /*
        [NotMapped] public virtual IAlert IAlert { get; set; } = null!;
        */

        public bool Equals(NewProductAlert other)
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

            NewProductAlert other = obj as NewProductAlert;
            return Equals(other);
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
