using CodeBase.Services;
using CodeBase.Services.CoinService;
using UnityEngine;

namespace CodeBase.Coin
{
    public class CoinPickBehaviour : MonoBehaviour
    {
        [SerializeField] private int _pickBonus = 1;

        private ICoinService _coinService;

        private void Awake() => 
            _coinService = AllServices.Container.Single<ICoinService>();

        private void OnTriggerEnter(Collider other)
        {
            _coinService.GetCoin(_pickBonus);
            Destroy(gameObject);
        }
    }
}