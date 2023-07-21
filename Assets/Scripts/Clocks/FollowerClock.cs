using UnityEngine;

namespace Gameplay.Clocks
{
    public class FollowingClock : MonoBehaviour
    {
        private const int INITIAL_HEALTH = 100;
        [SerializeField] private ClockModel model;

        private int _currentHealth;
        private Rigidbody2D _rb2d;
        private Player _target;
        private float _startTime;

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _startTime = Time.time;
            _target = FindObjectOfType<Player>();

            _currentHealth = INITIAL_HEALTH;
        }

        private void Update()
        {
            FollowPlayer();
        }

        private void FollowPlayer()
        {
            // calculate direction to target pickup and start moving toward it
            Vector2 direction = new Vector2(
                _target.transform.position.x - transform.position.x,
                _target.transform.position.y - transform.position.y);
            direction.Normalize();
            _rb2d.velocity = Vector2.zero;
            float impulseForce = model.Speed;
            _rb2d.AddForce(direction * impulseForce, 
                ForceMode2D.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>())
            {
                var direction = new Vector2(
                    _target.transform.position.x - transform.position.x,
                    _target.transform.position.y - transform.position.y);
                
                direction.Normalize();

                Debug.Log("direction from the follower clock" + direction);
                _target.BounceBack(direction);
            }
        }

        public void TakeDamage()
        {
            
        }
    }
}


