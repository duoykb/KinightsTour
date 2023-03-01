using knightsTour.Extensions;
namespace knightsTour;

public static class KnightsTourPb
{
    private static bool isSequenceFound = false;
    private static LinkedList<int> seq = new();
    public static LinkedList<int> FindSequence(int start)
    {
        static void Main(IEnumerable<int> moves, LinkedList<int> visitedMoves)
        {
            if(isSequenceFound) return;
            if (visitedMoves.Count > seq.Count) seq = new LinkedList<int>(visitedMoves);
            if (seq.Count is 64) isSequenceFound = true;
            foreach (var move in moves)
            {
                if(visitedMoves.Contains(move)) continue;
                visitedMoves.AddLast(move);
                Main(Moves.FindNextMovesFrom(move), visitedMoves);
                visitedMoves.RemoveLast();
            }
        }

        LinkedList<int> visitedMoves = new();
        visitedMoves.AddLast(12);
        Main(Moves.FindNextMovesFrom(start),visitedMoves);
        return seq;
    }
}