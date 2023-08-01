using Events;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.PowerUps
{
    public class PowerUpsController : MonoBehaviour
    {
        private PickPowerUpEvent _pickUpEvent = new PickPowerUpEvent();
        private ReleasePowerUpEvent _releasePowerUpEvent = new ReleasePowerUpEvent();

        public void CollectPowerUp(PowerUpsBase powerUp)
        {
            _pickUpEvent?.Invoke(powerUp);
        }
        
        public void RemovePowerUp(PowerUpsBase powerUp)
        {
            _releasePowerUpEvent?.Invoke(powerUp);
        }
        
        /// <summary>
        /// Adds the given event handler as a listener
        /// </summary>
        /// <param name="handler">the event handler</param>
        public void AddPickUpPowerUpEventListener(UnityAction<PowerUpsBase> handler)
        {
            _pickUpEvent.AddListener(handler);
        }
        
        public void AddReleasePowerUpEventListener(UnityAction<PowerUpsBase> handler)
        {
            _pickUpEvent.AddListener(handler);
        }
    }
}