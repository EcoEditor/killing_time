using System.Collections;
using UnityEngine;
// nice ref: https://www.kodeco.com/191-how-to-make-a-power-up-system-in-unity

namespace Gameplay.PowerUps
{
    public abstract class PowerUpsBase : MonoBehaviour
    {
        [SerializeField] private PowerUpType powerUpType;
        [SerializeField] private Sprite icon;
        [SerializeField] protected float duration;
        [SerializeField] protected float expireTime;
        [SerializeField] protected AudioSource audioSfx;

        private Vector2 _moveDirection;
        private float _startTime;
        private bool _didPickUp;
        
        private void Update()
        {
            if (_didPickUp) return;
            var elapsedTime = Time.time - _startTime;
            if (elapsedTime >= expireTime)
            {
                Destroy(gameObject);
            }
        }

        public void StartExpireCountdown()
        {
            _startTime = Time.time;
        }

        /// <summary>
        /// Processes trigger collisions with other game objects
        /// </summary>
        /// <param name="other">information about the other collider</param>
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var player = other.gameObject.GetComponent<Player>();
                if (player == null) return;

                var puc = other.gameObject.GetComponent<PowerUpsController>();
                if (puc == null) return;
                puc.CollectPowerUp(this);

                Activate(player);
                audioSfx.Play();
                transform.position = new Vector2(100f, 100f);
                _didPickUp = true;
                // if colliding with enemy return both to 
                // their respective pools
                //ObjectPool.ReturnEnemy(other.gameObject);
                //ObjectPool.ReturnBullet(gameObject);
            }
        }

        protected abstract void Activate(Player player);

        public PowerUpType PowerUpType => powerUpType;
        public float Duration => duration;
        public Sprite Icon => icon;
    }

    public enum PowerUpType
    {
        Speed,
        Health,
        Invincibility,
    }
}