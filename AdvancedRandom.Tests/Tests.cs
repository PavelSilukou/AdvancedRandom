using System.Diagnostics;

namespace AdvancedRandom.Tests;

[TestFixture]
public class Tests
{
    private const int RandomSeed = 50;
    private const int RandomSequenceCount = 1000000;
    private const int RandomSequenceCount2 = 100000;
    private SimpleRandom _simpleRandom = null!;
    private AdvancedRandom _advancedRandom = null!;

    [SetUp]
    public void SetUp()
    {
        _simpleRandom = new SimpleRandom(RandomSeed);
        _advancedRandom = new AdvancedRandom(RandomSeed);
    }
        
    [Test]
    public void Test_NextPositiveWith2Parameters()
    {
        var simpleSequence = GetSimpleRandomSequenceNext(1, 6, RandomSequenceCount);
        var advancedSequence = GetAdvancedRandomSequenceNextPositive(1, 6, RandomSequenceCount);
        Show(simpleSequence, advancedSequence);
        Assert.Pass();
    }
        
    [Test]
    public void Test_NextNegativeWith2Parameters()
    {
        var simpleSequence = GetSimpleRandomSequenceNext(1, 6, RandomSequenceCount);
        var advancedSequence = GetAdvancedRandomSequenceNextNegative(1, 6, RandomSequenceCount);
        Show(simpleSequence, advancedSequence);
        Assert.Pass();
    }
        
    [Test]
    public void Test_NextPositiveWith2ParametersAndExtraLuck()
    {
        var simpleSequence = GetSimpleRandomSequenceNext(1, 6, RandomSequenceCount);
        _advancedRandom.SetExtraLuck(0.5f);
        var advancedSequence = GetAdvancedRandomSequenceNextPositive(1, 6, RandomSequenceCount);
        Show(simpleSequence, advancedSequence);
        Assert.Pass();
    }
        
    [Test]
    public void Test_NextNegativeWith2ParametersAndExtraLuck()
    {
        var simpleSequence = GetSimpleRandomSequenceNext(1, 6, RandomSequenceCount);
        _advancedRandom.SetExtraLuck(0.5f);
        var advancedSequence = GetAdvancedRandomSequenceNextNegative(1, 6, RandomSequenceCount);
        Show(simpleSequence, advancedSequence);
        Assert.Pass();
    }
        
    [Test]
    public void Test_NextDoublePositive()
    {
        var simpleSequence = GetSimpleRandomSequenceNextDouble(RandomSequenceCount);
        var advancedSequence = GetAdvancedRandomSequenceNextDoublePositive(RandomSequenceCount);
        Show(simpleSequence, advancedSequence);
        Assert.Pass();
    }
        
    [Test]
    public void Test_NextDoubleNegative()
    {
        var simpleSequence = GetSimpleRandomSequenceNextDouble(RandomSequenceCount);
        var advancedSequence = GetAdvancedRandomSequenceNextDoubleNegative(RandomSequenceCount);
        Show(simpleSequence, advancedSequence);
        Assert.Pass();
    }
        
    [Test]
    public void Test_ChancePositive()
    {
        var simpleSequence = GetSimpleRandomSequenceChance(0.03f, RandomSequenceCount);
        var advancedSequence = GetAdvancedRandomSequenceChancePositive(0.03f, RandomSequenceCount);
        Show(simpleSequence, advancedSequence);
        Assert.Pass();
    }
        
    [Test]
    public void Test_ChanceNegative()
    {
        var simpleSequence = GetSimpleRandomSequenceChance(0.03f, RandomSequenceCount);
        var advancedSequence = GetAdvancedRandomSequenceChanceNegative(0.03f, RandomSequenceCount);
        Show(simpleSequence, advancedSequence);
        Assert.Pass();
    }
        
    [Test]
    public void Test_ChoicePositive()
    {
        var simpleSequence = GetSimpleRandomSequenceChoice(new List<string>() {"Test1", "Test2", "Test3"}, RandomSequenceCount);
        var advancedSequence = GetAdvancedRandomSequenceChoicePositive(new List<string>() {"Test1", "Test2", "Test3"}, RandomSequenceCount);
        Show(simpleSequence, advancedSequence);
        Assert.Pass();
    }
        
