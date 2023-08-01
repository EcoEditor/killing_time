using System;
using System.Linq;
using RSG;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Infrastructure.Services
{
	public static class LoadingScreenServiceLocator
	{
		private const int LOADING_SCREEN_BUILD_ID = 3;
		
		private static ILoadingScreenService _service;
		
		public static IPromise<ILoadingScreenService> Get()
		{
			if (_service != null)
			{
				return Promise<ILoadingScreenService>.Resolved(_service);
			}

			var p = new Promise<ILoadingScreenService>();
			
			var loadOperation = SceneManager.LoadSceneAsync(LOADING_SCREEN_BUILD_ID, LoadSceneMode.Additive);
			loadOperation.completed += o =>
			{
				var service = Object.FindObjectsOfType<MonoBehaviour>().OfType<ILoadingScreenService>().FirstOrDefault();
				if (service == null)
				{
					throw new Exception("Can't load Loading Screen Service");
				}

				_service = service;
				p.Resolve(_service);
			};
			return p;
		}
	}
}