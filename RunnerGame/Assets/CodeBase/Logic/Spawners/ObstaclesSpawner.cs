using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic.Spawners
{
    public class ObstaclesSpawner : LevelItemsSpawner
    {
        [SerializeField] private GameObject _obstaclePrefab;
        [SerializeField] private List<Transform> _obstaclesSpawnPoints = new();
        [SerializeField] private Transform _obstaclesContainer;

        private void Start() => 
            SpawnItems();

        public override void SpawnItems()
        {
            Vector3 position = new Vector3(0f, 0.63f, 0f);
            for (int i = 0; i < _obstaclesSpawnPoints.Count; i++)
            {
                Instantiate(_obstaclePrefab, _obstaclesSpawnPoints[i].position + position,
                    Quaternion.identity, _obstaclesContainer);
            }
        }
    }
}