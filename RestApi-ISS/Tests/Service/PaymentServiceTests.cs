using System;
using System.Collections.Generic;
using Xunit;

using Iss.Entity;
using Iss.Repository;
using Iss.Service;
using Moq;

namespace Iss.Tests.Service
{
    public class PaymentServiceTests
    {
        [Fact]
        public void AddOneAd_WhenCalled_CallsAddOneAdOnRepository()
        {
            // Arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);

            // Act
            paymentService.AddOneAd();

            // Assert
            mockPaymentRepository.Verify(x => x.AddOneAd(), Times.Once);
        }

        [Fact]
        public void AddOneAdSet_WhenCalled_CallsAddOneAdSetOnRepository()
        {
            // Arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);

            // Act
            paymentService.AddOneAdSet();

            // Assert
            mockPaymentRepository.Verify(x => x.AddOneAdSet(), Times.Once);
        }

        [Fact]
        public void AddOneCampaign_WhenCalled_CallsAddOneCampaignOnRepository()
        {
            // Arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);

            // Act
            paymentService.AddOneCampaign();

            // Assert
            mockPaymentRepository.Verify(x => x.AddOneCampaign(), Times.Once);
        }

        [Fact]
        public void AddBasicSubscription_WhenCalled_CallsAddSubscriptionWithBasicOnRepository()
        {
            // Arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);

            // Act
            paymentService.AddBasicSubscription();

            // Assert
            mockPaymentRepository.Verify(x => x.AddSubscription("Basic"), Times.Once);
        }

        [Fact]
        public void AddSilverSubscription_WhenCalled_CallsAddSubscriptionWithSilverOnRepository()
        {
            // Arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);

            // Act
            paymentService.AddSilverSubscription();

            // Assert
            mockPaymentRepository.Verify(x => x.AddSubscription("Silver"), Times.Once);
        }

        [Fact]
        public void AddGoldSubscription_WhenCalled_CallsAddSubscriptionWithGoldOnRepository()
        {
            // Arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);

            // Act
            paymentService.AddGoldSubscription();

            // Assert
            mockPaymentRepository.Verify(x => x.AddSubscription("Gold"), Times.Once);
        }
    }
}
