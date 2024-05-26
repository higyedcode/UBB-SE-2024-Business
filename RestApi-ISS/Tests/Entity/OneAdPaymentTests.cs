using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Iss.Entity;

namespace Iss.Tests.Entity
{
    public class OneAdPaymentTests
    {
        [Fact]
        public void GetNextID_NoPreviousPayments_ReturnsCorrectNextID()
        {
            // Arrange
            var account = new AdAccount("TestCompany", "TestDomain", "https://example.com", "password", "123456789", "TestLocation", "TestInstitution");

            var payment = new OneAdPayment(0, 0, 0);
            payment.Account = account;

            // Act
            var nextID = payment.GetNextID();

            // Assert
            Assert.Equal(1, nextID); // adding payments not implemented
        }

        [Fact]
        public void GetterProperties_Initialization_ReturnCorrectValues()
        {
            // Arrange
            int paymentId = 1;
            int reach = 1000;
            decimal price = 50;

            var payment = new OneAdPayment(paymentId, reach, price);

            // Act
            int retrievedPaymentId = payment.PaymentId;
            int retrievedReach = payment.Reach;
            decimal retrievedPrice = payment.Price;

            // Assert
            Assert.Equal(paymentId, retrievedPaymentId);
            Assert.Equal(reach, retrievedReach);
            Assert.Equal(price, retrievedPrice);
        }
    }
}
