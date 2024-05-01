namespace PerformanceAnalyzer.Extensions
{
    static class CustomConsole
    {
        public static void WriteLine(string value, ConsoleColor background = ConsoleColor.Black, ConsoleColor foreground = ConsoleColor.Gray)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(value);

            Console.ResetColor();
        }
    }
}
