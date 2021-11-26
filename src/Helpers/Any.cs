namespace Helpers;

public static class Any
{
    private static int _min;
    private static int _max;
    private const int MaxAttemptsNumber = 1000;

    public const int IntMaxValue = 100000;
    public const int IntMinValue = -100000;

    public static string String(int length = 10)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        var random = new Random();
        var randomString = new string(Enumerable
            .Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)])
            .ToArray());

        return randomString;
    }

    public static int Int(int min = IntMinValue, int max = IntMaxValue)
    {
        _min = min;
        _max = max;

        return new Random().Next(min, max);
    }

    public static int Except(this int obj, params int[] items)
    {
        var attemptNumber = 0;
        var enumerable = items.ToList();

        while (enumerable.Contains(obj))
        {
            if (attemptNumber++ > MaxAttemptsNumber)
            {
                throw new ArgumentOutOfRangeException($"It is too complex to generate unique-random value for: ${obj}");
            }

            obj = Int(_min, _max);
        }

        return obj;
    }

    public static int PositiveInt(int max = 100000)
    {
        return Int(0, max);
    }

    public static int NegativeInt(int min = -100000)
    {
        return Int(min, 0);
    }

    public static Guid Guid()
    {
        return System.Guid.NewGuid();
    }

    public static string Except(this string obj, params string[] items)
    {
        var attemptNumber = 0;
        var enumerable = items.ToList();

        while (enumerable.Contains(obj))
        {
            if (attemptNumber++ > MaxAttemptsNumber)
            {
                throw new ArgumentOutOfRangeException($"It is too complex to generate unique-random value for: ${obj}");
            }

            obj = String(obj.Length);
        }

        return obj;
    }

    public static T From<T>(this T obj, params T[] items)
    {
        Random rand = new();

        var enumerable = items.ToList();
        return enumerable[rand.Next(enumerable.Count - 1)];
    }
}