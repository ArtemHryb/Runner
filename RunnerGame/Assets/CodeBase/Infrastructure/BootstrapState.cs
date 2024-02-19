using CodeBase.SceneLoading;

namespace CodeBase.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string BootScene = "Boot";
        private const string MainScene = "Main";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            _sceneLoader.Load(BootScene, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadLevelState, string>(MainScene);

        public void Exit()
        {
            
        }
    }
}