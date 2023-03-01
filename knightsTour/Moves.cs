using knightsTour.Extensions;

namespace knightsTour;

public static class Moves
{
    
    private static int MinLeft(int n) => (MaxRight(n) - 8) + 1;
    private static int MaxRight(int n) => (int)Math.Ceiling((double)n / 8) * 8;

    private static IEnumerable<int> TwoOnYOneOnX(int m, int directionY = -1, int directionX = -1)
    {
        var maxRight = MaxRight(m);
        var newMaxRight = maxRight + (16 * directionY);
        if (newMaxRight is > 64 or < 8)
            yield break;
        
        var twoOnY = newMaxRight - (maxRight - m);
        var newMinLeft = MinLeft(twoOnY);
        var oneOnX = twoOnY + (1 * directionX);
        
        if (newMinLeft <= oneOnX && oneOnX <= newMaxRight)
            yield return oneOnX;
    }

    private static IEnumerable<int> TwoOnXOneOnY(int m, int directionY = -1, int directionX = -1)
    {
        var maxRight = MaxRight(m);
        var minLeft = MinLeft(m);
        var twoOnX = m + (2 * directionX);
        
        if (! (minLeft <= twoOnX && twoOnX <= maxRight))
            yield break;

        var newMaxRight = maxRight + (directionY * 8);
        var oneOnY = newMaxRight - (maxRight - twoOnX);

        if (oneOnY is >= 1 and <= 64)
            yield return oneOnY;
    }

    public static IEnumerable<int> FindNextMovesFrom(int start) =>
        TwoOnYOneOnX(start )
            .Chain(TwoOnYOneOnX(start, directionX:1))
            .Chain(TwoOnYOneOnX(start, 1,1))
            .Chain(TwoOnYOneOnX(start, 1))
            .Chain(TwoOnXOneOnY(start))
            .Chain(TwoOnXOneOnY(start,directionY:1))
            .Chain(TwoOnXOneOnY(start,1,1))
            .Chain(TwoOnXOneOnY(start,directionX:1));
}