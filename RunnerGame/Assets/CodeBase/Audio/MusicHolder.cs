using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Audio
{
    [CreateAssetMenu(fileName = "MusicHolder",menuName = "Create Music Holder/Holder")]
    public class MusicHolder : ScriptableObject
    {
        public List<MusicData> Musics;
    }
}