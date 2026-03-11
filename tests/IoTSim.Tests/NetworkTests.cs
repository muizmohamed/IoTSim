using Xunit;
using System.IO;

namespace IoTSim.Tests
{
    public class NetworkTests
    {
        [Fact]
        public void AddDevice_ShouldStoreDevice()
        {
            var network = new Network();
            var device = new Device(1, DeviceType.Sensor, "TempSensor");

            network.AddDevice(device);

            Assert.True(network.TryGetDevice(1, out var retrieved));
            Assert.Equal(device, retrieved);
        }

        [Fact]
        public void SendMessage_ShouldPrintMessage()
        {
            var network = new Network();
            var sensor = new Device(1, DeviceType.Sensor, "Sensor");
            var actuator = new Device(2, DeviceType.Actuator, "Actuator");
            network.AddDevice(sensor);
            network.AddDevice(actuator);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            network.SendMessage(1, 2, "Test Message");

            var output = sw.ToString();
            Assert.Contains("Sensor -> Actuator: Test Message", output);
        }
    }
}
