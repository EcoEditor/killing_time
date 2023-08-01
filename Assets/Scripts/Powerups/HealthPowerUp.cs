namespace Gameplay.PowerUps
{
    public class HealthPowerUp : PowerUpsBase
    {
        protected override void Activate(Player player)
        {
            player.IncreaseHealth();
        }
    }
}