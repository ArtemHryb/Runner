using Scripts.Architecture.Services;
using Scripts.Architecture.Services.Interfaces;
using TMPro;
using UnityEngine;

namespace Scripts.UI
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

        private void Start() => UpdateText();

        private void OnDestroy() => 
            _coinService.OnCoinPick -= UpdateText;

        private void UpdateText() => 
            _coinText.text = _coinService.Count.ToString();
    }
}