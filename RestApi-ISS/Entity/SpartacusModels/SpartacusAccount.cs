using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT.Data.Models
{
    public class SpartacusAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Username { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; }

        [Required]
        [MaxLength(64)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(64)]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }
    }
}
