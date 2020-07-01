using MicrocontrollerCommLibrary;
using System;
using System.Linq;
using Xunit;

namespace MicroCommLibTests
{
    public class BluetoothStreamUnitTests
    {

        /* 
        It would be better to use a testing framework that could
        emulate bluetooth devices for testing. 
        */
        [Theory]
        [InlineData("Galaxy A70")]  // Test mobile phone
        public void TestNearbyDevicesPhone(string phone)
        {
            // Arrange
            var btMicro = new BluetoothStream();

            // Act
            btMicro.UpdateNearbyDevices();
            string[] nearbyDevices = btMicro.GetNearbyDevicesNames();

            // Assert
            Assert.True(nearbyDevices.Any(x => x == phone));
        }

        [Theory]
        [InlineData("Galaxy A70")] // Test mobile phone
        public void TestSelectDevice(string phone)
        {
            // Arrange
            var btMicro = new BluetoothStream();

            // Act 
            btMicro.SelectDevice(phone);

            // Assert
            Assert.True(btMicro.GetSelectedDevice() == phone);

        }
    }
}
