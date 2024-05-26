using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Iss.Entity;

namespace Iss.Tests.Entity
{
    public class RequestTest
    {
        [Fact]
        public void Constructor_WithAllParameters_CorrectInitialization()
        {
            // Arrange
            string collaborationTitle = "Title";
            string adOverview = "Overview";
            string contentRequirements = "Requirements";
            string compensation = "Compensation";
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(1);
            bool influencerAccept = true;
            bool adAccountAccept = true;

            // Act
            Request request = new Request(collaborationTitle, adOverview, contentRequirements, compensation, startDate, endDate, influencerAccept, adAccountAccept);

            // Assert
            Assert.Equal(collaborationTitle, request.CollaborationTitle);
            Assert.Equal(adOverview, request.AdOverview);
            Assert.Equal(contentRequirements, request.ContentRequirements);
            Assert.Equal(compensation, request.Compensation);
            Assert.Equal(startDate, request.StartDate);
            Assert.Equal(endDate, request.EndDate);
            Assert.Equal(influencerAccept, request.InfluencerAccept);
            Assert.Equal(adAccountAccept, request.AdAccountAccept);
        }
    }
}
