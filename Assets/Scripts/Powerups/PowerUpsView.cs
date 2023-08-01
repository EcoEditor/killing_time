using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.PowerUps
{
    public class PowerUpsView : MonoBehaviour
    {
        [SerializeField] private Image imageView;

        private void Awake()
        {
            imageView.fillAmount = 0f;
        }

        public void BeginInternal(PowerUpsBase powerUpsBase)
        {
            if (powerUpsBase is InvincibilityPowerUp)
            {
                //StopAllCoroutines();
                imageView.sprite = powerUpsBase.Icon;
            }
            
            imageView.fillAmount = 1f;
            StartCoroutine(CountDownRoutine(powerUpsBase.Duration));
        }
        
        private IEnumerator CountDownRoutine(float duration)
        {
            var startTime = Time.time;
            var elapsedTime = 0f;

            while (elapsedTime < 1f)
            {
                elapsedTime = (Time.time - startTime) / duration;
                imageView.fillAmount = Mathf.Lerp(1f, 0f, elapsedTime);
                yield return null;
            }
            
            Debug.Log("Power up is hidden");
        }
    }
}