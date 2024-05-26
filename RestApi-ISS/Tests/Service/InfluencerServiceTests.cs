using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;
using Iss.Repository;
using Iss.Service;

using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Iss.Tests.Service
{
    [TestFixture]
    public class InfluencerServiceTests
    {
        private IInfluencerRepository mockRepository;

        [SetUp]
        public void Setup()
        {
            // Create a mock repository for testing
            mockRepository = new MockInfluencerRepository();
        }

        [Test]
        /// <summary>
        /// Tests the retrieval of influencers when the repository returns a non-empty list.
        /// </summary>
        /// <remarks>
        /// Verifies that the GetInfluencers method returns a non-null list of influencers
        /// when the repository provides valid data.
        /// </remarks>
        public void GetInfluencers_ReturnsListOfInfluencers()
        {
            // Arrange
            var testInfluencerService = new InfluencerService(mockRepository);

            // Act
            List<Influencer> influencers = testInfluencerService.GetInfluencers();

            // Assert
            ClassicAssert.IsNotNull(influencers);
            ClassicAssert.IsInstanceOf<List<Influencer>>(influencers);
            ClassicAssert.Greater(influencers.Count, 0);
        }

        [Test]
        /// <summary>
        /// Tests the retrieval of influencers when the repository returns an empty list.
        /// </summary>
        /// <remarks>
        /// Verifies that the GetInfluencers method returns an empty list
        /// when the repository does not provide any influencers.
        /// </remarks>
        public void GetInfluencers_ReturnsEmptyList()
        {
            // Arrange
            ((MockInfluencerRepository)mockRepository).SetEmptyInfluencers(); // Set the mock repository to return an empty list
            var testInfluencerService = new InfluencerService(mockRepository);

            // Act
            List<Influencer> influencers = testInfluencerService.GetInfluencers();

            // Assert
            ClassicAssert.IsNotNull(influencers);
            ClassicAssert.IsInstanceOf<List<Influencer>>(influencers);
            ClassicAssert.AreEqual(0, influencers.Count);
        }
    }

    /// <summary>
    /// Mock implementation of the <see cref="IInfluencerRepository"/> interface for testing purposes.
    /// </summary>
    public class MockInfluencerRepository : IInfluencerRepository
    {
        private List<Influencer> influencers;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockInfluencerRepository"/> class with sample data.
        /// </summary>
        public MockInfluencerRepository()
        {
            // Initialize with sample data
            influencers = new List<Influencer>
            {
                new Influencer("1", "Influencer A", 10000, 500),
                new Influencer("2", "Influencer B", 20000, 700),
            };
        }

        /// <summary>
        /// Gets a list of influencers.
        /// </summary>
        /// <returns>A list of <see cref="Influencer"/> objects.</returns>
        public List<Influencer> GetInfluencers()
        {
            return this.influencers;
        }

        /// <summary>
        /// Sets the list of influencers to an empty list.
        /// </summary>
        public void SetEmptyInfluencers()
        {
            this.influencers = new List<Influencer>(); // Set to empty list
        }
    }
}
