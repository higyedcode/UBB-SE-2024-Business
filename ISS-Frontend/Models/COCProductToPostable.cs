using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celebration_Of_Capitalism___The_Finale.Models
{
    //TODO: whoever made this class is evil - it looks identical to Product, there's no need to Wrap this.
    public class COCProductToPostable
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public string Attributes { get; set; } = string.Empty;
    }
}
