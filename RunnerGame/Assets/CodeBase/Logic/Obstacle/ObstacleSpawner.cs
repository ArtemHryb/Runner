using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Logic.Obstacle
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private ObstacleSpawnPoint[] _obstacleSpawnPoint;
        [SerializeField] private Transform _obstaclesContainer;
        
        private readonly Vector3 _vasePosition = new (0f, 0.24f, 0f);
        private readonly Vector3 _lockGatePosition = new (0f, 1f, 0f);
        private readonly Vector3 _jumpGatePosition = new (0f, 1f, 0f);

        private IGameFactory _gameFactory;
        
        private void Awake() => _gameFactory = AllServices.Container.Single<IGameFactory>(); 
        
        private void Start() => Spawn();

        private void Spawn()
        {
            foreach (ObstacleSpawnPoint obstacle in _obstacleSpawnPoint)
            {
                switch (obstacle.ObstacleType)
                {
                    case ObstacleType.Vase:
                        CreateVase(obstacle);
                        break;
                    case ObstacleType.LockGate:
                        CreateLockGate(obstacle);
                        break;
                    case ObstacleType.JumpGate:
                        CreateJumpGate(obstacle);
                        break;
                }
            }
        }

        private void CreateLockGate(ObstacleSpawnPoint obstacle) =>
            _gameFactory.CreateBaseGameObject(AssetPath.LockGate, obstacle.transform.position + _lockGatePosition,
                Quaternion.identity, _obstaclesContainer);
        
        private void CreateJumpGate(ObstacleSpawnPoint obstacle) =>
            _gameFactory.CreateBaseGameObject(AssetPath.JumpGate, obstacle.transform.position + _jumpGatePosition,
                Quaternion.identity, _obstaclesContainer);

        private void CreateVase(ObstacleSpawnPoint obstacle) =>
            _gameFactory.CreateBaseGameObject(AssetPath.Vase,obstacle.transform.position + _vasePosition,
                Quaternion.identity,_obstaclesContainer);
    }
}