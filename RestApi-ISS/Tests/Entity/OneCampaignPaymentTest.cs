using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Iss.Entity;

namespace Iss.Tests.Entity
{
    public class OneCampaignPaymentTest
    {
        [Fact]
        public void Constructor_WithAllParameters_CorrectInitialization()
        {
            // Arrange
            int campaignPaymentId = 1;
            int reach = 1000;
            decimal price = 100;

            // Act
            OneCampaignPayment oneCampaignPayment = new OneCampaignPayment(campaignPaymentId, reach, price);

            // Assert
            Assert.Equal(campaignPaymentId, oneCampaignPayment.CampaignPaymentId);
            Assert.Equal(reach, oneCampaignPayment.Reach);
            Assert.Equal(price, oneCampaignPayment.Price);

            // Set
            oneCampaignPayment.CampaignPaymentId = 2;
            oneCampaignPayment.Reach = 2000;
            oneCampaignPayment.Price = 200;

            // Assert
            Assert.Equal(2, oneCampaignPayment.CampaignPaymentId);
            Assert.Equal(2000, oneCampaignPayment.Reach);
            Assert.Equal(200, oneCampaignPayment.Price);
        }
    }
}
