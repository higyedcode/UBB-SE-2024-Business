using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT.Data.Models
{
    public class Review
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("Product")]
        [Required] public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [ForeignKey("User")]
        [Required] public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Required] [MaxLength(64)] public string Title { get; set; }

        [Required] public string Description { get; set; }

        [Required] public int Rating { get; set; }
    }
}