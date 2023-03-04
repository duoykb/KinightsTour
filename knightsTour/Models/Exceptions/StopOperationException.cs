namespace knightsTour.Models.Exceptions;

public class StopOperationException : Exception
{
    public StopOperationException(string message = "")
    :base(message){ }
}