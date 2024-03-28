using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Logic.Spawners
{
    public class MagnetSpawner : LevelItemsSpawner
    {
        [SerializeField] private Transform _magnetsSpawnPoint;

        [SerializeField] private Transform _magnetsContainer;

        private IGameFactory _gameFactory;

        private void Awake() => 
            _gameFactory = AllServices.Container.Single<IGameFactory>();

        private void Start() => 
            SpawnItems();

        public override void SpawnItems()
        {
            Vector3 startPosition = new Vector3(0f, 0.5f, 0f);
            _gameFactory.CreateBaseGameObject(AssetPath.Magnet,_magnetsSpawnPoint.position + startPosition,
                Quaternion.identity,_magnetsContainer );
        }
    }
}