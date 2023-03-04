using System.Diagnostics;

namespace knightsTour.Tools;

public static class EfficiencyMeasure
{
    private static readonly Stopwatch Stopwatch = new();
    private static string? measuring = null;
    private static long virtualMemorySize;
    private static long actualMemorySize;

    public static void Start()
    {
        measuring = "started";
        Stopwatch.Restart();
        GC.Collect();
        virtualMemorySize = Process.GetCurrentProcess().VirtualMemorySize64;
        actualMemorySize = Process.GetCurrentProcess().WorkingSet64;
    }

    public static void Stop()
    {
        if (measuring is not "started")
            return;
        Stopwatch.Stop();
        virtualMemorySize = Process.GetCurrentProcess().VirtualMemorySize64 - virtualMemorySize;
        actualMemorySize = Process.GetCurrentProcess().WorkingSet64 - actualMemorySize;
        measuring = "stopped";
    }


    public static void Log()
    {
        if (measuring is not "stopped")
            return;
        WriteLine("----------------------");
        WriteLine($"Actual Memory Size  : {actualMemorySize}");
        WriteLine($"Virtual Memory Size : {virtualMemorySize}");
        WriteLine($"Runtime took: {Stopwatch.Elapsed}");
        WriteLine("----------------------");
    }
}