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
        
        private void HandleGameLostEvent(GameObject go)
        {
            // stop shooting player
        }

        protected override void Die()
        {
            var randomPowerUpIndex = Random.Range(0, powerUps.Length);
            var powerUpPrefab = powerUps[randomPowerUpIndex];
            var powerUp = Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            powerUp.StartExpireCountdown();
            base.Die();
        }
    }
}

