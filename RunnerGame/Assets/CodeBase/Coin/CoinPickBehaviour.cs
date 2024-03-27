using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Services;
using CodeBase.Services.CoinService;
using UnityEngine;

namespace CodeBase.Coin
{
    public class CoinPickBehaviour : MonoBehaviour
    {
        private const float DestroyDelay = 0.5f;
        [SerializeField] private GameObject _fx;

        private ICoinService _coinService;
        private IGameFactory _gameFactory;

        private void Awake() => 
            _coinService = AllServices.Container.Single<ICoinService>();

        private void OnTriggerEnter(Collider other)
        {
            _coinService.GetCoin();
           GameObject fx = Instantiate(_fx, transform.position, Quaternion.identity);
           Destroy(fx, DestroyDelay);
           Destroy(gameObject);
        }
    }
}