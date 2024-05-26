using System;
using Xunit;

using Iss.Entity;

namespace Iss.Tests.Entity
{
    public class GoldSubscriptionTests
    {
        [Fact]
        public void GoldSubscription_Constructor_CorrectInitialization()
        {
            // Arrange
            int expectedNumberOfCampaigns = 10;
            decimal expectedPrice = 199.99m;
            int expectedReach = 20000;

            // Act
            GoldSubscription subscription = new GoldSubscription(expectedNumberOfCampaigns, expectedPrice, expectedReach);

            // Assert
            Assert.Equal(expectedNumberOfCampaigns, subscription.GetNumberOfCampaigns());
            Assert.Equal(expectedPrice, subscription.GetPrice());
            Assert.Equal(expectedReach, subscription.GetReach());
        }
    }
}
