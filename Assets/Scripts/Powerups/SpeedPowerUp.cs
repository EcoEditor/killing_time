using System.Collections;
using UnityEngine;

namespace Gameplay.PowerUps
{
    public class SpeedPowerUp : PowerUpsBase
    {
        [SerializeField] private float speedMultiplier = 2f;
        
        protected override void Activate(Player player)
        {
            player.ApplySpeedBoost(speedMultiplier);
            StartCoroutine(Deactivate(player));
        }

        private IEnumerator Deactivate(Player player)
        {
            yield return new WaitForSeconds(duration);
            player.GetComponent<PowerUpsController>().RemovePowerUp(this);
            player.ResetSpeed();
        }
    }
}