    [Test]
    public void Test_ChoiceNegative()
    {
        var simpleSequence = GetSimpleRandomSequenceChoice(new List<string>() {"Test1", "Test2", "Test3"}, RandomSequenceCount);
        var advancedSequence = GetAdvancedRandomSequenceChoiceNegative(new List<string>() {"Test1", "Test2", "Test3"}, RandomSequenceCount);
        Show(simpleSequence, advancedSequence);
        Assert.Pass();
    }
        
    [Test]
    public void Test_ChoiceChancePositive()
    {
        var simpleSequence = GetSimpleRandomSequenceChoiceChance(new List<string>() {"Test1", "Test2", "Test3"}, new List<int>() {1, 5, 10}, RandomSequenceCount);
        var advancedSequence = GetAdvancedRandomSequenceChoiceChancePositive(new List<string>() {"Test1", "Test2", "Test3"}, new List<int>() {1, 5, 10}, RandomSequenceCount);
        Show(simpleSequence, advancedSequence);
        Assert.Pass();
    }
        
    [Test]
    public void Test_ChoiceChanceNegative()
    {
        var simpleSequence = GetSimpleRandomSequenceChoiceChance(new List<string>() {"Test1", "Test2", "Test3"}, new List<int>() {1, 5, 10}, RandomSequenceCount);
        var advancedSequence = GetAdvancedRandomSequenceChoiceChanceNegative(new List<string>() {"Test1", "Test2", "Test3"}, new List<int>() {1, 5, 10}, RandomSequenceCount);
        Show(simpleSequence, advancedSequence);
        Assert.Pass();
    }
        
