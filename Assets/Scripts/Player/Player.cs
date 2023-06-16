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
        public void BounceBack(Vector2 direction, int damage)
        {
            StartCoroutine(BounceRoutine(direction, damage));
        }

        private IEnumerator BounceRoutine(Vector2 direction, int damage)
        {
            var startTime = Time.time;
            var elapsedTime = 0f;
            var initialPosition = transform.position;
            var oppositeDirection = direction * -1;

            while (elapsedTime < 1)
            {
                elapsedTime = (Time.time - startTime) / bounceDuration;
                var bounceFactor = bounceBackCurve.Evaluate(elapsedTime);
                transform.position = Vector3.Lerp(initialPosition, oppositeDirection * -1f, bounceFactor);
                yield return null;
            }
            
            DecreaseHealth(damage);
        }
    }
}
