using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Logic.Spawners
{
    public class ChunkSpawner : MonoBehaviour
    {
        [SerializeField] private Chunk[] _chunkPrefab;
        [SerializeField] private Chunk _firstChunk;
        
        private Transform _player;
        private List<Chunk> _spawnedChunks = new();

        private int _distanceToSpawn = 30;

        public void Initialize(Transform player)
        {
            _spawnedChunks.Add(_firstChunk);
            _player = player;
        }

        private void Update()
        {
            if (ReadyToSpawn()) 
                SpawnChunk();
        }

        private bool ReadyToSpawn() => 
            _player.position.z > _spawnedChunks[_spawnedChunks.Count - 1].End.position.z - _distanceToSpawn;

        private void SpawnChunk()
        {
            Chunk newChunk = Instantiate(_chunkPrefab[Random.Range(0, _chunkPrefab.Length)],Vector3.zero, Quaternion.identity,transform);
            
            newChunk.transform.position = 
                _spawnedChunks[_spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
            
            _spawnedChunks.Add(newChunk);

            if (_spawnedChunks.Count >=3)
            {
                Destroy(_spawnedChunks[0].gameObject);
                _spawnedChunks.RemoveAt(0);
            }
        }
    }
}