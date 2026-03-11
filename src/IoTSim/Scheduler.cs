using System;
using System.Threading;

namespace IoTSim
{
    /// <summary>
    /// Simulates time progression (ticks).
    /// </summary>
    public class Scheduler
    {
        private readonly Network network;
        private bool running = false;

        public Scheduler(Network net) => network = net;

        /// <summary>
        /// Run simulation for a number of ticks.
        /// </summary>
        public void Run(int ticks = 10, int delayMs = 1000)
        {
            running = true;
            for (int i = 0; i < ticks && running; i++)
            {
                Console.WriteLine($"[Scheduler] Tick {i+1}");
                Thread.Sleep(delayMs); // Wait between ticks
            }
        }

        /// <summary>
        /// Stop the simulation.
        /// </summary>
        public void Stop() => running = false;
    }
}
