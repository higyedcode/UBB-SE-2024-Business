using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace NamespaceGPT.Data.DTOs
{
    public class MarketplaceDTO
    {
        public int Id { get; set; }
        public string MarketplaceName { get; set; }
        public string WebsiteURL { get; set; }
        public string Country { get; set; }
    }
}
