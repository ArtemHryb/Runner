﻿using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Audio
{
    [CreateAssetMenu(fileName = "SfxHolder", menuName = "Create Sfx Holder/Holder")]
    public class SfxHolder : ScriptableObject
    {
        public List<SfxData> SoundEffects;
    }
}