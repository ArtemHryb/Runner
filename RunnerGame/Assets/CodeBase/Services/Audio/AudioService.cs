using System.Collections.Generic;
using CodeBase.Audio;
using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Factories.AssetProviding;
using UnityEngine;

namespace CodeBase.Services.Audio
{
    public class AudioService : IAudioService
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IGameFactory _gameFactory;

        private readonly List<SfxData> _sfxDataList = new();
        private readonly List<MusicData> _musicDataList = new();

        private AudioSource _sfxAudioSource;
        private AudioSource _musicAudioSource;

        public AudioService(IAssetProvider assetProvider, IGameFactory gameFactory)
        {
            _assetProvider = assetProvider;
            _gameFactory = gameFactory;
            
            InitializeAudioListener();
            InitializeMusicDataList();
            InitializeSfxDataList();
            InitializeMusicAudioSource();
            InitializeSfxAudioSource();
        }
        
        public void PlayMusic(MusicType musicType)
        {
            MusicData musicData = GetMusicData(musicType);
            _musicAudioSource.clip = musicData.Clip;
            _musicAudioSource.Play();
        }

        public void PlaySfx(SfxType sfxType)
        {
            SfxData sfxData = GetSfxData(sfxType);
            _sfxAudioSource.PlayOneShot(sfxData.Clip);
        }

        public void StopMusic() => 
            _musicAudioSource.Stop();

        private MusicData GetMusicData(MusicType musicType)
        {
            MusicData result = _musicDataList.Find(data => data.MusicType == musicType);
            return result;
        }
        
        private SfxData GetSfxData(SfxType sfxType)
        {
            SfxData result = _sfxDataList.Find(data => data.SfxType == sfxType);
            return result;
        }

        private void InitializeSfxDataList()
        {
            SfxHolder sfxHolder = _assetProvider.Initialize<SfxHolder>(AssetPath.SfxHolder);

            foreach (SfxData sfx in sfxHolder.SoundEffects) 
                _sfxDataList.Add(sfx);
        }

        private void InitializeMusicDataList()
        {
            MusicHolder musicHolder = _assetProvider.Initialize<MusicHolder>(AssetPath.MusicHolder);
            
            foreach (MusicData music in musicHolder.Musics) 
                _musicDataList.Add(music);
        }

        private void InitializeSfxAudioSource()
        {
            _sfxAudioSource = _gameFactory.CreateBaseGameObject<AudioSource>(AssetPath.SfxAudioSource);
            Object.DontDestroyOnLoad(_sfxAudioSource);
        }


        private void InitializeMusicAudioSource()
        {
            _musicAudioSource = _gameFactory.CreateBaseGameObject<AudioSource>(AssetPath.MusicAudioSource);
            Object.DontDestroyOnLoad(_musicAudioSource);
        }

        private void InitializeAudioListener()
        {
            AudioListener audioListener = _gameFactory.CreateBaseGameObject<AudioListener>(AssetPath.AudioListener);
            Object.DontDestroyOnLoad(audioListener);
        }
    }
}