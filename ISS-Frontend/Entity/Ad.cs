using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISS_Frontend.Entity
{
    public class Ad
    {
        /// <summary>
        /// Gets or sets the ID of the advertisement.
        /// </summary>
        public string AdId { get; set; }

        public string AdAccountId { get; set; }

        public string AdSetId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product being advertised.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the path to the photo associated with the advertisement.
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Gets or sets the description of the product being advertised.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the website link related to the advertisement.
        /// </summary>
        public string WebsiteLink { get; set; }

        public Ad()
        {
        }

        public Ad(string adId, string adAccountId, string adSetId, string productName, string photo, string description, string websiteLink)
        {
            this.AdId = adId;
            this.AdAccountId = adAccountId;
            this.AdSetId = adSetId;
            this.ProductName = productName;
            this.Photo = photo;
            this.Description = description;
            this.WebsiteLink = websiteLink;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ad"/> class.
        /// </summary>
        /// <param name="productName">The name of the product being advertised.</param>
        /// <param name="photo">The path to the photo associated with the advertisement.</param>
        /// <param name="description">The description of the product being advertised.</param>
        /// <param name="websiteLink">The website link related to the advertisement.</param>
        public Ad(string productName, string photo, string description, string websiteLink)
        {
            this.ProductName = productName;
            this.Photo = photo;
            this.Description = description;
            this.WebsiteLink = websiteLink;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ad"/> class.
        /// </summary>
        /// <param name="id">The ID of the advertisement.</param>
        /// <param name="productName">The name of the product being advertised.</param>
        /// <param name="photo">The path to the photo associated with the advertisement.</param>
        /// <param name="description">The description of the product being advertised.</param>
        /// <param name="websiteLink">The website link related to the advertisement.</param>
        public Ad(string id, string productName, string photo, string description, string websiteLink)
        {
            this.AdId = id;
            this.ProductName = productName;
            this.Photo = photo;
            this.Description = description;
            this.WebsiteLink = websiteLink;
        }

        /// <summary>
        /// Returns a string that represents the current advertisement.
        /// </summary>
        /// <returns>A string containing the product name, description, and website link.</returns>
        public override string ToString()
        {
            return "PRODUCT NAME: " + ProductName + "-" + "DESCRIPTION: " + Description + "-" + "URL: " + WebsiteLink;
        }
    }
}
