using System;
using UnityEngine;

namespace Gameplay.Clocks
{
    public class ClockBase : MonoBehaviour
    {
        public Action<float> ChangeClockHealth;

        #region consts
        
        private const float INITIAL_HEALTH = 100;

        #endregion
        
        [SerializeField] protected ClockModel model;
 
        private float _currentHealth;
        private float _healthPortion;
        private int _takeDamage;

        protected virtual void Awake()
        {
            _currentHealth = INITIAL_HEALTH;
            _healthPortion = _currentHealth / model.HealthPortions;
            _takeDamage = model.HealthPortions;
        }

        public void DecreaseHealth()
        {
            var currentHealth = _currentHealth - _healthPortion;
            if (currentHealth <= 0f)
            {
                Die();
                return;
            }

            _currentHealth = currentHealth;
            ChangeClockHealth?.Invoke(_currentHealth);
            Debug.Log($"clock {gameObject.name} health is {_currentHealth}");
        }
        
        // In case follower clock collides upon a health power up
        public void IncreaseHealth()
        {
            var currentHealth = _currentHealth + _healthPortion;
            if (currentHealth > INITIAL_HEALTH) return;
            _currentHealth = currentHealth;
            ChangeClockHealth?.Invoke(_currentHealth);
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}