using CodeBase.Services;
using CodeBase.UI.MainMenu;
using UnityEngine;

namespace CodeBase.Factories
{
    public interface IUIFactory : IService
    {
        Transform HudRoot { get; }
        MainMenuController CreateMainMenu();
        void CreateInGameHud();
        //GameObject CreateBaseWindow(string path, Transform parentTransform, Vector2 anchoredPosition);
        //GameObject CreateBaseWindow(string path, Transform parentTransform);
        Transform CreateUIWindow(string path, Transform parentTransform);
        Transform CreateUIWindow(string path);
        
        T CreateBaseWindow<T>(string path) where T : Component ;
    }
}