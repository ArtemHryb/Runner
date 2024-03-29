using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class PregameMenu : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _pregameText;

        [SerializeField]
        private Button _button;

        private void Awake() => 
            _button.onClick.AddListener(Click);

        private void Start() => 
            Time.timeScale = 0f;

        private void Click()
        {
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
    }
}