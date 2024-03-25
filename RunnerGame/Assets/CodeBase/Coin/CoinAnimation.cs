using UnityEngine;

namespace CodeBase.Coin
{
    public class CoinAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly int _spinningHash = Animator.StringToHash("Spinning");
        
        
    }
}