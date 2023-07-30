using UnityEngine;

namespace Gameplay.PowerUps
{
    public class SpeedPowerUp : PowerUpsBase
    {
        [SerializeField] private float speedMultiplier = 2f;
        public override void Activate(Player player)
        {
            player.ApplySpeedBoost(speedMultiplier);
        }

        public override void Deactivate(Player player)
        {
            player.ResetSpeed();
        }
        public float SpeedMultiplier => speedMultiplier;
    }
}