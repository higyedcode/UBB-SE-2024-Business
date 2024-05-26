using System;
using Xunit;

using Iss.Entity;

namespace Iss.Tests.Entity
{
    public class SilverSubscriptionTests
    {
        [Fact]
        public void SilverSubscription_Constructor_CorrectInitialization()
        {
            // Arrange
            int expectedNumberOfCampaigns = 8;
            decimal expectedPrice = 149.99m;
            int expectedReach = 15000;

            // Act
            SilverSubscription subscription = new SilverSubscription(expectedNumberOfCampaigns, expectedPrice, expectedReach);

            // Assert
            Assert.Equal(expectedNumberOfCampaigns, subscription.GetNumberOfCampaigns());
            Assert.Equal(expectedPrice, subscription.GetPrice());
            Assert.Equal(expectedReach, subscription.GetReach());
        }
    }
}
