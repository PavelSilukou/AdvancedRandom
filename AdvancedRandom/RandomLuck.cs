using System;
using AdvancedRandom.Utils;

namespace AdvancedRandom
{
    internal class RandomLuck
    {
        private float _luck;
        private float _minLuck = -1.0f;
        private float _maxLuck = 1.0f;
        private float _extraLuck;
        public float Luck
        {
            get => _luck;
            private set => _luck = new MathUtils().Clamp(value, _minLuck, _maxLuck);
        }

        public float ExtraLuck
        {
            get => _extraLuck;
            private set => _extraLuck = new MathUtils().Clamp(value, -1.0f, 1.0f);
        }
        
        private readonly Random _random;

        public RandomLuck(int seed, float luck = 0.0f)
        {
            Luck = luck;
            _random = new Random(seed >> 2);
        }

        public bool CheckPositiveLuck(float successChance, float failureChance)
        {
            return CheckLuck(successChance, failureChance, 1.0f);
        }
        
        public bool CheckNegativeLuck(float successChance, float failureChance)
        {
            return CheckLuck(successChance, failureChance, -1.0f);
        }

        public void SetExtraLuck(float extraLuck)
        {
            ExtraLuck = extraLuck;
            if (ExtraLuck >= 0.0f)
            {
                _minLuck = -1.0f + ExtraLuck;
                _maxLuck = 1.0f;
            }
            else
            {
                _maxLuck = 1.0f - ExtraLuck;
                _minLuck = -1.0f;
            }

            Luck = _luck;
        }
        
        private bool CheckLuck(float successChance, float failureChance, float coefficient)
        {
            var value = _random.NextDouble();
            if (value > Luck * coefficient)
            {
                Luck += failureChance * coefficient;
                return false;
            }
            
            Luck -= successChance * coefficient;
            return true;
        }
    }
}