using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.PowerUps
{
    public class PowerUpsController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer iconRenderer;
        [SerializeField] private Player player;
        
        private List<PowerUpsBase> _activePowerUps;

        public void CollectPowerUp(PowerUpsBase powerUp)
        {
            // Check if the player already has the same power-up type
            var existingPowerUp = _activePowerUps.Find(p => p.PowerUpType == powerUp.PowerUpType);

            if (existingPowerUp != null)
            {
                // If the power-up is already active, reset its duration or refresh it
                existingPowerUp.Deactivate(player);
            }
            else
            {
                // If the power-up is new, activate it
                powerUp.Activate(player);
                _activePowerUps.Add(powerUp);
            }
        }
        
        public void RemovePowerUp(PowerUpsBase powerUp)
        {
            _activePowerUps.Remove(powerUp);
        }
        
        public void Initialize(PowerUpsBase pu)
        {
            iconRenderer.sprite = pu.Icon;

            if (pu is HealthPowerUp)
            {
                player.IncreaseHealth();
            } else if (pu is SpeedPowerUp)
            {
                //player.SetPlayerSpeed();
            }
        }

        public void Hide()
        {
            iconRenderer.sprite = null;
        }
    }
}