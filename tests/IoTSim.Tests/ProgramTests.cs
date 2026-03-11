using Xunit;
using System.IO;

namespace IoTSim.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Main_ShouldPrintBanner()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            Program.Main();

            var output = sw.ToString();
            Assert.Contains("IoT Simulator CLI", output);
        }
    }
}
