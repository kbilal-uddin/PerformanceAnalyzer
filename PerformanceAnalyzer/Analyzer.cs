using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using PerformanceAnalyzer.Comparison;

namespace PerformanceAnalyzer
{
    public class Analyzer
    {
        internal void Run()
        {
            WriteLine("Performance Face-Off: Benchmarking C# Methods to Find the Fastest Approach", ConsoleColor.Black, ConsoleColor.Yellow);
            WriteLine("Please select the appropiate key to run an analysis", ConsoleColor.Black, ConsoleColor.Yellow);

            WriteLine($"Please select the appropiate key to run an analysis{Environment.NewLine}{GenerateMenu()}");


            string _key = Console.ReadLine();

            WriteLine("Please provide path to generate reports", ConsoleColor.Black, ConsoleColor.Yellow);

            string _path = Console.ReadLine();

            InitializePerformance(_key, _path);
        }

        private string GenerateMenu()
        {
            StringBuilder menu = new StringBuilder(); // Generate menu

            menu.AppendLine("1. Concatination vs Interpolation");
            menu.AppendLine("2. WithStringBuilder vs WithString");

            return menu.ToString();
        }

        private void InitializePerformance(string key, string reportPath = "")
        {
            ManualConfig customConfig = null;

            if(!string.IsNullOrEmpty(reportPath) && Directory.Exists(reportPath))
                customConfig = DefaultConfig.Instance.WithArtifactsPath(reportPath);

            try
            {
                var result = key switch
                {
                    "1" => BenchmarkRunner.Run<StringBenchmark>(customConfig),
                    "2" => BenchmarkRunner.Run<CompareMethods>(customConfig),
                    _ => throw new NotImplementedException(),
                };
            }
            catch (Exception)
            {
                WriteLine("No such key found", ConsoleColor.Black, ConsoleColor.Red);
            }
            
        }

        private void WriteLine(string value, ConsoleColor background = ConsoleColor.Black, ConsoleColor foreground = ConsoleColor.Gray)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(value);

            Console.ResetColor();
        }
    }
}
