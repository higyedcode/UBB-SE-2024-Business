using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS_Frontend.Entity
{
    public class AdAccount
    {
        public string AdAccountId { get; set; }
        public string NameOfCompany { get; set; }
        public string DomainOfActivity { get; set; }
        public string SiteUrl { get; set; }
        public string Password { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string HeadquartersLocation { get; set; }
        public string AuthorisingInstituion { get; set; }
        public List<Ad> Ads { get; set; }
        public List<AdSet> AdSets { get; set; }
        public List<Campaign> Campaigns { get; set; }
        public List<Collaboration> Collaborations { get; set; }

        public List<IOneTimePayment> OneTimePayments = new List<IOneTimePayment>();
        /*List<Ad> ads = new List<Ad>();
        List<AdSet> adSets = new List<AdSet>();
        List<Campaign> campaigns = new List<Campaign>();
        List<Collaboration> collaborations = new List<Collaboration>();
        List<Request> requests = new List<Request>();
        ISubscription? subscription;*/

        public AdAccount()
        {
        }

        public AdAccount(string id, string nameOfCompany, string domainOfActivity, string siteUrl, string password, string taxIdentificationNumber, string headquartersLocation, string authorisingInstituion)
        {
            this.AdAccountId = id;
            this.NameOfCompany = nameOfCompany;
            this.DomainOfActivity = domainOfActivity;
            this.SiteUrl = siteUrl;
            this.Password = password;
            this.TaxIdentificationNumber = taxIdentificationNumber;
            this.HeadquartersLocation = headquartersLocation;
            this.AuthorisingInstituion = authorisingInstituion;
        }

        public AdAccount(string nameOfCompany, string domainOfActivity, string siteUrl, string password, string taxIdentificationNumber, string headquartersLocation, string authorisingInstituion)
        {
            this.NameOfCompany = nameOfCompany;
            this.DomainOfActivity = domainOfActivity;
            this.SiteUrl = siteUrl;
            this.Password = password;
            this.TaxIdentificationNumber = taxIdentificationNumber;
            this.HeadquartersLocation = headquartersLocation;
            this.AuthorisingInstituion = authorisingInstituion;
        }

        public List<IOneTimePayment> GetPayments()
        {
            return OneTimePayments;
        }
    }
}
