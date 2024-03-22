using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroAnimation : MonoBehaviour
    {
        private readonly int _runHash = Animator.StringToHash("Run");
        private readonly int _jumpHash = Animator.StringToHash("Jump");
        private readonly int _dieHash = Animator.StringToHash("Die");
        private readonly int _hitHash = Animator.StringToHash("Hit");
        
       [SerializeField] private Animator _animator;

       public void PlayRun() => _animator.SetTrigger(_runHash);
       public void PlayDeath() => _animator.SetTrigger(_dieHash);
       public void PlayJump() => _animator.SetTrigger(_jumpHash);

        private void Start() => PlayRun();
    } 
}