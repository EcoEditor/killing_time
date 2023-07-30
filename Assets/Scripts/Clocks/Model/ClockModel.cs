using UnityEngine;

namespace Gameplay.Clocks
{
    [CreateAssetMenu(menuName = "Clocks/Create clock")]
    public class ClockModel : ScriptableObject, IClockModel
    {
        [SerializeField] private ClockType clockType;
        [Range(1,20)]
        [SerializeField] private int healthPortions;
        [Range(0,20)]
        [SerializeField] private int giveDamage;
        [SerializeField] private float speed;
        
        public void Init()
        {
            
        }

        public int GiveDamage => giveDamage;
        public int HealthPortions => healthPortions;
        public float Speed => speed;
        public ClockType Type => clockType;
    }
}