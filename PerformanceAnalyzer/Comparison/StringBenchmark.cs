using BenchmarkDotNet.Attributes;
using System.Text;

namespace PerformanceAnalyzer.Comparison
{
    public class StringBenchmark
    {
        private const int Iterations = 10;

        [Benchmark]
        public string Concatenation()
        {
            string result = "";
            for (int i = 0; i < Iterations; i++)
            {
                result += "Slow" + i + " ";
            }
            return result;
        }

        [Benchmark]
        public string Interpolation()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                sb.Append($"Fast{i} ");
            }
            return sb.ToString();
        }
    }
}
