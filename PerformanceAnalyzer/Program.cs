using PerformanceAnalyzer;
using PerformanceAnalyzer.Extensions;

try
{
    new Analyzer().Run();
}
catch(Exception e)
{
    CustomConsole.WriteLine($"Unable to run comparsion: {e.Message}", ConsoleColor.Black, ConsoleColor.Red);
}