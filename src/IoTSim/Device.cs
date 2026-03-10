namespace IoTSim
{
    public enum DeviceType { Sensor, Actuator }

    public class Device
    {
        public int Id { get; }
        public DeviceType Type { get; }
        public string Name { get; }
        public bool State { get; private set; }
        public double Value { get; private set; }

        public Device(int id, DeviceType type, string name)
        {
            Id = id;
            Type = type;
            Name = name;
            State = true;
            Value = 0;
        }

        public void SetValue(double value) => Value = value;
        public void Toggle() => State = !State;

        public override string ToString() =>
            $"Device {Id}: {Name} ({Type}), State={State}, Value={Value}";
    }
}
