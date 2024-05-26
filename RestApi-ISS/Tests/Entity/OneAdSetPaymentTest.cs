using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Iss.Entity;

namespace Iss.Tests.Entity
{
    public class OneAdSetPaymentTest
    {
        [Fact]
        public void Constructor_WithAllParameters_CorrectInitialization()
        {
            // Arrange
            int adSetPaymentId = 1;
            int reach = 1000;
            decimal price = 100;

            // Act
            OneAdSetPayment oneAdSetPayment = new OneAdSetPayment(adSetPaymentId, reach, price);

            // Assert
            Assert.Equal(adSetPaymentId, oneAdSetPayment.AdSetPaymentId);
            Assert.Equal(reach, oneAdSetPayment.Reach);
            Assert.Equal(price, oneAdSetPayment.Price);

            // Set
            oneAdSetPayment.AdSetPaymentId = 2;
            oneAdSetPayment.Reach = 2000;
            oneAdSetPayment.Price = 200;

            // Assert
            Assert.Equal(2, oneAdSetPayment.AdSetPaymentId);
            Assert.Equal(2000, oneAdSetPayment.Reach);
            Assert.Equal(200, oneAdSetPayment.Price);
        }
    }
}
