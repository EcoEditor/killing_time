using UnityEngine;

namespace Gameplay.Clocks
{
    [CreateAssetMenu(menuName = "Clocks/Create clock")]
    public class ClockModel : ScriptableObject, IClockModel
    {
        [SerializeField] private ClockType clockType;
        [Range(0,4)]
        [SerializeField] private int damage;
        [Range(1,20)]
        [SerializeField] private int health;
        [SerializeField] private float speed;
        
        public void Init()
        {
            
        }

        public int Damage => damage;
        public int Health => health;
        public float Speed => speed;
        public ClockType Type => clockType;
    }
}