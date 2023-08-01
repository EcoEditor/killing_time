using System;
using Events;
using Gameplay.Flows;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text levelText;

        private int _currentLevel = 1;

        public void LevelUp()
        {
            _currentLevel++;
            levelText.text = _currentLevel.ToString();
        }
        
        [ContextMenu("GameWon test")]
        public void GameWon()
        {
            //TODO send game won event
            var goToWinMenu = new FromGameMenuToMainMenuFlow();
            goToWinMenu.Execute();
        }
    }
}