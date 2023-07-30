using UnityEngine;

namespace Gameplay.Clocks
{
    public interface IClockModel
    {
        void Init();
        int GiveDamage { get; }
        int HealthPortions { get; }
        float Speed { get; }
        ClockType Type { get; }
    }
    
    public enum ClockType
    {
        Neutral = 0,
        Hostile = 1,
    }
}
