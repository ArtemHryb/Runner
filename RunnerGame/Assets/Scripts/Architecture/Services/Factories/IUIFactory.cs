using Scripts.Architecture.Services.Interfaces;
using Scripts.UI.MainMenu;
using UnityEngine;

namespace Scripts.Architecture.Services.Factories
{
    public interface IUIFactory : IService
    {
        MyCoroutineRunner CoroutineRunner { get; }
        Transform DistanceTracker { get; }
        Transform MagnetTracker { get; }
        Transform CoinView { get; }
        Transform HpBar { get; }
        Transform HudRoot { get; }
        MainMenuController CreateMainMenu();
        void CreateInGameHud();
        void CreateMagnetTracker();
        Transform CreateUIWindow(string path, Transform parentTransform);
        Transform CreateUIWindow(string path);
        
        T CreateBaseWindow<T>(string path) where T : Component ;
    }
}