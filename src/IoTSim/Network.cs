using System;
using System.Collections.Generic;

namespace IoTSim
{
    /// <summary>
    /// Manages devices and communication between them.
    /// </summary>
    public class Network
    {
        private readonly Dictionary<int, Device> devices = new();

        /// <summary>
        /// Add a new device to the network.
        /// </summary>
        public void AddDevice(Device device) => devices[device.Id] = device;

        /// <summary>
        /// Try to get a device by ID.
        /// </summary>
        public bool TryGetDevice(int id, out Device device) => devices.TryGetValue(id, out device);

        /// <summary>
        /// Send a message between two devices.
        /// </summary>
        public void SendMessage(int fromId, int toId, string message)
        {
            if (!devices.ContainsKey(fromId) || !devices.ContainsKey(toId))
            {
                Console.WriteLine("[Network] Invalid device IDs.");
                return;
            }
            Console.WriteLine($"[Network] {devices[fromId].Name} -> {devices[toId].Name}: {message}");
        }

        /// <summary>
        /// Print status of all devices in the network.
        /// </summary>
        public void Status()
        {
            Console.WriteLine("=== Network Status ===");
            foreach (var d in devices.Values)
                Console.WriteLine(d);
        }
    }
}
