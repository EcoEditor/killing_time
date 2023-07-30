using System;
using System.Collections;
using Events;
using UnityEngine;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        #region Events

        public Action<float> ChangePlayerHealth;
        private GameLostEvent _gameLostEvent = new GameLostEvent();

        #endregion
        
        #region consts
        
        private const float INITIAL_HEALTH = 100;
        // Must be the same amount as health bar sprites
        private const int HEALTH_PORTIONS = 21;
        
        #endregion
        
        [SerializeField] private float movementSpeed;
        [SerializeField] private AnimationCurve bounceBackCurve;
        [SerializeField] private float bounceDuration = 1f;

        [Header("Player Audio")] 
        [SerializeField] private AudioClip playerHitAudio;
        [SerializeField] private AudioClip playerDeathAudio;
        [SerializeField] private AudioSource playerAudioSource;
        
        private float _currentHealth;
        private float _healthPortion;
        private float _speed;

        private void Awake()
        {
            _currentHealth = INITIAL_HEALTH;
            _healthPortion = _currentHealth / HEALTH_PORTIONS;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                IncreaseHealth();
            }
        }

        [ContextMenu("Increase health")]
        public void IncreaseHealth()
        {
            var currentHealth = _currentHealth + _healthPortion;
            if (currentHealth > INITIAL_HEALTH) return;
            UpdateCurrentHealth(currentHealth);
        }

        public void DecreaseHealth()
        {
            var currentHealth = _currentHealth - _healthPortion;
            if (currentHealth <= 0f)
            {
                Die();
                return;
            }

            playerAudioSource.clip = playerHitAudio;
            playerAudioSource.Play();
            UpdateCurrentHealth(currentHealth);
        }

        private void UpdateCurrentHealth(float currentHealth)
        {
            _currentHealth = currentHealth;
            ChangePlayerHealth?.Invoke(_currentHealth);
            Debug.Log($"currentHealth {_currentHealth}");
        }
        
        public void ApplySpeedBoost(float multiplier)
        {
            _speed = multiplier * movementSpeed;
        }

        public void ResetSpeed()
        {
            _speed = movementSpeed;
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
            var initialPosition = (Vector2)transform.position;
            var endPosition = initialPosition + direction;

            while (elapsedTime < 1)
            {
                elapsedTime = (Time.time - startTime) / bounceDuration;
                var bounceFactor = bounceBackCurve.Evaluate(elapsedTime);
                transform.position = Vector3.Lerp(initialPosition, endPosition, bounceFactor);
                yield return null;
            }
            
            DecreaseHealth();
        }

        private void Die()
        {
            _gameLostEvent?.Invoke();
            playerAudioSource.clip = playerDeathAudio;
            playerAudioSource.Play();
        }
        
        #region Properties

        public float MaxHealth => INITIAL_HEALTH;
        public float MovementSpeed => _speed;

        #endregion
    }
}