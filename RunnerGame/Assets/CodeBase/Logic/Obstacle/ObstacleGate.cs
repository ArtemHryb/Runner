using CodeBase.Audio;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Logic.Obstacle
{
    public class ObstacleGate : ObstacleBase
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTag))
            {
                other.GetComponent<HeroHealth>().TakeDamage();
                _audioService.PlaySfx(SfxType.BrokeGate);
            }
            Destroy(gameObject);
        }
    }
}