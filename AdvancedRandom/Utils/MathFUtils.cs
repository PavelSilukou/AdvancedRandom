using System;

namespace AdvancedRandom.Utils
{
    internal static class MathFUtils
    {
        public static float Clamp(float val, float min, float max)
        {
            return Math.Max(min, Math.Min(val, max));
        }

        public static float Lerp(float a, float b, float t)
        {
            return a * (1.0f - t) + b * t;
        }

        public static float InverseLerp(float a, float b, float value)
        {
            return (value - a) / (b - a);
        }
    }
}