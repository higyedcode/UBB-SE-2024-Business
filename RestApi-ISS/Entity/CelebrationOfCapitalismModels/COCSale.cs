using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT.Data.Models
{
    public class COCSale
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("User")]
        [Required] public int UserId { get; set; }
        public COCUser User { get; set; } = null!;

        [ForeignKey("COCListing")]
        [Required] public int ListingId { get; set; }
        public COCListing Listing { get; set; } = null!;
    }
}
