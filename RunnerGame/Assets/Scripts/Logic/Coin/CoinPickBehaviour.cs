using DG.Tweening;
using Scripts.Architecture.Services;
using Scripts.Architecture.Services.Factories;
using Scripts.Architecture.Services.Interfaces;
using Scripts.Data;
using UnityEngine;

namespace Scripts.Logic.Coin
{
    public class CoinPickBehaviour : MonoBehaviour
    {
        private const float DestroyDelay = 0.5f;

        private ICoinService _coinService;
        private IGameFactory _gameFactory;
        private void Awake()
        {
            _coinService = AllServices.Container.Single<ICoinService>();
            _gameFactory = AllServices.Container.Single<IGameFactory>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(AllTags.Player))
            {
                _coinService.GetCoin();
                GameObject explosion = CreateDestroyEffect();
                Destroy(explosion, DestroyDelay);
                DestroyCoin();
            }

            if (other.CompareTag(AllTags.MagnetPick))
            {
                CapsuleCollider parent = other.GetComponentInParent<CapsuleCollider>();
                _coinService.GetCoin();
                transform.DOMove(parent.transform.position + new Vector3(0f, 0f, 2f), .5f)
                    .SetEase(Ease.OutBack).OnComplete(DestroyCoin);
            }
        }

        private GameObject CreateDestroyEffect() => 
            _gameFactory.CreateBaseGameObject(AssetPath.Explosion, transform.position, Quaternion.identity, null);

        private void DestroyCoin() => 
            Destroy(gameObject);
    }
}