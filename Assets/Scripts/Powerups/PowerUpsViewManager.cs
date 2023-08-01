using UnityEngine;

namespace Gameplay.PowerUps
{
    public class PowerUpsViewManager : MonoBehaviour
    {
        [SerializeField] private PowerUpsView speedView;
        [SerializeField] private PowerUpsView healthView;
        [SerializeField] private PowerUpsView invincibilityView;

        private PowerUpsController _controller;

        private void Awake()
        {
            _controller = FindObjectOfType<PowerUpsController>();
            if (_controller == null) return;
            _controller.AddPickUpPowerUpEventListener(OnBeginPowerUpView);
        }

        private void OnBeginPowerUpView(PowerUpsBase powerUp)
        {
            // Which power up to begin with
            var powerUpType = powerUp.PowerUpType;

            switch (powerUpType)
            {
                case PowerUpType.Health:
                    healthView.transform.SetAsFirstSibling();
                    healthView.BeginInternal(powerUp);
                    break;
                case PowerUpType.Invincibility:
                    invincibilityView.transform.SetAsFirstSibling();
                    invincibilityView.BeginInternal(powerUp);
                    break;
                case PowerUpType.Speed:
                    speedView.transform.SetAsFirstSibling();
                    speedView.BeginInternal(powerUp);
                    break;
            }
        }
    }
}