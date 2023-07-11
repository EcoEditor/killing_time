using RSG;
using UnityEngine.SceneManagement;

namespace Infrastructure.Navigation
{
	public static class NavigationManager
	{
		#region Consts

		private const int MAIN_MENU_SCREEN_BUILD_ID = 1;

		private const int GAME_SCREEN_BUILD_ID = 2;
		
		private const int WIN_SCREEN_BUILD_ID = 3;
		
		#endregion
		
		#region Methods

		private static IPromise LoadSceneAsync(int sceneIndex)
		{
			var p = new Promise();
			var loadOperation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
			loadOperation.completed += operation =>
			{
				p.Resolve();
			};
			return p;
		}
		
		private static IPromise UnloadSceneAsync(int sceneIndex)
		{
			var p = new Promise();
			var unloadOperation = SceneManager.UnloadSceneAsync(sceneIndex);
			unloadOperation.completed += operation =>
			{
				p.Resolve();
			};
			return p;
		}

		public static IPromise LoadMainMenuScreenAsync()
		{
			return LoadSceneAsync(MAIN_MENU_SCREEN_BUILD_ID);
		}

		public static IPromise UnloadMainMenuScreenAsync()
		{
			return UnloadSceneAsync(MAIN_MENU_SCREEN_BUILD_ID);
		}

		public static IPromise LoadGameAsync()
		{
			return LoadSceneAsync(GAME_SCREEN_BUILD_ID);
		}

		public static IPromise UnloadGameAsync()
		{
			return UnloadSceneAsync(GAME_SCREEN_BUILD_ID);
		}		
		
		public static IPromise LoadWinMenuAsync()
		{
			return LoadSceneAsync(WIN_SCREEN_BUILD_ID);
		}

		public static IPromise UnloadWinMenuAsync()
		{
			return UnloadSceneAsync(WIN_SCREEN_BUILD_ID);
		}

		#endregion
	}
}