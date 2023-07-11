using Infrastructure.Navigation;
using Infrastructure.Services;

namespace Gameplay.Flows
{
    public class FromWinMenuToMainMenuFlow : IFlow
    {
        public void Execute()
        {
            LoadingScreenServiceLocator.Get()
                .Then(lss =>
                {
                    lss.FadeIn();
                    lss.SetProgress(0.3f, "Calling on mission control center");
                })
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() => NavigationManager.UnloadWinMenuAsync())
                .Then(() => NavigationManager.LoadMainMenuScreenAsync())
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() => LoadingScreenServiceLocator.Get())
                .Then(lss => lss.SetProgress(0.6f, "spaceship ready to land"))
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() => LoadingScreenServiceLocator.Get())
                .Then(lss => lss.SetProgress(1f, "Ready to  re-start mission"))
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() => LoadingScreenServiceLocator.Get())
                .Done(lss => lss.FadeOut());
        }
    }
}