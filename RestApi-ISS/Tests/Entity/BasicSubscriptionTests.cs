using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Iss.Entity;

namespace Iss.Tests.Entity
{
    public class BasicSubscriptionTests
    {
        [Fact]
        public void BasicSubscription_Constructor_CorrectInitialization()
        {
            // Arrange
            int expectedNumberOfCampaigns = 5;
            decimal expectedPrice = 99.99m;
            int expectedReach = 10000;

            // Act
            BasicSubscription subscription = new BasicSubscription(expectedNumberOfCampaigns, expectedPrice, expectedReach);

            // Assert
            Assert.Equal(expectedNumberOfCampaigns, subscription.GetNumberOfCampaigns());
            Assert.Equal(expectedPrice, subscription.GetPrice());
            Assert.Equal(expectedReach, subscription.GetReach());
        }
    }
}
