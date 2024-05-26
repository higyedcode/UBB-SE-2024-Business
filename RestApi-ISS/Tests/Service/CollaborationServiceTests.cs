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
    public class CollaborationServiceTests
    {
        [Fact]
        public void AddCollaboration_WhenCalled_CallsCreateCollaborationOnRepository()
        {
            // Arrange
            var mockCollaborationRepository = new Mock<IColaborationRepository>();
            var collaborationService = new CollaborationService(mockCollaborationRepository.Object);

            var collaboration = new Collaboration(
            collaborationId: 1,
            startDate: DateTime.Now,
            status: true,
            contentRequirement: "Content requirement",
            adOverview: "Ad overview",
            collaborationFee: "100",
            days: 7,
            collaborationTitle: "Collaboration Title");

            // Act
            collaborationService.AddCollaboration(collaboration);

            // Assert
            mockCollaborationRepository.Verify(x => x.CreateCollaboration(collaboration), Times.Once);
        }

        [Fact]
        public void GetCollaborationForAdAccount_WhenCalled_CallsGetCollaborationsForAdAccountOnRepository()
        {
            // Arrange
            var mockCollaborationRepository = new Mock<IColaborationRepository>();
            var collaborationService = new CollaborationService(mockCollaborationRepository.Object);

            // Act
            var result = collaborationService.GetCollaborationForAdAccount();

            // Assert
            mockCollaborationRepository.Verify(x => x.GetCollaborationsForAdAccount(), Times.Once);
        }

        [Fact]
        public void GetCollaborationForInfluencer_WhenCalled_CallsGetCollaborationsForInfluencerOnRepository()
        {
            // Arrange
            var mockCollaborationRepository = new Mock<IColaborationRepository>();
            var collaborationService = new CollaborationService(mockCollaborationRepository.Object);

            // Act
            var result = collaborationService.GetCollaborationForInfluencer();

            // Assert
            mockCollaborationRepository.Verify(x => x.GetCollaborationsForInfluencer(), Times.Once);
        }

        [Fact]
        public void GetActiveCollaborationForAdAccount_WhenCalled_ReturnsActiveCollaborations()
        {
            // Arrange
            var mockCollaborationRepository = new Mock<IColaborationRepository>();
            var collaborationService = new CollaborationService(mockCollaborationRepository.Object);

            var activeCollaborations = new List<Collaboration>(); // Add some active collaborations
            mockCollaborationRepository.Setup(x => x.GetCollaborationsForAdAccount()).Returns(activeCollaborations);

            // Act
            var result = collaborationService.GetActiveCollaborationForAdAccount();

            // Assert
            Assert.Equal(activeCollaborations, result);
        }
    }
}
