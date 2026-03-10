using Xunit;

namespace IoTSim.Tests
{
    public class DeviceTests
    {
        [Fact]
        public void DeviceToggleChangesState()
        {
            var d = new Device(1, DeviceType.Sensor, "TempSensor");
            var initial = d.State;
            d.Toggle();
            Assert.NotEqual(initial, d.State);
        }

        [Fact]
        public void SetValueUpdatesValue()
        {
            var d = new Device(2, DeviceType.Sensor, "S");
            d.SetValue(12.5);
            Assert.Equal(12.5, d.Value);
        }
    }
}
