using UnityEngine;

namespace Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player model;
        private bool _isShooting;
        public bool Shooting => _isShooting;
        
        private void Update()
        {
            
        }
    }
}