using CodeBase.Factories.AssetProviding;
using UnityEngine;

namespace CodeBase.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateBaseGameObject(string path, Vector3 at, Quaternion rotation, Transform parent) => 
            Object.Instantiate(_assetProvider.Initialize<GameObject>(path), at, rotation, parent);

        public T CreateBaseGameObject<T>(string path) where T : Component =>
            Object.Instantiate(_assetProvider.Initialize<T>(path));
    }
}
       
        

        
        
        // public GameObject CreateHero(GameObject at) => 
        //     Instantiate(AssetPath.Hero,at: at.transform.position);
        //
        // public void CreateGameCamera() => 
        //     Instantiate(AssetPath.GameCamera);
        //
        // public GameObject CreateUICamera() => 
        //     Instantiate(AssetPath.UICamera);
        //
        // public GameObject CreateGameView() =>
        //     _assetProvider.Initialize<GameObject>(AssetPath.GameView);

        // private static GameObject Instantiate(string path)

        // {

        //     var prefab = Resources.Load<GameObject>(path);

        //     return Object.Instantiate(prefab);

        // }

        //

        // private static GameObject Instantiate(string path, Vector3 at)

        // {

        //     var prefab = Resources.Load<GameObject>(path);

        //     return Object.Instantiate(prefab,at,Quaternion.identity);

        // }
