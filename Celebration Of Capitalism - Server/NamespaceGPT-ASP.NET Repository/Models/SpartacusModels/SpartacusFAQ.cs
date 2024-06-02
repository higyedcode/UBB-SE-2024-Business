using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT.Data.Models
{
    public class SpartacusFAQ
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Question { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Answer { get; set; }

        [ForeignKey("SpartacusBusiness")]
        [Required]
        public int BusinessId { get; set; }
    }
}
