using UnityEngine;

namespace Gameplay
{
    public class ShootingLineIndicator : MonoBehaviour
    {
        [SerializeField] private Animator indicatorsAnimator;
        [SerializeField] private float fadeDelay = 0.1f;

        private bool _isShowing = true;
        private void Awake()
        {

        }

        public void Show()
        {
            
        }

        [ContextMenu("stop")]
        public void Hide()
        {
        }
    }
}