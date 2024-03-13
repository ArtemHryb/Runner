using CodeBase.Audio;

namespace CodeBase.Services.Audio
{
    public interface IAudioService : IService
    {
        void PlayMusic(MusicType musicType);
        void PlaySfx(SfxType sfxType);
        void StopMusic();
    }
}