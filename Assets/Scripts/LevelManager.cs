using System;
using Gameplay.Flows;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelManager : MonoBehaviour
    {
        
        [ContextMenu("GameWon test")]
        public void GameWon()
        {
            //TODO send game won event
            var goToWinMenu = new FromGameMenuToMainMenuFlow();
            goToWinMenu.Execute();
        }
    }
}