using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Iss.Entity;

namespace Iss.Tests.Entity
{
    public class RequestTests
    {
        [Fact]
        public void ToString_ReturnsCollaborationTitle()
        {
            // Arrange
            var request = new Request("Title", "Overview", "Requirements", "Compensation", DateTime.Now, DateTime.Now, true, true);

            // Act
            var result = request.ToString();

            // Assert
            Assert.Equal("Title", result);
        }

        [Fact]
        public void RequestProperties_AreSetCorrectly()
        {
            // Arrange
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(7);

            // Act
            var request = new Request("Title", "Overview", "Requirements", "Compensation", startDate, endDate, true, true);

            // Assert
            Assert.Equal("Title", request.CollaborationTitle);
            Assert.Equal("Overview", request.AdOverview);
            Assert.Equal("Requirements", request.ContentRequirements);
            Assert.Equal("Compensation", request.Compensation);
            Assert.Equal(startDate, request.StartDate);
            Assert.Equal(endDate, request.EndDate);
            Assert.True(request.InfluencerAccept);
            Assert.True(request.AdAccountAccept);
        }
    }
}
