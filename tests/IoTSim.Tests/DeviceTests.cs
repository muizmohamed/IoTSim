using Xunit;

namespace IoTSim.Tests
{
    public class DeviceTests
    {
        [Fact]
        public void Toggle_ShouldChangeState()
        {
            var device = new Device(1, DeviceType.Sensor, "TempSensor");
            var initialState = device.State;

            device.Toggle();

            Assert.NotEqual(initialState, device.State);
        }

        [Fact]
        public void SetValue_ShouldUpdateValue()
        {
            var device = new Device(2, DeviceType.Sensor, "HumiditySensor");
            device.SetValue(55.5);

            Assert.Equal(55.5, device.Value);
        }
    }
}
