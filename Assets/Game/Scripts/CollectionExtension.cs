using System;
using System.Collections.Generic;
using System.Linq;


public static class CollectionExtension
{
    private static Random _random;

    private static Random GetLocalRandom()
    {
        _random ??= new Random();
        return _random;
    }


    public static List<T> GetRandomSubset<T>(this ICollection<T> source, int count, Random random = null)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        if (count > source.Count) throw new ArgumentException($"source.count < count {source.Count} < {count}");

        random ??= GetLocalRandom();

        var list = source.ToList();

        if (list.Count == 0) return new List<T>();
        if (list.Count == 1) return new List<T>(list);

        var result = new List<T>(count);

        for (var i = 0; i < count; i++)
        {
            int index = random.Next(list.Count);
            result.Add(list[index]);
            list.RemoveAt(index);
        }

        return result;
    }

    public static T GetRandom<T>(this ICollection<T> source, Random random = null)
    {
        random ??= GetLocalRandom();

        int targetElement = random.Next(source.Count);

        T result = default(T);

        int i = 0;
        foreach (var element in source)
        {
            if (i == targetElement)
            {
                result = element;
                break;
            }
            i++;
        }

        return result;
    }

    public static void SwapValues<T>(this IList<T> source, int index1, int index2)
    {
        (source[index1], source[index2]) = (source[index2], source[index1]);
    }

    public static void Shuffle<T>(this IList<T> list, Random random = null)
    {
        random ??= GetLocalRandom();

        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            list.SwapValues(k, n);
        }
    }
}
