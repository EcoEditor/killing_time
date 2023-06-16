using UnityEngine;

namespace Gameplay.Clocks
{
    public class ShootingClock : MonoBehaviour
    {
        [SerializeField] private ClockModel model;
        [SerializeField] private float shootingInterval = 0.4f;
        [SerializeField] private GameObject bullet;
        [SerializeField] private float launchedVelocity;

        private Player _target;
        private float _startTime;

        private void Awake()
        {
            _target = FindObjectOfType<Player>();
            _startTime = Time.time;
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

            transform.Rotate(direction, Space.Self);  
            
            var bulletObj = Instantiate(bullet, transform.position, transform.rotation);
            bulletObj.GetComponent<Rigidbody2D>().AddForce(direction * transform.up);
        }
    }
}
