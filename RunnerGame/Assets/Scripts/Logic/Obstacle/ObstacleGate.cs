using Scripts.Audio;
using Scripts.Data;
using Scripts.Hero;
using UnityEngine;

namespace Scripts.Logic.Obstacle
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