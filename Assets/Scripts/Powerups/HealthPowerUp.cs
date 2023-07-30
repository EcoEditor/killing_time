namespace Gameplay.PowerUps
{
    public class HealthPowerUp : PowerUpsBase
    {
        public override void Activate(Player player)
        {
            player.IncreaseHealth();
        }

        public override void Deactivate(Player player)
        {
            
        }
    }
}