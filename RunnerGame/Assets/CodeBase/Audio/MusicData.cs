using System;
using UnityEngine;

namespace CodeBase.Audio
{
    [Serializable]
    public class MusicData
    {
        [SerializeField] private MusicType _musicType;
        [SerializeField] private AudioClip _audioClip;

        public MusicType MusicType => _musicType;
        public AudioClip Clip => _audioClip;
    }
}