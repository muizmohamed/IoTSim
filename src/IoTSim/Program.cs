using System;

namespace IoTSim
{
    /// <summary>
    /// Entry point with CLI interface for IoT Simulator.
    /// </summary>
    class Program
    {
        static void Main()
        {
            var network = new Network();
            var scheduler = new Scheduler(network);

            Console.WriteLine("IoT Simulator CLI");
            Console.WriteLine("Commands: add, set, send, toggle, status, run, exit");

            int idCounter = 1;
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine()?.Split(' ', 3);
                if (input == null || input.Length == 0) continue;

                var cmd = input[0].ToLower();
                switch (cmd)
                {
                    case "add":
                        if (input.Length >= 3)
                        {
                            var type = input[1].ToLower() == "sensor" ? DeviceType.Sensor : DeviceType.Actuator;
                            var device = new Device(idCounter++, type, input[2]);
                            network.AddDevice(device);
                            Console.WriteLine($"Added {device}");
                        }
                        break;

                    case "set":
                        if (input.Length >= 3 && int.TryParse(input[1], out int id) && double.TryParse(input[2], out double val))
                        {
                            if (network.TryGetDevice(id, out var d))
                            {
                                d.SetValue(val);
                                Console.WriteLine($"Device {id} value set to {val}");
                            }
                            else Console.WriteLine("Device not found.");
                        }
                        break;

                    case "send":
                        if (input.Length >= 3)
                        {
                            var args = input[1].Split(' ');
                            if (args.Length >= 2 && int.TryParse(args[0], out int from) && int.TryParse(args[1], out int to))
                            {
                                network.SendMessage(from, to, input[2]);
                            }
                        }
                        break;

                    case "toggle":
                        if (input.Length >= 2 && int.TryParse(input[1], out int tid))
                        {
                            if (network.TryGetDevice(tid, out var d))
                            {
                                d.Toggle();
                                Console.WriteLine($"Device {tid} toggled.");
                            }
                            else Console.WriteLine("Device not found.");
                        }
                        break;

                    case "status":
                        network.Status();
                        break;

                    case "run":
                        scheduler.Run();
                        break;

                    case "exit":
                        return;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }
    }
}
