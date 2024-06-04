using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.DTOs
{
    public class AdRecommendationDTO
    {
        public int Id { get; set; }
        public int ListingId { get; set; } = 0;
    }
}
