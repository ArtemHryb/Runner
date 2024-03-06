using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic.Spawners
{
    public class CoinSpawner : LevelItemsSpawner
    {
        [SerializeField] private GameObject _coinPrefab;

        [SerializeField] private List<Transform> _coinsSpawnPoints;

        [SerializeField] private Transform _coinsContainer;

        private void Start() => 
            SpawnItems();

        public override void SpawnItems()
        {
            Vector3 startPosition = new Vector3(0f, 0.5f, 0f);
            Vector3 spacing = new Vector3(0f, 0f, 0.5f);
                
            Vector3 currentPosition = startPosition;
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < _coinsSpawnPoints.Count; i++)
                {
                    Instantiate(_coinPrefab, _coinsSpawnPoints[i].position + currentPosition,
                        Quaternion.Euler(-90f,0f,0f), _coinsContainer);
                    
                    currentPosition += spacing;
                }
            }
        }
    }
}