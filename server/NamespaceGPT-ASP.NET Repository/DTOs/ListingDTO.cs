using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.DTOs
{
    public class ListingDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MarketplaceId { get; set; }
        public int Price { get; set; } = 0;
    }
}
