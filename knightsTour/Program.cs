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

var builder = new StringBuilder();
foreach (var i in KnightsTourPb.FindSequence(12)) builder.Append($"{i}->");
builder.Remove(builder.Length-1, 1);

WriteLine($"{builder}");