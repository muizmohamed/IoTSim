using System;
using System.Collections.Generic;

namespace IoTSim
{
    public class Network
    {
        private readonly Dictionary<int, Device> devices = new();

        public void AddDevice(Device device) => devices[device.Id] = device;

        public bool TryGetDevice(int id, out Device device) => devices.TryGetValue(id, out device);

        public void SendMessage(int fromId, int toId, string message)
        {
            if (!devices.ContainsKey(fromId) || !devices.ContainsKey(toId))
            {
                Console.WriteLine("[Network] Invalid device IDs.");
                return;
            }
            Console.WriteLine($"[Network] {devices[fromId].Name} -> {devices[toId].Name}: {message}");
        }

        public void Status()
        {
            Console.WriteLine("=== Network Status ===");
            foreach (var d in devices.Values)
                Console.WriteLine(d);
        }
    }
}
