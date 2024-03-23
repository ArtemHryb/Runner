﻿using CodeBase.Services;
using CodeBase.Services.Audio;
using UnityEngine;

namespace CodeBase.Logic.Obstacle
{
    public abstract class ObstacleBase : MonoBehaviour
    {
        protected IAudioService _audioService;
        protected const string PlayerTag = "Player";
        private void Awake() => _audioService = AllServices.Container.Single<IAudioService>();
        protected abstract void OnTriggerEnter(Collider other);
    }
}