using System;
using System.Threading;

namespace IoTSim
{
    public class Scheduler
    {
        private readonly Network network;
        private bool running = false;

        public Scheduler(Network net) => network = net;

        public void Run(int ticks = 10, int delayMs = 1000)
        {
            running = true;
            for (int i = 0; i < ticks && running; i++)
            {
                Console.WriteLine($"[Scheduler] Tick {i+1}");
                Thread.Sleep(delayMs);
            }
        }

        public void Stop() => running = false;
    }
}
