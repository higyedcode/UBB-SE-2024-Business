using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT.Data.Models
{
    public class COCReview
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("COCProduct")]
        [Required] public int ProductId { get; set; }
        public COCProduct Product { get; set; } = null!;

        [ForeignKey("User")]
        [Required] public int UserId { get; set; }
        public COCUser User { get; set; } = null!;

        [Required] [MaxLength(64)] public string Title { get; set; }

        [Required] public string Description { get; set; }

        [Required] public int Rating { get; set; }
    }
}