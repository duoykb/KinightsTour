namespace knightsTour.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<TElement> Chain<TElement>(this IEnumerable<TElement> enumerable,
        IEnumerable<TElement> enumerableTwo)
    {
        foreach (var element in enumerable)
            yield return element;

        foreach (var element in enumerableTwo)
            yield return element;
    }
}