using System.Text;

static void DisplayBoard()
{
    var moves = Enumerable.Range(1, 64);
    var movesInARow = 8;
    var builder = new StringBuilder();

    foreach (var move in moves)
        if (movesInARow is 1)
        {
            builder.Append($"{move}\n");
            movesInARow = 8;
        }
        else
        {
            builder.Append($"{move}\t");
            movesInARow -= 1;
        }
    WriteLine($"{builder}");
}
DisplayBoard();

WriteLine("---");


foreach (var n in new[]{1,4,12,32,57,50})
{
    WriteLine($"{n}: maxR {KnightsTourPb.MaxRight(n)}");
    WriteLine($"{n}: maxL {KnightsTourPb.MaxLeft(n)}");
}


