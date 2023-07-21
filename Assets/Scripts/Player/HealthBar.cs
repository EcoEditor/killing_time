using Gameplay;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Sprite[] healthBarImages;
    [SerializeField] private Image healthBarImage;

    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _player.ChangePlayerHealth += UpdateHealthBar;
    }

    private void OnDestroy()
    {
        if (_player != null)
        {
            _player.ChangePlayerHealth -= UpdateHealthBar;
        }
    }
    
    // Call this method whenever the player is shot or their health changes.
    private void UpdateHealthBar(float currentHealth)
    {
        // Calculate the index of the health bar sprite based on the player's current health.
        var healthImageIndex = Mathf.RoundToInt(currentHealth / _player.MaxHealth * (healthBarImages.Length - 1));
        var healthImageIndexClamped = Mathf.Clamp(healthImageIndex, 0, healthBarImages.Length - 1);

        // Set the health bar sprite based on the calculated index.
        healthBarImage.sprite = healthBarImages[healthImageIndexClamped];
    }
}