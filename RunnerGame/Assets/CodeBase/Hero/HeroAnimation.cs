using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroAnimation : MonoBehaviour
    {
        private static readonly int RunHash = Animator.StringToHash("Run");
        private static readonly int JumpHash = Animator.StringToHash("Jump");
        private static readonly int DieHash = Animator.StringToHash("Die");
        
       [SerializeField] private Animator _animator;

       private void PlayRun() => _animator.SetTrigger(RunHash);
       private void PlayDeath() => _animator.SetTrigger(DieHash);
       private void PlayJump() => _animator.SetTrigger(JumpHash);

        private void Start()
        {
            PlayRun();
        }
    } 
}