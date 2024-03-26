using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Services;
using CodeBase.Services.CoinService;
using UnityEngine;

namespace CodeBase.Coin
{
    public class CoinPickBehaviour : MonoBehaviour
    {
        [SerializeField] private int _pickBonus = 1;
        [SerializeField] private GameObject _fx;

        private readonly float _destroyDelay = 0.5f;
        private ICoinService _coinService;
        private IGameFactory _gameFactory;

        private void Awake() => 
            _coinService = AllServices.Container.Single<ICoinService>();

        private void OnTriggerEnter(Collider other)
        {
            _coinService.GetCoin(_pickBonus);
           GameObject fx = Instantiate(_fx, transform.position, Quaternion.identity);
           Destroy(fx, _destroyDelay);
           Destroy(gameObject);
        }
    }
}