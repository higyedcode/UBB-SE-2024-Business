using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT.Data.Models
{
    public class FavouriteProduct
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("Product")]
        [Required] public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [ForeignKey("User")]
        [Required] public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
