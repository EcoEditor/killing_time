using RSG;

namespace Infrastructure.Services
{
	public interface ILoadingScreenService
	{
		IPromise FadeIn();
		
		IPromise FadeOut();

		IPromise SetProgress(float progress, string progressText);
	}
}