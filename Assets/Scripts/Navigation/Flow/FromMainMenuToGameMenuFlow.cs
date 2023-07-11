using System;
using Infrastructure.Navigation;
using Infrastructure.Services;

namespace Gameplay.Flows
{
    public class FromMainMenuToGameMenuFlow : IFlow
    {
        public void Execute()
        {
            //1. load loading screen
            LoadingScreenServiceLocator.Get()
                .Then(lss =>
                {
                    lss.FadeIn();
                    lss.SetProgress(0.2f, "Onboard Mission...");
                })
                //2. await x seconds
                .Then(() => CoroutineService.Instance.Delay(2f))
                //3. unload main menu screen and load game screen
                .Then(NavigationManager.UnloadMainMenuScreenAsync)
                .Then(() => NavigationManager.LoadGameAsync())
                //4. update progression status
                .Then(() => LoadingScreenServiceLocator.Get())
                .Then(lss => lss.SetProgress(0.4f, "Calling on mission control center"))
                //5. await x seconds and update progression status
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() => LoadingScreenServiceLocator.Get())
                .Then(lss => lss.SetProgress(0.6f, "spaceship ready to launch"))
                //6. await x seconds and update progression status
                .Then(() => CoroutineService.Instance.Delay(1f))
                .Then(() => LoadingScreenServiceLocator.Get())
                .Then(lss => lss.SetProgress(1f, "Ready to start mission"))
                //7. start game
                .Then(() => CoroutineService.Instance.Delay(1f))
                //TODO public game started event
                .Then(() => LoadingScreenServiceLocator.Get())
                .Then(lss => lss.FadeOut());
        }
    }
}