using UnityEngine;

namespace Gameplay.PowerUps
{
    public class PowerUpsBase : MonoBehaviour
    {
        [SerializeField] private int value;

        public int Value => value;
    }
}