using System;

namespace IoTSim
{
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
                if (cmd == "add" && input.Length >= 3)
                {
                    var type = input[1].ToLower() == "sensor" ? DeviceType.Sensor : DeviceType.Actuator;
                    var device = new Device(idCounter++, type, input[2]);
                    network.AddDevice(device);
                    Console.WriteLine($"Added {device}");
                    continue;
                }

                if (cmd == "set" && input.Length >= 3)
                {
                    if (int.TryParse(input[1], out int id) && double.TryParse(input[2], out double val))
                    {
                        if (network.TryGetDevice(id, out var d))
                        {
                            d.SetValue(val);
                            Console.WriteLine($"Device {id} value set to {val}");
                        }
                        else Console.WriteLine("Device not found.");
                    }
                    continue;
                }

                if (cmd == "send" && input.Length >= 3)
                {
                    var args = input[1].Split(' ');
                    if (args.Length >= 2 && int.TryParse(args[0], out int from) && int.TryParse(args[1], out int to))
                    {
                        network.SendMessage(from, to, input[2]);
                    }
                    continue;
                }

                if (cmd == "toggle" && input.Length >= 2 && int.TryParse(input[1], out int tid))
                {
                    if (network.TryGetDevice(tid, out var d))
                    {
                        d.Toggle();
                        Console.WriteLine($"Device {tid} toggled.");
                    }
                    else Console.WriteLine("Device not found.");
                    continue;
                }

                if (cmd == "status") { network.Status(); continue; }
                if (cmd == "run") { scheduler.Run(); continue; }
                if (cmd == "exit") return;

                Console.WriteLine("Unknown command.");
            }
        }
    }
}
