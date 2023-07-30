using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.PowerUps
{
    public abstract class PowerUpsBase : MonoBehaviour
    {
        [SerializeField] private PowerUpType powerUpType;
        [SerializeField] private int value;
        [SerializeField] private Sprite icon;
        [SerializeField] protected float duration;
        [SerializeField] protected AudioSource audioSfx;

        private Vector2 _moveDirection;
        
        private void Start()
        {
            // Calculate the move direction based on the projectile's initial rotation.
            //_moveDirection = transform.right.normalized;
        }
        
        private void Update()
        {
            // Move the projectile in the direction of moveDirection.
            //transform.position += (Vector3)_moveDirection * movementSpeed * Time.deltaTime;
        }
        
        /// <summary>
        /// Processes trigger collisions with other game objects
        /// </summary>
        /// <param name="other">information about the other collider</param>
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var puc = other.gameObject.GetComponent<PowerUpsController>();
                if (puc == null) return;
                puc.CollectPowerUp(this);
                audioSfx.Play();
                Destroy(gameObject);

                // if colliding with enemy return both to 
                // their respective pools
                //ObjectPool.ReturnEnemy(other.gameObject);
                //ObjectPool.ReturnBullet(gameObject);
            }
        }

        public virtual void Activate(Player player)
        {
            
        }

        public virtual void Deactivate(Player player)
        {
            
        }

        public int Value => value;
        public Sprite Icon => icon;
        public float Duration => duration;
        public PowerUpType PowerUpType => powerUpType;
    }

    public enum PowerUpType
    {
        Speed,
        Health,
        Invincibility,
    }
}