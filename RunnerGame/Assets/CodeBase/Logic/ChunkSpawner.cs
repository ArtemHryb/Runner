using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Logic
{
    public class ChunkSpawner : MonoBehaviour
    {
        [SerializeField] private Chunk[] _chunkPrefab;
        [SerializeField] private Chunk _firstChunk;
        
        private Transform _player;

        private List<Chunk> _spawnedChunks = new();

        public void Initialize(Transform player) => 
            _player = player;

        private void Start()
        {
            _spawnedChunks.Add(_firstChunk);
        }

        private void Update()
        {
            if (_player.position.z > _spawnedChunks[_spawnedChunks.Count - 1].End.position.z)
            {
                SpawnChunk();
            }
        }

        private void SpawnChunk()
        {
            Chunk newChunk = Instantiate(_chunkPrefab[Random.Range(0, _chunkPrefab.Length)]);
            newChunk.transform.position =
                _spawnedChunks[_spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
            _spawnedChunks.Add(newChunk);

            if (_spawnedChunks.Count >=2)
            {
                Destroy(_spawnedChunks[0].gameObject);
                _spawnedChunks.RemoveAt(0);
            }
        }
    }
}