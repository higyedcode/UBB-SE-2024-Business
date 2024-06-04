using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.DTOs
{
    public class NewProductAlertDTO : IAlert
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

        /*
        [NotMapped] public virtual IAlert IAlert { get; set; } = null!;
        */

        public bool Equals(NewProductAlertDTO other)
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

            NewProductAlertDTO other = obj as NewProductAlertDTO;
            return Equals(other);
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
