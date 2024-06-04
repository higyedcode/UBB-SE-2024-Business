using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT.Data.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Username { get; set; }

        [Required]
        [MaxLength(512)]
        public string Content { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        [Required]
        public DateTime DateOfUpdate { get; set; } = DateTime.Now;

        [ForeignKey("Post")]
        [Required]
        public int PostId { get; set; }
    }
}
