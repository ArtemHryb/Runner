using Scripts.Data;
using Scripts.Hero;
using Scripts.Logic.CameraLogic;
using UnityEngine;

namespace Scripts.Architecture.Services.Factories
{
    public class GameFactory : IGameFactory
    {
        public Transform Hero { get; private set; }
        public Camera Camera { get; private set; }

        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public void CreateGameObjects()
        {
            CreateDirectionalLight();
            CreateUICamera();
            CreateHero();
            InitializeInput();
            CreateGameCamera();
            CreateGeometry();
        }

        private void CreateDirectionalLight()
        {
            CreateBaseGameObject(AssetPath.DirectionalLight, new Vector3(0f,3f,0f),
                Quaternion.Euler(new Vector3(30f, 0f, 0f)),
                null);
        }

        private void CreateHero()
        { 
            HeroMove hero = CreateBaseGameObject<HeroMove>(AssetPath.Hero);
            Hero = hero.transform;
        }

        private void InitializeInput()
        {
            InputReporter input = Object.FindObjectOfType<InputReporter>();
            Hero.GetComponent<HeroMove>().Initialize(input);
        }

        private void CreateGeometry() => 
            CreateBaseGameObject(AssetPath.Geometry, Vector3.zero, Quaternion.identity, null);

        private void CreateGameCamera()
        {
            GameObject camera = CreateBaseGameObject(AssetPath.GameCamera, Vector3.zero,
                Quaternion.identity, null);
            camera.GetComponent<CameraFollow>().Follow(Hero);
        }
        private void CreateUICamera() =>
            Camera = _assetProvider.Initialize<Camera>(AssetPath.UICamera);
        public GameObject CreateBaseGameObject(string path, Vector3 at, Quaternion rotation, Transform parent) => 
            Object.Instantiate(_assetProvider.Initialize<GameObject>(path), at, rotation, parent);

        public T CreateBaseGameObject<T>(string path) where T : Component =>
            Object.Instantiate(_assetProvider.Initialize<T>(path));
    }
}