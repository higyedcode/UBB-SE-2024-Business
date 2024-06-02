using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT.Data.Models
{
    public class COCFavouriteProduct
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("COCProduct")]
        [Required] public int ProductId { get; set; }
        public COCProduct Product { get; set; } = null!;

        [ForeignKey("User")]
        [Required] public int UserId { get; set; }
        public COCUser User { get; set; } = null!;
    }
}
