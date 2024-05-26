using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Iss.Entity;

namespace Iss.Tests.Entity
{
    public class InfluencerTest
    {
        [Fact]
        public void Constructor_WithAllParameters_CorrectInitialization()
        {
            // Arrange
            string influencerId = "1";
            string influencerName = "Influencer Name";
            int followerCount = 1000;
            int collaborationPrice = 100;

            // Act
            Influencer influencer = new Influencer(influencerId, influencerName, followerCount, collaborationPrice);

            // Assert
            Assert.Equal(influencerId, influencer.InfluencerId);
            Assert.Equal(influencerName, influencer.InfluencerName);
            Assert.Equal(followerCount, influencer.FollowerCount);
            Assert.Equal(collaborationPrice, influencer.CollaborationPrice);
            Assert.Equal(influencerName + " with " + followerCount + " followers. Costs: " + collaborationPrice + "$", influencer.ToString());
        }

        [Fact]
        public void Constructor_WithSelectedParameters_CorrectInitialization()
        {
            // Arrange
            string influencerName = "Influencer Name";
            int followerCount = 1000;
            int collaborationPrice = 100;

            // Act
            Influencer influencer = new Influencer(influencerName, followerCount, collaborationPrice);

            // Assert
            Assert.Equal(influencerName, influencer.InfluencerName);
            Assert.Equal(followerCount, influencer.FollowerCount);
            Assert.Equal(collaborationPrice, influencer.CollaborationPrice);
            Assert.Equal(influencerName + " with " + followerCount + " followers. Costs: " + collaborationPrice + "$", influencer.ToString());
        }
    }
}
