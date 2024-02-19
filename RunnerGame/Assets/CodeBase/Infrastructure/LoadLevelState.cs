using CodeBase.Data;
using CodeBase.Hero;
using CodeBase.SceneLoading;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        private void OnLoaded()
        { 
            GameObject initialPoint = GameObject.FindWithTag(InitialPointTag);
            
            Instantiate(AssetPath.GameCamera);
            Camera uiCamera =  Instantiate(AssetPath.UICamera).GetComponent<Camera>();
            HeroMove hero = Instantiate(AssetPath.Hero,at: initialPoint.transform.position).GetComponent<HeroMove>();
            GameView gameView = Instantiate(AssetPath.GameView).GetComponent<GameView>();
           
            gameView.InputReporter.Initialize(uiCamera);
            hero.Initialize(gameView.InputReporter);
            
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab,at,Quaternion.identity);
        }
        
        
        public void Exit()
        {
            
        }
    }
}