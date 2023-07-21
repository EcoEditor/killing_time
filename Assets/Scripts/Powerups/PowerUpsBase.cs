using UnityEngine;

namespace Gameplay.PowerUps
{
    public class PowerUpsBase : MonoBehaviour
    {
        [SerializeField] private int value;
        [SerializeField] private Sprite icon;
        [SerializeField] private float duration;

        public int Value => value;
    }
}