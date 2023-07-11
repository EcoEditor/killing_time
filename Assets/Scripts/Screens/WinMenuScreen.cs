using Gameplay.Flows;
using UnityEngine;
using UnityEngine.UI;

namespace Production.Scripts.Gameplay.Screens
{
    public class WinMenuScreen : MonoBehaviour
    {
        #region Editor

        [SerializeField] 
        private Button _replayButton;

        #endregion

        #region Methods

        protected void Awake()
        {
            _replayButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            var goToGameMenu = new FromWinMenuToMainMenuFlow();
            goToGameMenu.Execute();
        }

        #endregion
    }
}