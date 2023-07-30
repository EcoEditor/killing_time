using Gameplay.PowerUps;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Clocks
{
    public class MysteryClock : ClockBase
    {
        [SerializeField] private PowerUpsBase[] powerUps;
        [SerializeField] private float shootingInterval = 5f;

        private Player _target;
        private float _startTime;
        
        protected override void Awake()
        {
            base.Awake();
            _target = FindObjectOfType<Player>();
            _startTime = Time.time;
            EventManager.AddListener(HandleGameLostEvent);
        }
        
        private void Update()
        {
            var elapsedTime = Time.time - _startTime;
                if (elapsedTime >= shootingInterval)
            {
                //ShootPlayer();
                _startTime = Time.time;
            }
        }
            
        private void ShootPlayer()
        {
            // Generate a random angle in degrees.
            var randomAngle = Random.Range(0f, 360f);

            // Convert the angle to a vector in 2D space.
            var randomDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
            randomDirection.Normalize();

            // Get the rotation of the power up based on the random direction:
            var powerUpRotation = Quaternion.LookRotation(Vector3.forward, randomDirection);

            var randomPowerUpIndex = Random.Range(0, powerUps.Length);
            var powerUpPrefab = powerUps[0];
            Instantiate(powerUpPrefab, transform.position, powerUpRotation);
        }
        
        private void HandleGameLostEvent(GameObject go)
        {
            // stop shooting player
        }

        protected override void Die()
        {
            var randomPowerUpIndex = Random.Range(0, powerUps.Length);
            var powerUpPrefab = powerUps[randomPowerUpIndex];
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            base.Die();
        }
    }
}

