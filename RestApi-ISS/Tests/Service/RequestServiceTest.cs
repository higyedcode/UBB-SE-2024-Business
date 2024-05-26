using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Moq;

using Iss.Entity;
using Iss.Repository;
using Iss.Service;

namespace Iss.Tests.Service
{
    public class RequestServiceTest
    {
        private Request testingRequest = new Request(
            "title", "adOverview", "contentRequirement", "compensation", DateTime.Now, DateTime.Now.AddDays(7), true, true);

        private List<Request> testingRequestList = new List<Request>
        {
            new Request("title1", "adOverview1", "contentRequirement1", "compensation1", DateTime.Now, DateTime.Now.AddDays(7), true, true),
            new Request("title2", "adOverview2", "contentRequirement2", "compensation2", DateTime.Now, DateTime.Now.AddDays(7), true, true),
            new Request("title3", "adOverview3", "contentRequirement3", "compensation3", DateTime.Now, DateTime.Now.AddDays(7), true, true)
        };

        [Fact]
        public void AddRequest_WhenCalled_CallsAddRequestOnRepository()
        {
            // Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            // Act
            requestService.AddRequest(testingRequest);

            // Assert
            mockRequestRepository.Verify(x => x.AddRequest(testingRequest), Times.Once);
        }

        [Fact]
        public void DeleteRequest_WhenCalled_CallsDeleteRequestOnRepository()
        {
            // Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            // Act
            requestService.DeleteRequest(testingRequest);

            // Assert
            mockRequestRepository.Verify(x => x.DeleteRequest(testingRequest), Times.Once);
        }

        [Fact]
        public void GetInfluencerId_WhenCalled_CallsGetInfluencerIdOnRepository()
        {
            // Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            // Act
            requestService.GetInfluencerId();

            // Assert
            mockRequestRepository.Verify(x => x.GetInfluencerId(), Times.Once);
        }

        [Fact]
        public void GetRequestsForInfluencer_WhenCalled_CallsGetRequestsForInfluencerOnRepository()
        {
            // Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            // Act
            requestService.GetRequestsForInfluencer();

            // Assert
            mockRequestRepository.Verify(x => x.GetRequestsForInfluencer(), Times.Once);
        }

        [Fact]
        public void GetRequestWithTitle_WhenCalled_CallsGetRequestsListOnRepository()
        {
            // Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            requestService.AddRequest(testingRequest);

            // Act
            requestService.GetRequestWithTitle("title");

            // Assert
            mockRequestRepository.Verify(x => x.GetRequestsList(), Times.Once);
        }

        [Fact]
        public void GetRequestsForAdAccount_WhenCalled_CallsGetRequestsForAdAccountOnRepository()
        {
            // Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            // Act
            requestService.GetRequestsForAdAccount();

            // Assert
            mockRequestRepository.Verify(x => x.GetRequestsForAdAccount(), Times.Once);
        }

        [Fact]
        public void UpdateRequest_WhenCalled_CallsUpdateRequestOnRepository()
        {
            // Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            // Act
            requestService.UpdateRequest(testingRequest, "newCompensation", "newContentRequirements");

            // Assert
            mockRequestRepository.Verify(x => x.UpdateRequest(testingRequest), Times.Once);
        }
    }
}
