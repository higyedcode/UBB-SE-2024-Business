using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceGPT_ASP.NET_Repository.Models.SpartacusModels
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int NumberOfLikes { get; set; } = 0;

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(256)]
        public string ImagePath { get; set; }

        [Required]
        [MaxLength(512)]
        public string Caption { get; set; }

        [ForeignKey("Business")]
        [Required]
        public int BusinessId { get; set; }

        public List<int> CommentIds { get; set; } = new List<int>();
    }
}
