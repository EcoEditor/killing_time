using UnityEngine;

namespace Gameplay.Clocks
{
    public interface IClockModel
    {
        void Init();
        int Damage { get; }
        int Health { get; }
        float Speed { get; }
        ClockType Type { get; }
    }
    
    public enum ClockType
    {
        Neutral = 0,
        Hostile = 1,
    }
}
