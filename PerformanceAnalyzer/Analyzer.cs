using System.Text;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using PerformanceAnalyzer.Comparison;
using PerformanceAnalyzer.Extensions;

namespace PerformanceAnalyzer
{
    public class Analyzer
    {
        internal void Run()
        {
            CustomConsole.WriteLine("Performance Face-Off: Benchmarking C# Methods to Find the Fastest Approach", ConsoleColor.Black, ConsoleColor.Yellow);
            CustomConsole.WriteLine("Please select the appropiate key to run an analysis", ConsoleColor.Black, ConsoleColor.Yellow);

            CustomConsole.WriteLine($"Please select the appropiate key to run an analysis{Environment.NewLine}{GenerateMenu()}");


            string _key = Console.ReadLine();

            CustomConsole.WriteLine("Please provide path to generate reports", ConsoleColor.Black, ConsoleColor.Yellow);

            string _path = Console.ReadLine();

            InitializeBenchmarkDotNet(_key, _path);
        }

        private string GenerateMenu()
        {
            StringBuilder menu = new StringBuilder(); // Generate menu

            menu.AppendLine("1. Concatination vs Interpolation");
            menu.AppendLine("2. WithStringBuilder vs WithString");
            menu.AppendLine("3. != null vs is not null");

            return menu.ToString();
        }

        private void InitializeBenchmarkDotNet(string key, string reportPath = "")
        {
            ManualConfig customConfig = null;

            if(!string.IsNullOrEmpty(reportPath) && Directory.Exists(reportPath))
                customConfig = DefaultConfig.Instance.WithArtifactsPath(reportPath);

            try
            {
                var result = key switch
                {
                    "1" => BenchmarkRunner.Run<StringBenchmark>(customConfig),
                    "2" => BenchmarkRunner.Run<StringEfficiencyAnalyzer>(customConfig),
                    "3" => BenchmarkRunner.Run<NullCheckComparator>(customConfig),
                    _ => throw new NotImplementedException(),
                };
            }
            catch (Exception e)
            {
                CustomConsole.WriteLine($"Unable to run comparsion: {e.Message}", ConsoleColor.Black, ConsoleColor.Red);
            }
            
        }
    }
}
