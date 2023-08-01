using System.Collections;
using UnityEngine;

namespace Gameplay.PowerUps
{
    public class InvincibilityPowerUp : PowerUpsBase
    {
        protected override void Activate(Player player)
        {
            player.RaiseArmor();
            StartCoroutine(Deactivate(player));
        }

        private IEnumerator Deactivate(Player player)
        {
            yield return new WaitForSeconds(duration);
            player.GetComponent<PowerUpsController>().RemovePowerUp(this);
            player.LowerArmor();
        }
    }
}



