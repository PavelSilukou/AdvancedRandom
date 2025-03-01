using System.Collections.Generic;
using AdvancedRandom.Utils;

namespace AdvancedRandom.TrueChance
{
    internal class TrueChance
    {
        private static TrueChance? _instance;
        private readonly List<TrueChanceElement> _trueChancesList;

        private TrueChance()
        {
            _trueChancesList = GetTrueChancesList();
        }
        
        public static TrueChance Instance => _instance ??= new TrueChance();

        private static List<TrueChanceElement> GetTrueChancesList()
        {
            return new List<TrueChanceElement>
            {
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.0f, Right = 0.0f},
                    TrueRange = new TrueChanceElementRange {Left = 0.0f, Right = 0.0f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.0f, Right = 0.0001f},
                    TrueRange = new TrueChanceElementRange {Left = 0.0f, Right = 0.000087f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.0001f, Right = 0.001f},
                    TrueRange = new TrueChanceElementRange {Left = 0.000087f, Right = 0.00084f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.001f, Right = 0.01f},
                    TrueRange = new TrueChanceElementRange {Left = 0.00084f, Right = 0.0084f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.01f, Right = 0.02f},
                    TrueRange = new TrueChanceElementRange {Left = 0.0084f, Right = 0.017f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.02f, Right = 0.03f},
                    TrueRange = new TrueChanceElementRange {Left = 0.017f, Right = 0.0257f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.03f, Right = 0.05f},
                    TrueRange = new TrueChanceElementRange {Left = 0.0257f, Right = 0.0434f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.05f, Right = 0.07f},
                    TrueRange = new TrueChanceElementRange {Left = 0.0434f, Right = 0.0615f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.07f, Right = 0.1f},
                    TrueRange = new TrueChanceElementRange {Left = 0.0615f, Right = 0.089f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.1f, Right = 0.15f},
                    TrueRange = new TrueChanceElementRange {Left = 0.089f, Right = 0.1385f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.15f, Right = 0.2f},
                    TrueRange = new TrueChanceElementRange {Left = 0.1385f, Right = 0.188f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.2f, Right = 0.35f},
                    TrueRange = new TrueChanceElementRange {Left = 0.188f, Right = 0.343f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.35f, Right = 0.5f},
                    TrueRange = new TrueChanceElementRange {Left = 0.343f, Right = 0.5f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.5f, Right = 0.65f},
                    TrueRange = new TrueChanceElementRange {Left = 0.5f, Right = 0.657f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.65f, Right = 0.8f},
                    TrueRange = new TrueChanceElementRange {Left = 0.657f, Right = 0.812f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.8f, Right = 0.85f},
                    TrueRange = new TrueChanceElementRange {Left = 0.812f, Right = 0.865f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.85f, Right = 0.9f},
                    TrueRange = new TrueChanceElementRange {Left = 0.865f, Right = 0.91f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.9f, Right = 0.93f},
                    TrueRange = new TrueChanceElementRange {Left = 0.91f, Right = 0.939f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.93f, Right = 0.95f},
                    TrueRange = new TrueChanceElementRange {Left = 0.939f, Right = 0.957f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.95f, Right = 0.97f},
                    TrueRange = new TrueChanceElementRange {Left = 0.957f, Right = 0.9745f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.97f, Right = 0.98f},
                    TrueRange = new TrueChanceElementRange {Left = 0.9745f, Right = 0.9833f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.98f, Right = 0.99f},
                    TrueRange = new TrueChanceElementRange {Left = 0.9833f, Right = 0.9918f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.99f, Right = 0.999f},
                    TrueRange = new TrueChanceElementRange {Left = 0.9918f, Right = 0.9992f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.999f, Right = 0.9999f},
                    TrueRange = new TrueChanceElementRange {Left = 0.9992f, Right = 0.99992f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 0.9999f, Right = 1.0f},
                    TrueRange = new TrueChanceElementRange {Left = 0.99992f, Right = 1.0f}
                },
                new TrueChanceElement
                {
                    OriginalRange = new TrueChanceElementRange {Left = 1.0f, Right = 1.0f},
                    TrueRange = new TrueChanceElementRange {Left = 1.0f, Right = 1.0f}
                }
            };
        }

        public float GetTrueChance(float chance)
        {
            var trueChanceElement = _trueChancesList.Find(element => element.OriginalRange.Left <= chance 
                                                                     && element.OriginalRange.Right >= chance);

            var t = MathFUtils.InverseLerp(trueChanceElement.OriginalRange.Left, 
                                              trueChanceElement.OriginalRange.Right, 
                                            chance);
            var trueChance = MathFUtils.Lerp(trueChanceElement.TrueRange.Left, 
                                                trueChanceElement.TrueRange.Right, 
                                                  t);
            return trueChance;
        }
    }
}