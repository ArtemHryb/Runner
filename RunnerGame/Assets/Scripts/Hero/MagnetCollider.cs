using System.Collections;
using Scripts.Architecture.Services;
using Scripts.Architecture.Services.Factories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Hero
{
    public class MagnetCollider : MonoBehaviour
    {
        private readonly Vector3 _boxColliderCenter = new (0f, 0.5f, 2f);
        [SerializeField] private BoxCollider _boxCollider;
        private TextMeshProUGUI _timerText;
        private IUIFactory _uiFactory;
        private bool _isTimerActive;

        public void StartMagnet(Vector3 sizePlus,float duration)
        {
            _uiFactory = AllServices.Container.Single<IUIFactory>();
            ActivateTimerView();
            StartCoroutine(Magnet(sizePlus, duration));
            StartTimer(duration);
        }
        private IEnumerator Timer(float duration)
        {
            _isTimerActive = true;
            _timerText.text = duration.ToString("0" + "s");
            while (duration > 0f)
            {
                yield return new WaitForSeconds(1f);
                duration -= 1;
                _timerText.text = duration.ToString("0" + "s");
            }

            _isTimerActive = false;
            GameObject magnetTimer = _timerText.GetComponentInParent<Image>().gameObject;
            magnetTimer.SetActive(false);
        }
        private IEnumerator Magnet(Vector3 sizePlus, float duration)
        {
            UpScaleCollider(sizePlus);
            yield return new WaitForSeconds(duration);
            DownScaleCollider();
        }

        private void StartTimer(float duration)
        {
            if (!_isTimerActive) 
                StartCoroutine(Timer(duration));
            else
                return;
        }
        private void ActivateTimerView()
        {
            if (_uiFactory.MagnetTracker.gameObject.activeSelf == true)
                return;
            _uiFactory.MagnetTracker.gameObject.SetActive(true);
            _timerText = _uiFactory.MagnetTracker.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }

        private void DownScaleCollider()
        {
            _boxCollider.size = Vector3.zero;
            _boxCollider.center = Vector3.zero;
        }

        private void UpScaleCollider(Vector3 sizePlus)
        {
            _boxCollider.center = _boxColliderCenter;
            _boxCollider.size = sizePlus;
        }
    }
}