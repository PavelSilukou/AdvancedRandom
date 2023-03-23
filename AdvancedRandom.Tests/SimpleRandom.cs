namespace AdvancedRandom.Tests;

internal class SimpleRandom
{
    private readonly Random _random;

    public SimpleRandom(int seed)
    {
        _random = new Random(seed);
    }

    public int Next(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue);
    }
        
    public double NextDouble()
    {
        return _random.NextDouble();
    }
        
    public bool Chance(float chance)
    {
        return RandomExtensions.Chance(_random, chance);
    }
        
    public T Choice<T>(List<T> list)
    {
        return RandomExtensions.Choice(_random, list);
    }
        
    public T Choice<T>(List<T> list, List<int> chances)
    {
        return RandomExtensions.Choice(_random, list, chances);
    }
}