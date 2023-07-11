using Gameplay.Flows;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Screens
{
    public class MainMenuScreen : MonoBehaviour
    {
        #region Editor

        [SerializeField] 
        private Button _startButton;

        #endregion

        #region Methods

        protected void Awake()
        {
            _startButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _startButton.interactable = false;
            
            var goToGameMenu = new FromMainMenuToGameMenuFlow();
            goToGameMenu.Execute();
        }

        #endregion
    }
}