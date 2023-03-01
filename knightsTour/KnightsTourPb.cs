namespace knightsTour;

public static class KnightsTourPb
{
    public static int MaxLeft(int n) => (MaxRight(n) - 8) + 1;
    public static int MaxRight(int n) => (int)Math.Ceiling((double)n / 8) * 8;

    public IEnumerable<int>? TwoUpOneOnX()
    {
        var maxR = MaxRight(m);
        var newMr = maxR - 16;
        if (newMr is > 64 or < 8)
            return;
        var twoUp = newMr - (maxR - m);
        var oneLeft = twoUp - 1;
        var oneRight = twoUp + 1;
        
        if 
    }

    public static IEnumerable<int>? FindNextMoves(int m)
    {
        var twoUpOneLeft = int?() =>
        {

        }
    }

    public static IEnumerable<int> FindSequence(int start)
    {
        return null;
    }
}