using System;
using CodeBase.Services;
using CodeBase.Services.CoinService;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinText;

        private ICoinService _coinService;

        private void Awake()
        {
            _coinService = AllServices.Container.Single<ICoinService>();
            _coinService.OnCoinPick += UpdateText;
        }

        public void Initialize(ICoinService coinService)
        {
            _coinService = coinService;
            _coinService.OnCoinPick += UpdateText;
        }

        // private void OnEnable() => 
        //     _coinService.OnCoinPick += UpdateText;
        // private void OnDisable() => 
        //     _coinService.OnCoinPick -= UpdateText;
        private void OnDestroy() => 
            _coinService.OnCoinPick -= UpdateText;

        private void UpdateText() => 
            _coinText.text = _coinService.Count.ToString();
    }
}