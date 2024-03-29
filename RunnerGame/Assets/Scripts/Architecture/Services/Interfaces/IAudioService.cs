using Scripts.Audio;

namespace Scripts.Architecture.Services.Interfaces
{
    public interface IAudioService : IService
    {
        void PlayMusic(MusicType musicType);
        void PlaySfx(SfxType sfxType);
        void StopMusic();
    }
}