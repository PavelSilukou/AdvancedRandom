using System;

namespace AdvancedRandom.Utils
{
    internal class MathUtils
    {
        public float Clamp(float val, float min, float max)
        {
            return Math.Max(min, Math.Min(val, max));
        }

        public float Lerp(float a, float b, float t)
        {
            return a * (1.0f - t) + b * t;
        }

        public float InverseLerp(float a, float b, float value)
        {
            return (value - a) / (b - a);
        }
    }
}