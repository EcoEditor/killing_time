using System;
using UnityEngine;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        private const int INITIAL_HEALTH = 100;
        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = INITIAL_HEALTH;
        }

        public void IncreaseHealth(int amount)
        {
            _currentHealth += amount;
        }

        public void DecreaseHealth(int amount)
        {
            _currentHealth -= amount;
        }

        private void Update()
        {

        }
    }
}
