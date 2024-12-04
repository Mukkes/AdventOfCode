namespace AdventOfCodeLibrary.ExtensionClasses;
public static class EnumExtensions
{
    public static IEnumerable<T> GetValues<T>()
    {
        foreach (object value in Enum.GetValues(typeof(T)))
        {
            yield return (T)value;
        }
    }
}
