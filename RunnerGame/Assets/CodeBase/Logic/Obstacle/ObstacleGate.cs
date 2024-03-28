using CodeBase.Audio;
using CodeBase.Data;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Logic.Obstacle
{
    public class ObstacleGate : ObstacleBase
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(AllTags.Player))
            {
                other.GetComponent<HeroHealth>().TakeDamage();
                _audioService.PlaySfx(SfxType.BrokeGate);
                Destroy(gameObject);
            }
            
        }
    }
}