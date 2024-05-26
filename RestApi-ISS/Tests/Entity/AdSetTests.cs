using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Iss.Tests.Entity
{
    /// <summary>
    /// Contains NUnit tests for the <see cref="AdSet"/> class.
    /// </summary>
    [TestFixture]
    public class AdSetTests
    {
        /// <summary>
        /// Tests the constructor of <see cref="AdSet"/> when initialized without providing ads.
        /// Verifies that properties are set correctly and Ads list is initialized as empty.
        /// </summary>
        [Test]
        public void AdSetConstructor_WithoutAds_SetsPropertiesCorrectly()
        {
            // Arrange
            string id = "1";
            string name = "Test AdSet";
            string targetAudience = "Test Audience";

            // Act
            AdSet adSet = new AdSet(id, name, targetAudience);

            // Assert
            ClassicAssert.AreEqual(id, adSet.AdSetId);
            ClassicAssert.AreEqual(name, adSet.Name);
            ClassicAssert.AreEqual(targetAudience, adSet.TargetAudience);
            ClassicAssert.IsNotNull(adSet.Ads); // Ads should be initialized as a new list
            ClassicAssert.AreEqual(0, adSet.Ads.Count); // Ads list should be empty initially
        }

        /// <summary>
        /// Tests the constructor of <see cref="AdSet"/> when initialized with a list of ads.
        /// Verifies that properties are set correctly with the provided ads list.
        /// </summary>
        [Test]
        public void AdSetConstructor_WithAds_SetsPropertiesCorrectly()
        {
            // Arrange
            string name = "Test AdSet";
            string targetAudience = "Test Audience";
            List<Ad> ads = new List<Ad>
            {
                new Ad("Product A", "photoA.jpg", "Description A", "https://example.com/productA"),
                new Ad("Product B", "photoB.jpg", "Description B", "https://example.com/productB"),
            };

            // Act
            AdSet adSet = new AdSet(name, targetAudience, ads);

            // Assert
            ClassicAssert.AreEqual(name, adSet.Name);
            ClassicAssert.AreEqual(targetAudience, adSet.TargetAudience);
            Assert.That(ads, Is.EqualTo(adSet.Ads)); // Check if Ads list matches the provided list
        }

        /// <summary>
        /// Tests the <see cref="AdSet.AddAd(Ad)"/> method by adding an ad to the ad set.
        /// Verifies that the ad is included in the Ads list after adding.
        /// </summary>
        [Test]
        public void AddAd_AddsAdToAdSet()
        {
            // Arrange
            AdSet adSet = new AdSet("1", "Test AdSet", "Test Audience");
            Ad ad = new Ad("Product C", "photoC.jpg", "Description C", "https://example.com/productC");

            // Act
            adSet.AddAd(ad);

            // Assert
            ClassicAssert.IsTrue(adSet.Ads.Contains(ad)); // Check if the added ad is in the Ads list
        }

        /// <summary>
        /// Tests the <see cref="AdSet.RemoveAd(Ad)"/> method by removing an ad from the ad set.
        /// Verifies that the ad is no longer in the Ads list after removal.
        /// </summary>
        [Test]
        public void RemoveAd_RemovesAdFromAdSet()
        {
            // Arrange
            Ad adToRemove = new Ad("Product D", "photoD.jpg", "Description D", "https://example.com/productD");
            AdSet adSet = new AdSet("1", "Test AdSet", new List<Ad> { adToRemove });

            // Act
            adSet.RemoveAd(adToRemove);

            // Assert
            ClassicAssert.IsFalse(adSet.Ads.Contains(adToRemove)); // Check if the ad was removed from the Ads list
        }

        /// <summary>
        /// Tests the <see cref="AdSet.ToString"/> method to ensure it returns the expected string format.
        /// </summary>
        [Test]
        public void ToString_ReturnsExpectedFormat()
        {
            // Arrange
            string name = "Test AdSet";
            string targetAudience = "Test Audience";
            AdSet adSet = new AdSet("1", name, targetAudience);

            // Act
            string result = adSet.ToString();

            // Assert
            string expected = $"ADSET NAME: {name}-TARGET AUDIENCE: {targetAudience}";
            ClassicAssert.AreEqual(expected, result);
        }
    }
}
