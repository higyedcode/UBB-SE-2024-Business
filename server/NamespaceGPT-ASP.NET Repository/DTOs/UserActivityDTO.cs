using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NamespaceGPT.Data.DTOs
{
    public class UserActivityDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ActionType { get; set; }
    }
}
