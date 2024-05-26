using Iss.Entity;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Iss.Tests.Entity
{
    /// <summary>
    /// Contains NUnit test cases for the <see cref="Ad"/> class.
    /// </summary>
    [TestFixture]
    public class AdTests
    {
        /// <summary>
        /// Tests the constructor of <see cref="Ad"/> without specifying an ID, ensuring properties are set correctly.
        /// </summary>
        [Test]
        public void AdConstructor_WithoutId_SetsPropertiesCorrectly()
        {
            // Arrange
            string productName = "Test Product";
            string photo = "test.jpg";
            string description = "Test description";
            string websiteLink = "https://test.com";

            // Act
            Ad ad = new Ad(productName, photo, description, websiteLink);

            // Assert
            Assert.That(ad.AdId, Is.Null); // Ensure Id is not set
            ClassicAssert.AreEqual(productName, ad.ProductName);
            ClassicAssert.AreEqual(photo, ad.Photo);
            ClassicAssert.AreEqual(description, ad.Description);
            ClassicAssert.AreEqual(websiteLink, ad.WebsiteLink);
        }

        /// <summary>
        /// Tests the constructor of <see cref="Ad"/> with specifying an ID, ensuring properties are set correctly.
        /// </summary>
        [Test]
        public void AdConstructor_WithId_SetsPropertiesCorrectly()
        {
            // Arrange
            string id = "123";
            string productName = "Test Product";
            string photo = "test.jpg";
            string description = "Test description";
            string websiteLink = "https://test.com";

            // Act
            Ad ad = new Ad(id, productName, photo, description, websiteLink);

            // Assert
            ClassicAssert.AreEqual(id, ad.AdId);
            ClassicAssert.AreEqual(productName, ad.ProductName);
            ClassicAssert.AreEqual(photo, ad.Photo);
            ClassicAssert.AreEqual(description, ad.Description);
            ClassicAssert.AreEqual(websiteLink, ad.WebsiteLink);
        }

        /// <summary>
        /// Tests the <see cref="Ad.ToString"/> method to ensure it returns the expected format.
        /// </summary>
        [Test]
        public void ToString_ReturnsExpectedFormat()
        {
            // Arrange
            string productName = "Sample Product";
            string description = "This is a sample description.";
            string websiteLink = "https://example.com";
            Ad ad = new Ad(productName, "photo.jpg", description, websiteLink);

            // Act
            string result = ad.ToString();

            // Assert
            string expected = $"PRODUCT NAME: {productName}-DESCRIPTION: {description}-URL: {websiteLink}";
            ClassicAssert.AreEqual(expected, result);
        }
    }
}
