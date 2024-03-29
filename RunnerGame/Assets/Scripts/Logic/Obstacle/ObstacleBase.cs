using Scripts.Architecture.Services;
using Scripts.Architecture.Services.Interfaces;
using UnityEngine;

namespace Scripts.Logic.Obstacle
{
    public abstract class ObstacleBase : MonoBehaviour
    {
        protected IAudioService _audioService;
        private void Awake() => _audioService = AllServices.Container.Single<IAudioService>();
        protected abstract void OnTriggerEnter(Collider other);
    }
}