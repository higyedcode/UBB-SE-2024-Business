using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT.Data.Models
{
    public class SpartacusReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string UserName { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required]
        [MaxLength(256)]
        public string ImagePath { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        [ForeignKey("SpartacusBusiness")]
        [Required]
        public int BusinessId { get; set; }

        [ForeignKey("AdminComment")]
        [Required]
        public int AdminCommentId { get; set; }
    }
}
