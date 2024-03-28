using System.Collections;
using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Hero;
using CodeBase.Services;
using TMPro;
using UnityEngine;

namespace CodeBase.Boosters
{
    public class MagnetBooster : BoosterBase
    {
        private MagnetCollider _magnetCollider;
        private TextMeshProUGUI _timerText;

        protected override void Take()
        {
            _magnetCollider.StartMagnet(_sizePlus, _duration);
        }

        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(AllTags.Player))
            {
                _magnetCollider = other.GetComponentInChildren<MagnetCollider>();
                Take();
                Destroy(gameObject);
            }
        }
    }
}