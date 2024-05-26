using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Iss.Entity;
using Iss.Repository;
using Iss.Service;
using Moq;

namespace Iss.Tests.Service
{
    public class AdAccountServiceTest
    {
        // string adAccountId, string nameOfCompany, string domainOfActivity, string siteUrl,
        // string password, string taxIdentificationNumber,
        // string headquartersLocation, string authorisingInstituion
        private AdAccount testingAccount = new AdAccount("1", "name", "domain", "site", "password", "tax", "location", "institution");

        [Fact]
        public void AddAccount_WhenCalled_CallsAddAccountOnRepository()
        {
            // Arrange
            var mockAdAccountRepository = new Mock<IAdAccountRepository>();
            var adAccountService = new AdAccountService(mockAdAccountRepository.Object);

            // Act
            adAccountService.AddAdAccount(testingAccount);

            // Assert
            mockAdAccountRepository.Verify(x => x.AddAdAccount(testingAccount), Times.Once);
        }

        /*
        [Fact]
        public void Login_WhenCalled_CallsGetAdAccountOnRepository()
        {
            //Arrange
            var mockAdAccountRepository = new Mock<IAdAccountRepository>();
            var adAccountService = new AdAccountService(mockAdAccountRepository.Object);

            //Add account to repository
            adAccountService.addAdAccount(testingAccount);

            //Act
            adAccountService.login("name", "password");

            //Assert
            mockAdAccountRepository.Verify(x => x.getAdAccount("name", "password"), Times.Once);
        }
        */

        [Fact]
        public void Login_WhenCalled_ThrowsExceptionIfAccountNotFound()
        {
            // Arrange
            var mockAdAccountRepository = new Mock<IAdAccountRepository>();
            var adAccountService = new AdAccountService(mockAdAccountRepository.Object);

            // Act
            Action act = () => adAccountService.Login("name", "password");

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void GetAdsForCurrentUser_WhenCalled_CallsGetAdsForCurrentUserOnRepository()
        {
            // Arrange
            var mockAdAccountRepository = new Mock<IAdAccountRepository>();
            var adAccountService = new AdAccountService(mockAdAccountRepository.Object);

            // Act
            adAccountService.GetAdsForCurrentUser();

            // Assert
            mockAdAccountRepository.Verify(x => x.GetAdsForCurrentUser(), Times.Once);
        }

        [Fact]
        public void GetAdSetsForCurrentUser_WhenCalled_CallsGetAdSetsForCurrentUserOnRepository()
        {
            // Arrange
            var mockAdAccountRepository = new Mock<IAdAccountRepository>();
            var adAccountService = new AdAccountService(mockAdAccountRepository.Object);

            // Act
            adAccountService.GetAdSetsForCurrentUser();

            // Assert
            mockAdAccountRepository.Verify(x => x.GetAdSetsForCurrentUser(), Times.Once);
        }

        [Fact]
        public void GetCampaignsForCurrentUser_WhenCalled_CallsGetCampaignsForCurrentUserOnRepository()
        {
            // Arrange
            var mockAdAccountRepository = new Mock<IAdAccountRepository>();
            var adAccountService = new AdAccountService(mockAdAccountRepository.Object);

            // Act
            adAccountService.GetCampaignsForCurrentUser();

            // Assert
            mockAdAccountRepository.Verify(x => x.GetCampaignsForCurrentUser(), Times.Once);
        }

        [Fact]
        public void EditAdAccount_WhenCalled_CallsEditAdAccountOnRepository()
        {
            // Arrange
            var mockAdAccountRepository = new Mock<IAdAccountRepository>();
            var adAccountService = new AdAccountService(mockAdAccountRepository.Object);

            // Act
            adAccountService.EditAdAccount("name", "site", "password", "location");

            // Assert
            mockAdAccountRepository.Verify(x => x.EditAdAccount("name", "site", "password", "location"), Times.Once);
        }
    }
}
