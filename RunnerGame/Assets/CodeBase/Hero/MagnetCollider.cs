using System.Collections;
using CodeBase.Factories;
using CodeBase.Services;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Hero
{
    public class MagnetCollider : MonoBehaviour
    {
        private readonly Vector3 _boxColliderCenter = new (0f, 0.5f, 2f);
        [SerializeField] private BoxCollider _boxCollider;
        private TextMeshProUGUI _timerText;
        private IUIFactory _uiFactory;

        public void StartMagnet(Vector3 sizePlus,float duration)
        {
            _uiFactory = AllServices.Container.Single<IUIFactory>();
            _uiFactory.CreateMagnetTracker();
            _timerText = _uiFactory.MagnetTracker.gameObject.GetComponentInChildren<TextMeshProUGUI>();
            StartCoroutine(Magnet(sizePlus, duration));
            StartCoroutine(Timer(duration));
        }
        private IEnumerator Timer(float duration)
        {
            _timerText.text = duration.ToString("0" + "s");
            while (duration > 0f)
            {
                yield return new WaitForSeconds(1f);
                duration -= 1;
                _timerText.text = duration.ToString("0" + "s");
            }

            GameObject timer = _timerText.GetComponentInParent<Image>().gameObject;
            Destroy(timer);
        }
        private IEnumerator Magnet(Vector3 sizePlus, float duration)
        {
            UpScaleCollider(sizePlus);
            yield return new WaitForSeconds(duration);
            DownScaleCollider(sizePlus);
        }

        private void DownScaleCollider(Vector3 sizePlus)
        {
            _boxCollider.size -= sizePlus;
            _boxCollider.center -= _boxColliderCenter;
        }

        private void UpScaleCollider(Vector3 sizePlus)
        {
            _boxCollider.center += _boxColliderCenter;
            _boxCollider.size += sizePlus;
        }
    }
}