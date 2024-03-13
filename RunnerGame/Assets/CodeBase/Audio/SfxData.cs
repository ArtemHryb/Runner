using System;
using UnityEngine;

namespace CodeBase.Audio
{
    [Serializable]
    public class SfxData
    {
        [SerializeField] private SfxType _sfxType;
        [SerializeField] private AudioClip _audioClip;

        public SfxType SfxType => _sfxType;
        public AudioClip Clip => _audioClip;
    }
}