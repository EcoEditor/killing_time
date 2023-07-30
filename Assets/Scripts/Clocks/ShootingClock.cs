using UnityEngine;

namespace Gameplay.Clocks
{
    public class ShootingClock : ClockBase
    {
        [SerializeField] private float shootingInterval = 0.4f;
        [SerializeField] private Bullet bulletRef;
        [SerializeField] private float launchedVelocity;

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
                ShootPlayer();
                _startTime = Time.time;
            }
        }

        private void ShootPlayer()
        {
            Vector2 direction = new Vector2(
                _target.transform.position.x - transform.position.x,
                _target.transform.position.y - transform.position.y);
            direction.Normalize();

            var bulletObj = Instantiate(bulletRef, transform.position, transform.rotation);
            bulletObj.TempIgnoreCollider();
            bulletObj.StartMoving(direction);
        }

        private void HandleGameLostEvent(GameObject go)
        {
            // stop shooting player
        }
    }
}