    [Test]
    public void Test_ExecutionTime_NextPositiveWith2Parameters()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        GetSimpleRandomSequenceNext(1, 6, RandomSequenceCount);
        stopwatch.Stop();
        var ts = stopwatch.Elapsed;
        Console.WriteLine("Elapsed Time is {0:00}:{1:00}:{2:00}.{3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

        stopwatch.Start();
        GetAdvancedRandomSequenceNextPositive(1, 6, RandomSequenceCount);
        stopwatch.Stop();
        ts = stopwatch.Elapsed;
        Console.WriteLine("Elapsed Time is {0:00}:{1:00}:{2:00}.{3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            
        Assert.Pass();
    }
        
    [Test]
    public void Test_TrueChanceTable()
    {
        var simpleSequences = new List<List<bool>>();
        for (var i = 0.01f; i < 1.0f; i += 0.01f)
        {
            var simpleSequence = GetSimpleRandomSequenceChance(i, RandomSequenceCount2);
            simpleSequences.Add(simpleSequence);
        }
            
        var advancedSequences = new List<List<bool>>();
        for (var i = 0.01f; i < 1.0f; i += 0.01f)
        {
            var advancedSequence = GetAdvancedRandomSequenceChancePositive(i, RandomSequenceCount2);
            advancedSequences.Add(advancedSequence);
        }
            
        Show(simpleSequences, advancedSequences);
        Assert.Pass();
    }
        
    private List<int> GetSimpleRandomSequenceNext(int minValue, int maxValue, int count)
    {
        var sequence = new List<int>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _simpleRandom.Next(minValue, maxValue);
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<int> GetAdvancedRandomSequenceNextPositive(int minValue, int maxValue, int count)
    {
        var sequence = new List<int>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _advancedRandom.NextFromNegativeToPositive(minValue, maxValue);
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<int> GetAdvancedRandomSequenceNextNegative(int minValue, int maxValue, int count)
    {
        var sequence = new List<int>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _advancedRandom.NextFromPositiveToNegative(minValue, maxValue);
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<double> GetSimpleRandomSequenceNextDouble(int count)
    {
        var sequence = new List<double>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _simpleRandom.NextDouble();
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<double> GetAdvancedRandomSequenceNextDoublePositive(int count)
    {
        var sequence = new List<double>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _advancedRandom.NextDoubleFromNegativeToPositive();
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<double> GetAdvancedRandomSequenceNextDoubleNegative(int count)
    {
        var sequence = new List<double>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _advancedRandom.NextDoubleFromPositiveToNegative();
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<bool> GetSimpleRandomSequenceChance(float chance, int count)
    {
        var sequence = new List<bool>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _simpleRandom.Chance(chance);
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<bool> GetAdvancedRandomSequenceChancePositive(float chance, int count)
    {
        var sequence = new List<bool>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _advancedRandom.ChancePositive(chance);
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<bool> GetAdvancedRandomSequenceChanceNegative(float chance, int count)
    {
        var sequence = new List<bool>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _advancedRandom.ChanceNegative(chance);
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<string> GetSimpleRandomSequenceChoice(List<string> list, int count)
    {
        var sequence = new List<string>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _simpleRandom.Choice(list);
            sequence.Add(item);
        }
            
        return sequence;
    }

    private List<string> GetAdvancedRandomSequenceChoicePositive(List<string> list, int count)
    {
        var sequence = new List<string>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _advancedRandom.ChoiceFromNegativeToPositive(list);
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<string> GetAdvancedRandomSequenceChoiceNegative(List<string> list, int count)
    {
        var sequence = new List<string>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _advancedRandom.ChoiceFromPositiveToNegative(list);
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<string> GetSimpleRandomSequenceChoiceChance(List<string> list, List<int> chances, int count)
    {
        var sequence = new List<string>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _simpleRandom.Choice(list, chances);
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<string> GetAdvancedRandomSequenceChoiceChancePositive(List<string> list, List<int> chances, int count)
    {
        var sequence = new List<string>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _advancedRandom.ChoiceFromNegativeToPositive(list, chances);
            sequence.Add(item);
        }
            
        return sequence;
    }
        
    private List<string> GetAdvancedRandomSequenceChoiceChanceNegative(List<string> list, List<int> chances, int count)
    {
        var sequence = new List<string>(count);
        
        for (var i = 0; i < count; i++)
        {
            var item = _advancedRandom.ChoiceFromPositiveToNegative(list, chances);
            sequence.Add(item);
        }
            
        return sequence;
    }

    private void Show(List<int> simpleSequence, List<int> advancedSequence)
    {
        var simpleSequenceQuery1 = simpleSequence.GroupBy(item => item, _ => 1, (i, values) => new {Key = i, Count = values.Count()});
        var simpleSequenceSortedQuery1 = simpleSequenceQuery1.OrderBy(item => item.Key).ToList();
        var advancedSequenceQuery1 = advancedSequence.GroupBy(item => item, _ => 1, (i, values) => new {Key = i, Count = values.Count()});
        var advancedSequenceSortedQuery1 = advancedSequenceQuery1.OrderBy(item => item.Key).ToList();
            
        var simpleSequenceChunks = SplitSequenceByRepeatedChunks(simpleSequence);
        var advancedSequenceChunks = SplitSequenceByRepeatedChunks(advancedSequence);
        var simpleSequenceQuery2 = simpleSequenceChunks.GroupBy(chunk => chunk[0], chunk => chunk, (i, lists) => new {Key = i, Lists = lists});
        var simpleSequenceSortedQuery2 = simpleSequenceQuery2.OrderBy(item => item.Key).ToList();
        var advancedSequenceQuery2 = advancedSequenceChunks.GroupBy(chunk => chunk[0], chunk => chunk, (i, lists) => new {Key = i, Lists = lists});
        var advancedSequenceSortedQuery2 = advancedSequenceQuery2.OrderBy(item => item.Key).ToList();
            
        Console.WriteLine($"|{"Item",5}|{"Simple Random",20}|{"Advanced Random",20}|");
        Console.WriteLine($"|{"     ",5}|{"Items Count",41}|");
        for (var i = 0; i < simpleSequenceSortedQuery1.Count; i++)
        {
            Console.WriteLine($"|{simpleSequenceSortedQuery1[i].Key,5}|{simpleSequenceSortedQuery1[i].Count,20}|{advancedSequenceSortedQuery1[i].Count,20}|");
        }
            
        Console.WriteLine($"|{"     ",5}|{"Max Sequence",41}|");
        for (var i = 0; i < simpleSequenceSortedQuery2.Count; i++)
        {
            Console.WriteLine($"|{simpleSequenceSortedQuery2[i].Key,5}|{simpleSequenceSortedQuery2[i].Lists.Max(list => list.Count),20}|{advancedSequenceSortedQuery2[i].Lists.Max(list => list.Count),20}|");
        }
            
        Console.WriteLine($"|{"     ",5}|{"Average Sequences Length",41}|");
        for (var i = 0; i < simpleSequenceSortedQuery2.Count; i++)
        {
            Console.WriteLine($"|{simpleSequenceSortedQuery2[i].Key,5}|{simpleSequenceSortedQuery2[i].Lists.Average(list => list.Count),20}|{advancedSequenceSortedQuery2[i].Lists.Average(list => list.Count),20}|");
        }
    }
        
    private void Show(IEnumerable<double> simpleSequence, IEnumerable<double> advancedSequence)
    {
        var simpleSequenceInt = simpleSequence.Select(el => (int)(el * 10)).ToList();
        var advancedSequenceInt = advancedSequence.Select(el => (int)(el * 10)).ToList();
            
        var simpleSequenceQuery1 = simpleSequenceInt.GroupBy(item => item, _ => 1, (i, values) => new {Key = i, Count = values.Count()});
        var simpleSequenceSortedQuery1 = simpleSequenceQuery1.OrderBy(item => item.Key).ToList();
        var advancedSequenceQuery1 = advancedSequenceInt.GroupBy(item => item, _ => 1, (i, values) => new {Key = i, Count = values.Count()});
        var advancedSequenceSortedQuery1 = advancedSequenceQuery1.OrderBy(item => item.Key).ToList();
            
        var simpleSequenceChunks = SplitSequenceByRepeatedChunks(simpleSequenceInt);
        var advancedSequenceChunks = SplitSequenceByRepeatedChunks(advancedSequenceInt);
        var simpleSequenceQuery2 = simpleSequenceChunks.GroupBy(chunk => chunk[0], chunk => chunk, (i, lists) => new {Key = i, Lists = lists});
        var simpleSequenceSortedQuery2 = simpleSequenceQuery2.OrderBy(item => item.Key).ToList();
        var advancedSequenceQuery2 = advancedSequenceChunks.GroupBy(chunk => chunk[0], chunk => chunk, (i, lists) => new {Key = i, Lists = lists});
        var advancedSequenceSortedQuery2 = advancedSequenceQuery2.OrderBy(item => item.Key).ToList();
            
        Console.WriteLine($"|{"Item",5}|{"Simple Random",20}|{"Advanced Random",20}|");
        Console.WriteLine($"|{"     ",5}|{"Items Count",41}|");
        for (var i = 0; i < simpleSequenceSortedQuery1.Count; i++)
        {
            Console.WriteLine($"|{simpleSequenceSortedQuery1[i].Key,5}|{simpleSequenceSortedQuery1[i].Count,20}|{advancedSequenceSortedQuery1[i].Count,20}|");
        }
            
        Console.WriteLine($"|{"     ",5}|{"Max Sequence",41}|");
        for (var i = 0; i < simpleSequenceSortedQuery2.Count; i++)
        {
            Console.WriteLine($"|{simpleSequenceSortedQuery2[i].Key,5}|{simpleSequenceSortedQuery2[i].Lists.Max(list => list.Count),20}|{advancedSequenceSortedQuery2[i].Lists.Max(list => list.Count),20}|");
        }
            
        Console.WriteLine($"|{"     ",5}|{"Average Sequences Length",41}|");
        for (var i = 0; i < simpleSequenceSortedQuery2.Count; i++)
        {
            Console.WriteLine($"|{simpleSequenceSortedQuery2[i].Key,5}|{simpleSequenceSortedQuery2[i].Lists.Average(list => list.Count),20}|{advancedSequenceSortedQuery2[i].Lists.Average(list => list.Count),20}|");
        }
    }
        
    private static void Show(List<bool> simpleSequence, List<bool> advancedSequence)
    {
        var simpleSequenceQuery1 = simpleSequence.GroupBy(item => item, _ => 1, (i, values) => new {Key = i, Count = values.Count()});
        var simpleSequenceSortedQuery1 = simpleSequenceQuery1.OrderBy(item => item.Key).ToList();
        var advancedSequenceQuery1 = advancedSequence.GroupBy(item => item, _ => 1, (i, values) => new {Key = i, Count = values.Count()});
        var advancedSequenceSortedQuery1 = advancedSequenceQuery1.OrderBy(item => item.Key).ToList();
            
        var simpleSequenceChunks = SplitSequenceByRepeatedChunksChance(simpleSequence);
        var advancedSequenceChunks = SplitSequenceByRepeatedChunksChance(advancedSequence);
        var simpleSequenceQuery2 = simpleSequenceChunks.GroupBy(chunk => chunk[0], chunk => chunk, (i, lists) => new {Key = i, Lists = lists});
        var simpleSequenceSortedQuery2 = simpleSequenceQuery2.OrderBy(item => item.Key).ToList();
        var advancedSequenceQuery2 = advancedSequenceChunks.GroupBy(chunk => chunk[0], chunk => chunk, (i, lists) => new {Key = i, Lists = lists});
        var advancedSequenceSortedQuery2 = advancedSequenceQuery2.OrderBy(item => item.Key).ToList();
            
        Console.WriteLine($"|{"Item",7}|{"Simple Random",20}|{"Advanced Random",20}|");
        Console.WriteLine($"|{"     ",7}|{"Items Count",41}|");
        for (var i = 0; i < simpleSequenceSortedQuery1.Count; i++)
        {
            Console.WriteLine($"|{simpleSequenceSortedQuery1[i].Key,7}|{simpleSequenceSortedQuery1[i].Count,20}|{advancedSequenceSortedQuery1[i].Count,20}|");
        }
            
        Console.WriteLine($"|{"     ",7}|{"Max Sequence",41}|");
        for (var i = 0; i < simpleSequenceSortedQuery2.Count; i++)
        {
            Console.WriteLine($"|{simpleSequenceSortedQuery2[i].Key,7}|{simpleSequenceSortedQuery2[i].Lists.Max(list => list.Count),20}|{advancedSequenceSortedQuery2[i].Lists.Max(list => list.Count),20}|");
        }
            
        Console.WriteLine($"|{"     ",7}|{"Average Sequences Length",41}|");
        for (var i = 0; i < simpleSequenceSortedQuery2.Count; i++)
        {
            Console.WriteLine($"|{simpleSequenceSortedQuery2[i].Key,7}|{simpleSequenceSortedQuery2[i].Lists.Average(list => list.Count),20}|{advancedSequenceSortedQuery2[i].Lists.Average(list => list.Count),20}|");
        }
    }
        
    private static void Show(List<string> simpleSequence, List<string> advancedSequence)
    {
        var simpleSequenceQuery1 = simpleSequence.GroupBy(item => item, _ => 1, (i, values) => new {Key = i, Count = values.Count()});
        var simpleSequenceSortedQuery1 = simpleSequenceQuery1.OrderBy(item => item.Key).ToList();
        var advancedSequenceQuery1 = advancedSequence.GroupBy(item => item, _ => 1, (i, values) => new {Key = i, Count = values.Count()});
        var advancedSequenceSortedQuery1 = advancedSequenceQuery1.OrderBy(item => item.Key).ToList();
            
        var simpleSequenceChunks = SplitSequenceByRepeatedChunksChoice(simpleSequence);
        var advancedSequenceChunks = SplitSequenceByRepeatedChunksChoice(advancedSequence);
        var simpleSequenceQuery2 = simpleSequenceChunks.GroupBy(chunk => chunk[0], chunk => chunk, (i, lists) => new {Key = i, Lists = lists});
        var simpleSequenceSortedQuery2 = simpleSequenceQuery2.OrderBy(item => item.Key).ToList();
        var advancedSequenceQuery2 = advancedSequenceChunks.GroupBy(chunk => chunk[0], chunk => chunk, (i, lists) => new {Key = i, Lists = lists});
        var advancedSequenceSortedQuery2 = advancedSequenceQuery2.OrderBy(item => item.Key).ToList();
            
        Console.WriteLine($"|{"Item",7}|{"Simple Random",20}|{"Advanced Random",20}|");
        Console.WriteLine($"|{"     ",7}|{"Items Count",41}|");
        for (var i = 0; i < simpleSequenceSortedQuery1.Count; i++)
        {
            Console.WriteLine($"|{simpleSequenceSortedQuery1[i].Key,7}|{simpleSequenceSortedQuery1[i].Count,20}|{advancedSequenceSortedQuery1[i].Count,20}|");
        }
            
        Console.WriteLine($"|{"     ",7}|{"Max Sequence",41}|");
        for (var i = 0; i < simpleSequenceSortedQuery2.Count; i++)
        {
            Console.WriteLine($"|{simpleSequenceSortedQuery2[i].Key,7}|{simpleSequenceSortedQuery2[i].Lists.Max(list => list.Count),20}|{advancedSequenceSortedQuery2[i].Lists.Max(list => list.Count),20}|");
        }
            
        Console.WriteLine($"|{"     ",7}|{"Average Sequences Length",41}|");
        for (var i = 0; i < simpleSequenceSortedQuery2.Count; i++)
        {
            Console.WriteLine($"|{simpleSequenceSortedQuery2[i].Key,7}|{simpleSequenceSortedQuery2[i].Lists.Average(list => list.Count),20}|{advancedSequenceSortedQuery2[i].Lists.Average(list => list.Count),20}|");
        }
    }
        
    private static void Show(IReadOnlyList<List<bool>> simpleSequences, IReadOnlyList<List<bool>> advancedSequences)
    {
        Console.WriteLine($"|{"Item",7}|{"Simple Random",20}|{"Advanced Random",20}|");
        Console.WriteLine($"|{"     ",7}|{"True Count",41}|");
        for (var j = 0; j < 99; j++)
        {
            var simpleSequenceQuery1 = simpleSequences[j].GroupBy(item => item, _ => 1, (i, values) => new {Key = i, Count = values.Count()});
            var simpleSequenceSortedQuery1 = simpleSequenceQuery1.OrderBy(item => item.Key).ToList();
            var advancedSequenceQuery1 = advancedSequences[j].GroupBy(item => item, _ => 1, (i, values) => new {Key = i, Count = values.Count()});
            var advancedSequenceSortedQuery1 = advancedSequenceQuery1.OrderBy(item => item.Key).ToList();
            Console.WriteLine($"|{0.01f * (j + 1),7}|{simpleSequenceSortedQuery1[1].Count,20}|{advancedSequenceSortedQuery1[1].Count,20}|");
        }
    }

    private static IEnumerable<List<int>> SplitSequenceByRepeatedChunks(List<int> sequence)
    {
        var result = new List<List<int>>();
        var currentIndex = 0;
        var currentValue = sequence[currentIndex];
        for (var i = 1; i < sequence.Count; i++)
        {
            if (sequence[i] == currentValue) continue;
                
            var subsequence = sequence.GetRange(currentIndex, i - currentIndex);
            result.Add(subsequence);
            currentValue = sequence[i];
            currentIndex = i;
        }
            
        var lastSubsequence = sequence.GetRange(currentIndex, sequence.Count - currentIndex);
        result.Add(lastSubsequence);
            
        return result;
    }
        
    private static IEnumerable<List<bool>> SplitSequenceByRepeatedChunksChance(List<bool> sequence)
    {
        var result = new List<List<bool>>();
        var currentIndex = 0;
        var currentValue = sequence[currentIndex];
        for (var i = 1; i < sequence.Count; i++)
        {
            if (sequence[i] == currentValue) continue;
                
            var subsequence = sequence.GetRange(currentIndex, i - currentIndex);
            result.Add(subsequence);
            currentValue = sequence[i];
            currentIndex = i;
        }
            
        var lastSubsequence = sequence.GetRange(currentIndex, sequence.Count - currentIndex);
        result.Add(lastSubsequence);
            
        return result;
    }
        
    private static IEnumerable<List<string>> SplitSequenceByRepeatedChunksChoice(List<string> sequence)
    {
        var result = new List<List<string>>();
        var currentIndex = 0;
        var currentValue = sequence[currentIndex];
        for (var i = 1; i < sequence.Count; i++)
        {
            if (sequence[i] == currentValue) continue;
                
            var subsequence = sequence.GetRange(currentIndex, i - currentIndex);
            result.Add(subsequence);
            currentValue = sequence[i];
            currentIndex = i;
        }
            
        var lastSubsequence = sequence.GetRange(currentIndex, sequence.Count - currentIndex);
        result.Add(lastSubsequence);
            
        return result;
    }
}