using System.Collections;
using Infrastructure.Services;
using RSG;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Screens
{
	public class LoadingScreen : MonoBehaviour, ILoadingScreenService
	{
		#region Editor

		[SerializeField]
		private CanvasGroup _cg;

		[SerializeField]
		private float _fadeInOutDuration = 1.5f;
		
		[SerializeField]
		private AnimationCurve _alphaCurve;

		[SerializeField]
		private TMP_Text _progressDetailsText;

		[SerializeField]
		private Slider _progressSlider;
		
		#endregion

		#region Methods

		public IPromise SetProgress(float progress, string progressText)
		{
			_progressSlider.value = progress;
			_progressDetailsText.text = progressText;
			return Promise.Resolved();
		}

		public IPromise FadeIn()
		{
			var p = new Promise();
			StartCoroutine(FadeInCoroutine(_fadeInOutDuration, p));
			return p;
		}

		public IPromise FadeOut()
		{
			var p = new Promise();
			StartCoroutine(FadeOutCoroutine(_fadeInOutDuration, p));
			return p;
		}

		private IEnumerator FadeInCoroutine(float duration, IPendingPromise p)
		{
			var fadeInTime = 0f;
			while (fadeInTime < duration)
			{
				var factor = fadeInTime / duration;
				_cg.alpha = _alphaCurve.Evaluate(factor);
				fadeInTime += Time.deltaTime;
				yield return null;
			}
			p.Resolve();
		}

		private IEnumerator FadeOutCoroutine(float duration, IPendingPromise p)
		{
			var fadeOutTime = duration;
			while (fadeOutTime >= 0)
			{
				var factor = fadeOutTime / duration;
				_cg.alpha = _alphaCurve.Evaluate(factor);
				fadeOutTime -= Time.deltaTime;
				yield return null;
			}
			p.Resolve();
		}

		#endregion
	}
}