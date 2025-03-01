// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

#pragma warning disable S3776 // Cognitive Complexity of methods should not be too high
#pragma warning disable S1066 // Mergeable "if" statements should be combined

using System;
using System.Collections.Generic;
using System.Linq;
using AdvancedRandom.Utils;

namespace AdvancedRandom
{
    public class AdvancedRandom : Random
    {
        private readonly RandomLuck _randomLuck;

        public AdvancedRandom() : this(Environment.TickCount)
        {
        }

        public AdvancedRandom(int seed, float luck = 0.0f, float luckWeight = 0.5f) : base(seed)
        {
            Seed = seed;
            _randomLuck = new RandomLuck(seed, luck);
            LuckWeight = MathFUtils.Clamp(luckWeight, 0.0f, 1.0f);
        }
        
        public float Seed { get; }
        public float Luck => _randomLuck.Luck;
        public float LuckWeight { get; }
        
        public float ExtraLuck => _randomLuck.ExtraLuck;

        public override int Next()
        {
            return Next(0, int.MaxValue);
        }
        
        public override int Next(int maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxValue), "MaxValue should be more than 0.");
            }
            
            return Next(0, maxValue);
        }
        
        public override int Next(int minValue, int maxValue)
        {
            return NextFromNegativeToPositive(minValue, maxValue);
        }

        public int NextFromNegativeToPositive(int minValue, int maxValue)
        {
            if (maxValue - minValue < 2)
            {
                return minValue;
            }
            
            NextCalc(minValue, maxValue, out var minNegativeValue, out var maxNegativeValue, out var minPositiveValue, out var maxPositiveValue, out var neutralValue, out var percentsPerValue, out var value);

            if (value == neutralValue)
            {
                if (Luck < 0.0f)
                {
                    if (_randomLuck.CheckNegativeLuck(percentsPerValue, percentsPerValue))
                    {
                        value = base.Next(minNegativeValue, maxNegativeValue);
                    }
                }
                else if (Luck > 0.0f)
                {
                    if (_randomLuck.CheckPositiveLuck(percentsPerValue, percentsPerValue))
                    {
                        value = base.Next(minPositiveValue, maxPositiveValue);
                    }
                }
            }
            else if (value >= minNegativeValue && value < maxNegativeValue)
            {
                percentsPerValue *= maxNegativeValue - value;
                if (_randomLuck.CheckPositiveLuck(percentsPerValue, percentsPerValue))
                {
                    value = base.Next(minPositiveValue, maxPositiveValue);
                }
            }
            else if (value >= minPositiveValue && value < maxPositiveValue)
            {
                percentsPerValue *= value - minPositiveValue + 1;
                if (_randomLuck.CheckNegativeLuck(percentsPerValue, percentsPerValue))
                {
                    value = base.Next(minNegativeValue, maxNegativeValue);
                }
            }

            return value;
        }
        
        public int NextFromPositiveToNegative(int minValue, int maxValue)
        {
            if (maxValue - minValue < 2)
            {
                return minValue;
            }
            
            NextCalc(minValue, maxValue, out var minPositiveValue, out var maxPositiveValue, out var minNegativeValue, out var maxNegativeValue, out var neutralValue, out var percentsPerValue, out var value);

            if (value == neutralValue)
            {
                if (Luck < 0.0f)
                {
                    if (_randomLuck.CheckNegativeLuck(percentsPerValue, percentsPerValue))
                    {
                        value = base.Next(minNegativeValue, maxNegativeValue);
                    }
                }
                else if (Luck > 0.0f)
                {
                    if (_randomLuck.CheckPositiveLuck(percentsPerValue, percentsPerValue))
                    {
                        value = base.Next(minPositiveValue, maxPositiveValue);
                    }
                }
            }
            else if (value >= minNegativeValue && value < maxNegativeValue)
            {
                percentsPerValue *= value - minNegativeValue + 1;
                if (_randomLuck.CheckPositiveLuck(percentsPerValue, percentsPerValue))
                {
                    value = base.Next(minPositiveValue, maxPositiveValue);
                }
            }
            else if (value >= minPositiveValue && value < maxPositiveValue)
            {
                percentsPerValue *= maxPositiveValue - value;
                if (_randomLuck.CheckNegativeLuck(percentsPerValue, percentsPerValue))
                {
                    value = base.Next(minNegativeValue, maxNegativeValue);
                }
            }

            return value;
        }
        
        public override double NextDouble()
        {
            return NextDoubleFromNegativeToPositive();
        }

        public double NextDoubleFromNegativeToPositive()
        {
            NextDoubleCalc(out var trueChance, out var value);

            if (value < 0.5f)
            {
                if (_randomLuck.CheckPositiveLuck(trueChance, trueChance))
                {
                    value = NextDouble(0.5f, 1.0f);
                }
            }
            else if (value > 0.5f)
            {
                if (_randomLuck.CheckNegativeLuck(trueChance, trueChance))
                {
                    value = NextDouble(0.0f, 0.5f);
                }
            }
            else
            {
                if (Luck < 0.0f)
                {
                    if (_randomLuck.CheckNegativeLuck(trueChance, trueChance))
                    {
                        value = NextDouble(0.0f, 0.5f);
                    }
                }
                else if (Luck > 0.0f)
                {
                    if (_randomLuck.CheckPositiveLuck(trueChance, trueChance))
                    {
                        value = NextDouble(0.5f, 1.0f);
                    }
                }
            }
            
            return value;
        }
        
        public double NextDoubleFromPositiveToNegative()
        {
            NextDoubleCalc(out var trueChance, out var value);
            
            if (value < 0.5f)
            {
                if (_randomLuck.CheckNegativeLuck(trueChance, trueChance))
                {
                    value = NextDouble(0.5f, 1.0f);
                }
            }
            else if (value > 0.5f)
            {
                if (_randomLuck.CheckPositiveLuck(trueChance, trueChance))
                {
                    value = NextDouble(0.0f, 0.5f);
                }
            }
            else
            {
                if (Luck < 0.0f)
                {
                    if (_randomLuck.CheckPositiveLuck(trueChance, trueChance))
                    {
                        value = NextDouble(0.0f, 0.5f);
                    }
                }
                else if (Luck > 0.0f)
                {
                    if (_randomLuck.CheckNegativeLuck(trueChance, trueChance))
                    {
                        value = NextDouble(0.5f, 1.0f);
                    }
                }
            }

            return value;
        }

        public bool Chance(float chance)
        {
            return ChancePositive(chance);
        }
        
        public bool ChancePositive(float chance)
        {
            ChanceCalc(chance, out var trueChance, out var result);
            
            result = result ? !_randomLuck.CheckNegativeLuck(trueChance, 1.0f - trueChance) 
                : _randomLuck.CheckPositiveLuck(1.0f - trueChance, trueChance);

            return result;
        }
        
        public bool ChanceNegative(float chance)
        {
            ChanceCalc(chance, out var trueChance, out var result);
            
            result = result ? !_randomLuck.CheckPositiveLuck(trueChance, 1.0f - trueChance) 
                : _randomLuck.CheckNegativeLuck(1.0f - trueChance, trueChance);

            return result;
        }
        
        public T Choice<T>(List<T> list)
        {
            return ChoiceFromNegativeToPositive(list);
        }
        
        public T Choice<T>(List<T> list, List<int> chances)
        {
            return ChoiceFromNegativeToPositive(list, chances);
        }
        
        public T ChoiceFromNegativeToPositive<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(list), "List is empty.");
            }
            
            var index = NextFromNegativeToPositive(0, list.Count);
            return list[index];
        }
        
        public T ChoiceFromNegativeToPositive<T>(List<T> list, List<int> chances)
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
            var chancesSumList = chances.Select((t, i) => chances.GetRange(0, i + 1).Sum()).ToList();
            
            var value = NextFromNegativeToPositive(0, totalChances);
            var chanceIndex = chancesSumList.FindIndex(ch => ch > value);
            return list[chanceIndex];
        }
        
        public T ChoiceFromPositiveToNegative<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(list), "List is empty.");
            }
            
            var index = NextFromPositiveToNegative(0, list.Count);
            return list[index];
        }
        
        public T ChoiceFromPositiveToNegative<T>(List<T> list, List<int> chances)
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
            var chancesSumList = chances.Select((t, i) => chances.GetRange(0, i + 1).Sum()).ToList();
            
            var value = NextFromPositiveToNegative(0, totalChances);
            var chanceIndex = chancesSumList.FindIndex(ch => ch > value);
            return list[chanceIndex];
        }
        
        public void SetExtraLuck(float extraLuck)
        {
            _randomLuck.SetExtraLuck(extraLuck);
        }
        
        private void ChanceCalc(float chance, out float trueChance, out bool result)
        {
            if (chance < 0.0f || chance > 1.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(chance), "Chance should be between 0.0 and 1.0.");
            }
            
            var value = base.NextDouble();
            result = value < chance;
            trueChance = TrueChance.TrueChance.Instance.GetTrueChance(chance);
        }

        private void NextCalc(int minValue, int maxValue, out int minLeftValues, out int maxLeftValues, out int minRightValues, out int maxRightValues, out int midValue, out float percentsPerValue, out int value)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(minValue), "MinValue should be less than MaxValue.");
            }
        
            var valuesCount = maxValue - minValue;
            var ceilingValue = (int)Math.Ceiling(valuesCount / 2.0f);
            var floorValue = (int)Math.Floor(valuesCount / 2.0f);
            var middleValue = minValue + floorValue;
            
            minLeftValues = minValue;
            maxLeftValues = minValue + ceilingValue;
            minRightValues = middleValue;
            maxRightValues = middleValue + ceilingValue;
            midValue = valuesCount % 2 != 0 ? middleValue : int.MaxValue;
            percentsPerValue = (float)(1.0f / Math.Ceiling(valuesCount / 2.0f)) * LuckWeight;
        
            value = base.Next(minValue, maxValue);
        }

        private void NextDoubleCalc(out float trueChance, out double value)
        {
            value = base.NextDouble();
            var floatValue = (float)value;
            trueChance = floatValue < 0.5f 
                ? TrueChance.TrueChance.Instance.GetTrueChance(1.0f - floatValue) 
                : TrueChance.TrueChance.Instance.GetTrueChance(floatValue);
            trueChance *= LuckWeight;
        }
        
        private double NextDouble(float minValue, float maxValue)
        {
            var value = base.NextDouble();
            while ((float)value <= minValue || (float)value >= maxValue)
            {
                value = base.NextDouble();
            }
        
            return value;
        }
    }
}