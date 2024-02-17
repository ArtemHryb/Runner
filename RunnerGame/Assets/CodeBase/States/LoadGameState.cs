using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Hero;
using CodeBase.SceneLoading;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.States
{
    public class LoadGameState
    {
        private const string GameScene = "Main";
        
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IBaseFactory _baseFactory;

        public LoadGameState(ICoroutineRunner coroutineRunner, IBaseFactory baseFactory)
        {
            _coroutineRunner = coroutineRunner;
            _baseFactory = baseFactory;
        }
        
        public void Enter()
        {
            ISceneLoader sceneLoader = new SceneLoader(_coroutineRunner);
            
            sceneLoader.Load(GameScene, CreateScene);    
        }

        private void CreateScene()
        {
            _baseFactory.CreateBaseGameObject(AssetPath.GameCamera, new Vector3
                (0.35f, 8.14f, -1.57f), Quaternion.Euler(new Vector3(30, -1.5f, 0)), null);
            
            Camera uiCamera = _baseFactory.CreateBaseGameObject(AssetPath.UICamera, 
                Vector3.zero, Quaternion.identity, null).GetComponent<Camera>();
            
            HeroMove hero = _baseFactory.CreateBaseGameObject(AssetPath.Hero,new Vector3
                (0, 0.3f, 3), Quaternion.identity, null).GetComponent<HeroMove>();
            
            GameView gameView = _baseFactory.CreateBaseGameObject(AssetPath.GameView,
                new Vector3(0, 0.3f, 3), Quaternion.identity, null).GetComponent<GameView>();

            gameView.InputReporter.Initialize(uiCamera);
            
            hero.Initialize(gameView.InputReporter);
        }
    }
}
