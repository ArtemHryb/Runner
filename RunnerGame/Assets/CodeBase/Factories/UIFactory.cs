using CodeBase.Factories.AssetProviding;
using UnityEngine;

namespace CodeBase.Factories
{
    public class UIFactory : IUIFactory
    {
        private IAssetProvider _assetProvider;

        public UIFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void CreateMainMenu()
        {
            
        }

        public GameObject CreateBaseWindow(string path, Transform parentTransform)
        {
            Vector3 startPosition = new Vector3(0, 0, 0); //Screen.height

            GameObject window = Object.Instantiate(_assetProvider
                .Initialize<GameObject>(path),parentTransform);
            
            window.transform.localPosition = startPosition;
            return window;
        }
        public GameObject CreateBaseWindow(string path, Transform parentTransform, Vector2 anchoredPosition)
        {
            GameObject window = Object.Instantiate(_assetProvider
                .Initialize<GameObject>(path),parentTransform);
            
            window.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
            
            return window;
        }

        public GameObject CreateBaseWindow(string path)
        {
            Vector3 startPosition = new Vector3(0, 0, 0);

            GameObject window = Object.Instantiate(_assetProvider
                .Initialize<GameObject>(path));

            window.transform.localPosition = startPosition;
            return window;
        }

        public T CreateBaseWindow<T>(string path) where T : Component => 
            Object.Instantiate(_assetProvider.Initialize<T>(path));
    }
}