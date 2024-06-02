using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT.Data.Models
{
    public class SpartacusBusiness
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(512)]
        public string Description { get; set; }

        [Required]
        [MaxLength(64)]
        public string Category { get; set; }

        [MaxLength(256)]
        public string LogoFileName { get; set; }

        [MaxLength(2048)]
        public string Logo { get; set; }

        [MaxLength(512)]
        public string BannerShort { get; set; }

        [MaxLength(2048)]
        public string Banner { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(128)]
        public string Website { get; set; }

        [Required]
        [MaxLength(256)]
        public string Address { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<string> ManagerUsernames { get; set; } = new List<string>();

        public List<int> PostIds { get; set; } = new List<int>();

        public List<int> ReviewIds { get; set; } = new List<int>();

        public List<int> FaqIds { get; set; } = new List<int>();
    }
}
