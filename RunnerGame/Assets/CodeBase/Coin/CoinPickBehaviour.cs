using CodeBase.Data;
using CodeBase.Services;
using CodeBase.Services.CoinService;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Coin
{
    public class CoinPickBehaviour : MonoBehaviour
    {
        private const float DestroyDelay = 0.5f;
        [SerializeField] private GameObject _fx;

        private ICoinService _coinService;
        private void Awake() =>
            _coinService = AllServices.Container.Single<ICoinService>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(AllTags.Player))
            {
                _coinService.GetCoin();
                GameObject fx = Instantiate(_fx, transform.position, Quaternion.identity);
                Destroy(fx, DestroyDelay);
                Destroy(gameObject);
            }

            if (other.CompareTag(AllTags.MagnetPick))
            {
                CapsuleCollider collider = other.GetComponentInParent<CapsuleCollider>();
                _coinService.GetCoin();
                transform.DOMove(collider.transform.position + new Vector3(0f, 0f, 2f), .5f)
                    .SetEase(Ease.OutBack).OnComplete(DestroyCoin);
            }
        }

        private void DestroyCoin()
        {
            Destroy(gameObject);
        }
    }
}