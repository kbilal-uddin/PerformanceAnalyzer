using BenchmarkDotNet.Attributes;
using PerformanceAnalyzer.Models;

namespace PerformanceAnalyzer.Comparison
{
    [MemoryDiagnoser]
    public class NullCheckComparator
    {
        Github git = new Github();

        [Benchmark]
        public void WithTradationalNullCheck()
        {
            if(git != null)
            {
                git.repo_name = "kbilal-uddin/PerformanceAnalyzer";
                git.branch_name = "performance-analyzer/add-is-not-null-comparsion";
            }    
        }

        [Benchmark]
        public void WithIsNotNullCheck()
        {
            if (git is not null)
            {
                git.repo_name = "kbilal-uddin/PerformanceAnalyzer";
                git.branch_name = "performance-analyzer/add-is-not-null-comparsion";
            }
        }
    }
}
