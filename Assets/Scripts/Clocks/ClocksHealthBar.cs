using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Clocks
{
    public class ClocksHealthBar : MonoBehaviour
    {
        [SerializeField] private Sprite[] healthBarImages;
        [SerializeField] private Image healthBarImage;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private ClockBase clock;
        [SerializeField] private float showBarDuration = 1.2f;

        private float _startTime;
        
        private void Awake()
        {
            Hide();
            clock.ChangeClockHealth += UpdateHealthBar;
        }

        private void OnDestroy()
        {
            clock.ChangeClockHealth -= UpdateHealthBar;
        }

        // Call this method whenever the clock health changes.
        private void UpdateHealthBar(float currentHealth)
        {
            Show();
            // Calculate the index of the health bar sprite based on the player's current health.
            var healthImageIndex = Mathf.RoundToInt(currentHealth / 100f * (healthBarImages.Length - 1));
            var healthImageIndexClamped = Mathf.Clamp(healthImageIndex, 0, healthBarImages.Length - 1);

            // Set the health bar sprite based on the calculated index.
            healthBarImage.sprite = healthBarImages[healthImageIndexClamped];
        }

        private void Update()
        {
            if (canvasGroup.alpha >= 1f)
            {
                var elapsedTime = Time.time - _startTime;
                if (elapsedTime >= showBarDuration)
                {
                    Hide();
                }
            }
        }

        private void Show()
        {
            _startTime = Time.time;
            canvasGroup.alpha = 1f;
        }

        private void Hide()
        {
            canvasGroup.alpha = 0f;
        }
    }
}