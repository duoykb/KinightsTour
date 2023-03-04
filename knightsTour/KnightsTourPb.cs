using knightsTour.Models.Exceptions;

namespace knightsTour;
public static class KnightsTourPb
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="start"></param>
    /// <returns>the 64 sequence of moves</returns>
    /// <exception cref="StopOperationException">Raised when the max number of moves/64/ is reached as a way to exit the call stack.</exception>
    public static LinkedList<int> FindSequence(int start)
    {
        static void Main(IEnumerable<int> moves, LinkedList<int> visitedMoves)
        {
            // the 61 should be 64
            if (visitedMoves.Count == 61)
                throw new StopOperationException();
            foreach (var move in moves)
            {
                if(visitedMoves.Contains(move)) continue;
                visitedMoves.AddLast(move);
                Main(Moves.FindNextMovesFrom(move), visitedMoves);
                visitedMoves.RemoveLast();
            }
        }
        LinkedList<int> visitedMoves = new();
        visitedMoves.AddLast(start);
        try
        {
            Main(Moves.FindNextMovesFrom(start),visitedMoves);
        }catch(StopOperationException){}
        return visitedMoves;
    }
}