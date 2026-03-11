using Xunit;
using System.IO;

namespace IoTSim.Tests
{
    public class SchedulerTests
    {
        [Fact]
        public void Run_ShouldPrintTicks()
        {
            var network = new Network();
            var scheduler = new Scheduler(network);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            scheduler.Run(ticks: 3, delayMs: 10);

            var output = sw.ToString();
            Assert.Contains("[Scheduler] Tick 1", output);
            Assert.Contains("[Scheduler] Tick 2", output);
            Assert.Contains("[Scheduler] Tick 3", output);
        }
    }
}
