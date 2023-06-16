using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        private const int INITIAL_HEALTH = 100;
        
        [SerializeField] private AnimationCurve bounceBackCurve;
        [SerializeField] private float bounceDuration = 1f;
        
        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = INITIAL_HEALTH;
        }

        public void IncreaseHealth(int amount)
        {
            _currentHealth += amount;
        }

        public void DecreaseHealth(int amount)
        {
            _currentHealth -= amount;
        }

        // What happens to the player when it been hit by the Follower clock
        public void BounceBack(Vector2 direction)
        {
            StartCoroutine(BounceRoutine(direction));
        }

        private IEnumerator BounceRoutine(Vector2 direction)
        {
            var startTime = Time.time;
            var elapsedTime = 0f;

            while (elapsedTime < bounceDuration)
            {
                //elapsedTime = 
            }
        }
    }
}
