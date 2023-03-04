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
    /// <summary>
    /// Given a chess board where each position is represented as a number between 1-64,
    /// the method returns the next possible moves.
    /// </summary>
    /// <param name="current">a value between 1 and 64 including both.</param>
    /// <returns>IEnumerable of the available moves from the given position</returns>
    public static IEnumerable<int> FindNextMovesFrom(int current) =>
        TwoOnYOneOnX(current )
            .Chain(TwoOnYOneOnX(current, directionX:1))
            .Chain(TwoOnYOneOnX(current, 1,1))
            .Chain(TwoOnYOneOnX(current, 1))
            .Chain(TwoOnXOneOnY(current))
            .Chain(TwoOnXOneOnY(current,directionY:1))
            .Chain(TwoOnXOneOnY(current,1,1))
            .Chain(TwoOnXOneOnY(current,directionX:1));
}