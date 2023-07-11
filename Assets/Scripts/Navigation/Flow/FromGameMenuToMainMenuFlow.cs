using Infrastructure.Navigation;
using Infrastructure.Services;

namespace Gameplay.Flows
{
    public class FromGameMenuToMainMenuFlow : IFlow
    {
        public void Execute()
        {
            //1. load loading screen
            LoadingScreenServiceLocator.Get()
                .Then(lss =>
                {
                     lss.FadeIn();
                     lss.SetProgress(0.5f, "YOU WIN!!!");
                })
                //2. await x seconds
                .Then(() => CoroutineService.Instance.Delay(1f))
                //3. unload game menu screen and load win menu
                .Then(()=> NavigationManager.UnloadGameAsync())
                .Then(() => NavigationManager.LoadMainMenuScreenAsync())
                //4. await x seconds and update progression status
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() => LoadingScreenServiceLocator.Get())
                .Then(lss => lss.SetProgress(1f, "COMING HOME!!!"))
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() => LoadingScreenServiceLocator.Get())
                .Done(lss => lss.FadeOut());
        }
    }
}