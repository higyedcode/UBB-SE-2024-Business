using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;
using Iss.Repository;
using Iss.Service;
using Moq;

using Xunit;

namespace Iss.Tests.Service
{
    public class CampaignServiceTest
    {
        private Campaign testingCampaign = new Campaign(campaignId: "1",
                                        campaignName: "New Campaign",
                                        startDate: DateTime.Now,
                                        duration: 50);
        private AdSet testingAdSet = new AdSet(id: "1",
                                    name: "New AdSet",
                                    targetAudience: "Gen Z");

        [Fact]
        public void AddCampaign_WhenCalled_CallsAddCampaignOnRepository()
        {
            // Arrange
            var mockCampaignRepository = new Mock<ICampaignRepository>();
            var campaignService = new CampaignService(mockCampaignRepository.Object);

            // Act
            campaignService.AddCampaign(testingCampaign);

            // Assert
            mockCampaignRepository.Verify(x => x.AddCampaign(testingCampaign), Times.Once);
        }

        [Fact]
        public void GetCampaignByName_WhenCalled_CallsGetCampaignByNameOnRepository()
        {
            // Arrange
            var mockCampaignRepository = new Mock<ICampaignRepository>();
            var campaignService = new CampaignService(mockCampaignRepository.Object);

            // Act
            campaignService.GetCampaignByName(testingCampaign);

            // Assert
            mockCampaignRepository.Verify(x => x.GetCampaignByName(testingCampaign), Times.Once);
        }

        [Fact]
        public void DeleteCampaign_WhenCalled_CallsDeleteCampaignOnRepository()
        {
            // Arrange
            var mockCampaignRepository = new Mock<ICampaignRepository>();
            var campaignService = new CampaignService(mockCampaignRepository.Object);

            // Act
            campaignService.DeleteCampaign(testingCampaign);

            // Assert
            mockCampaignRepository.Verify(x => x.DeleteCampaign(testingCampaign), Times.Once);
        }

        [Fact]
        public void AddAdSetToCampaign_WhenCalled_CallsAddAdSetToCampaignOnRepository()
        {
            // Arrange
            var mockCampaignRepository = new Mock<ICampaignRepository>();
            var campaignService = new CampaignService(mockCampaignRepository.Object);

            // Act
            campaignService.AddAdSetToCampaign(testingCampaign, testingAdSet);

            // Assert
            mockCampaignRepository.Verify(x => x.AddAdSetToCampaign(testingCampaign, testingAdSet), Times.Once);
        }

        [Fact]
        public void DeleteAdSetFromCampaign_WhenCalled_CallsDeleteAdSetFromCampaignOnRepository()
        {
            // Arrange
            var mockCampaignRepository = new Mock<ICampaignRepository>();
            var campaignService = new CampaignService(mockCampaignRepository.Object);

            // Act
            campaignService.DeleteAdSetFromCampaign(testingCampaign, testingAdSet);

            // Assert
            mockCampaignRepository.Verify(x => x.DeleteAdSetFromCampaign(testingCampaign, testingAdSet), Times.Once);
        }

        [Fact]
        public void UpdateCampaign_WhenCalled_CallsUpdateCampaignOnRepository()
        {
            // Arrange
            var mockCampaignRepository = new Mock<ICampaignRepository>();
            var campaignService = new CampaignService(mockCampaignRepository.Object);

            var updatedCampaign = new Campaign(campaignId: "1",
                                               campaignName: "Updated Campaign",
                                               startDate: DateTime.Now,
                                               duration: 51);

            // Act
            campaignService.UpdateCampaign(updatedCampaign);

            // Assert
            mockCampaignRepository.Verify(x => x.UpdateCampaign(updatedCampaign), Times.Once);
        }
    }
}
