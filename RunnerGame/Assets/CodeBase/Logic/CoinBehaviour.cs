using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class CoinBehaviour : MonoBehaviour
    {
        public static event Action OnCoinPick;
        private const string PlayerTag = "Player";
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTag))
            {
                OnCoinPick?.Invoke();
                Destroy(gameObject);
            }
                
        }
    }
}