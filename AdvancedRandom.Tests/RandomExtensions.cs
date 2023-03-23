namespace AdvancedRandom.Tests;

internal static class RandomExtensions
{
    public static int Next(Random random, int minValue, int maxValue, bool isLastInclusive = true)
    {
        if (minValue > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(minValue), "MinValue should be less than MaxValue.");
        }
            
        var newMaxValue = isLastInclusive ? maxValue + 1 : maxValue;
        return random.Next(minValue, newMaxValue);
    }

    public static void Shuffle<T>(Random random, IList<T> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = random.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }

    public static T Choice<T>(Random random, List<T> list)
    {
        if (list.Count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(list), "List is empty.");
        }
            
        var index = random.Next(list.Count);
        return list[index];
    }
        
    public static T Choice<T>(Random random, List<T> list, List<int> chances)
    {
        if (list.Count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(list), "Values list is empty.");
        }
        if (list.Count != chances.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(chances), "Chances list and values list should have the same elements count.");
        }

        var totalChances = chances.Sum();
        var chancesSumList = chances.Select((_, i) => chances.GetRange(0, i + 1).Sum()).ToList();
            
        var value = Next(random, 1, totalChances);
        var chanceIndex = chancesSumList.FindIndex(ch => ch >= value);
        return list[chanceIndex];
    }

    public static bool Chance(Random random, float chance)
    {
        if (chance is < 0.0f or > 1.0f)
        {
            throw new ArgumentOutOfRangeException(nameof(chance), "Chance should be between 0.0 and 1.0.");
        }
            
        var newValue = random.NextDouble();
        return newValue < chance;
    }
}