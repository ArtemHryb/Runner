using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Logic
{
    public class CoinSpawner : MonoBehaviour
    { 
        [SerializeField] private GameObject _coinPrefab;
        
        [SerializeField] private List<Transform> _coinsSpawnPoints = new();
        
        private int _density = 8;

       private void Start()
        {
            SpawnCoins(_density);
        }
       

        private void SpawnCoins(int count)
        {
            Vector3 startPosition = new Vector3(0f, 0.7f, 0f);
            Vector3 spacing = new Vector3(0f, 0f, 1f);
            
            
                
                Vector3 currentPosition = startPosition;
                
                for (int i = 0; i < count; i++)
                {
                    int spawnIndex = RandomCount();
                    GameObject coin = Instantiate(_coinPrefab, _coinsSpawnPoints[spawnIndex].position + currentPosition,
                        Quaternion.Euler(-90f,0f,0f), null);
                    currentPosition += spacing;
                }
        }

        private int RandomCount() => 
            Random.Range(0, _coinsSpawnPoints.Count);
    }
}