namespace IoTSim
{
    /// <summary>
    /// Defines the type of IoT device: Sensor or Actuator.
    /// </summary>
    public enum DeviceType { Sensor, Actuator }

    /// <summary>
    /// Represents a single IoT device with state and value.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Unique identifier for the device.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Type of device (Sensor/Actuator).
        /// </summary>
        public DeviceType Type { get; }

        /// <summary>
        /// Human-readable name of the device.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Current On/Off state of the device.
        /// </summary>
        public bool State { get; private set; }

        /// <summary>
        /// Current value of the device (e.g., temperature).
        /// </summary>
        public double Value { get; private set; }

        /// <summary>
        /// Initializes a new device with default state ON and value 0.
        /// </summary>
        public Device(int id, DeviceType type, string name)
        {
            Id = id;
            Type = type;
            Name = name;
            State = true;
            Value = 0;
        }

        /// <summary>
        /// Set a new value for the device.
        /// </summary>
        public void SetValue(double value) => Value = value;

        /// <summary>
        /// Toggle device state (On/Off).
        /// </summary>
        public void Toggle() => State = !State;

        /// <summary>
        /// Returns a string representation of the device.
        /// </summary>
        public override string ToString() =>
            $"Device {Id}: {Name} ({Type}), State={State}, Value={Value}";
    }
}
