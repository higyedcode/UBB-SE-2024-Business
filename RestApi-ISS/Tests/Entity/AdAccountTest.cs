using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Iss.Entity;

namespace Iss.Tests.Entity
{
    public class AdAccountTest
    {
        [Fact]
        public void Constructor_WithAllParameters_CorrectInitialization()
        {
            // Arrange
            string id = "1";
            string nameOfCompany = "Company";
            string domainOfActivity = "Domain";
            string siteUrl = "Site";
            string password = "Password";
            string taxIdentificationNumber = "TIN";
            string headquartersLocation = "Location";
            string authorisingInstituion = "Institution";

            // Act
            AdAccount adAccount = new AdAccount(id, nameOfCompany, domainOfActivity, siteUrl, password, taxIdentificationNumber, headquartersLocation, authorisingInstituion);

            // Assert
            Assert.Equal(id, adAccount.AdAccountId);
            Assert.Equal(nameOfCompany, adAccount.NameOfCompany);
            Assert.Equal(domainOfActivity, adAccount.DomainOfActivity);
            Assert.Equal(siteUrl, adAccount.SiteUrl);
            Assert.Equal(password, adAccount.Password);
            Assert.Equal(taxIdentificationNumber, adAccount.TaxIdentificationNumber);
            Assert.Equal(headquartersLocation, adAccount.HeadquartersLocation);
            Assert.Equal(authorisingInstituion, adAccount.AuthorisingInstituion);
        }

        [Fact]
        public void Constructor_WithSelectedParameters_CorrectInitialization()
        {
            // Arrange
            string nameOfCompany = "Company";
            string domainOfActivity = "Domain";
            string siteUrl = "Site";
            string password = "Password";
            string taxIdentificationNumber = "TIN";
            string headquartersLocation = "Location";
            string authorisingInstituion = "Institution";

            // Act
            AdAccount adAccount = new AdAccount(nameOfCompany, domainOfActivity, siteUrl, password, taxIdentificationNumber, headquartersLocation, authorisingInstituion);

            // Assert
            Assert.Equal(nameOfCompany, adAccount.NameOfCompany);
            Assert.Equal(domainOfActivity, adAccount.DomainOfActivity);
            Assert.Equal(siteUrl, adAccount.SiteUrl);
            Assert.Equal(password, adAccount.Password);
            Assert.Equal(taxIdentificationNumber, adAccount.TaxIdentificationNumber);
            Assert.Equal(headquartersLocation, adAccount.HeadquartersLocation);
            Assert.Equal(authorisingInstituion, adAccount.AuthorisingInstituion);
        }
    }
}
