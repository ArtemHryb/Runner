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
        private readonly Vector3 _gatePosition = new (0f, 1f, 0f);

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
                        CreateGate(obstacle);
                        break;
                }
            }
        }

        private void CreateGate(ObstacleSpawnPoint obstacle) =>
            _gameFactory.CreateBaseGameObject(AssetPath.LockGate, obstacle.transform.position + _gatePosition,
                Quaternion.identity, _obstaclesContainer);

        private void CreateVase(ObstacleSpawnPoint obstacle) =>
            _gameFactory.CreateBaseGameObject(AssetPath.Vase,obstacle.transform.position + _vasePosition,
                Quaternion.identity,_obstaclesContainer);
    }
}