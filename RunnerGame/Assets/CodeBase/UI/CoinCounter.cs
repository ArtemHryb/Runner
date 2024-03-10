using CodeBase.Logic;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class CoinCounter : MonoBehaviour
    { 
        [SerializeField] private TMP_Text _coinsText;
        
        private int _coinsCount;

        public void Initialize() => 
            Subscribe();

        private void OnDestroy() =>
            UnSubscribe();

        private void CountPlus()
        {
            _coinsCount++;
            _coinsText.text = _coinsCount.ToString();
        }

        private void Subscribe() => 
            CoinBehaviour.OnCoinPick += CountPlus; 
        
        private void UnSubscribe() => 
            CoinBehaviour.OnCoinPick -= CountPlus;
        
    }
}