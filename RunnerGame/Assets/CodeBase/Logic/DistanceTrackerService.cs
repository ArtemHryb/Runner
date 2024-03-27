using System.Collections;
using CodeBase.Factories;
using CodeBase.SceneLoading;
using TMPro;
using UnityEngine;

namespace CodeBase.Logic
{
    public class DistanceTrackerService : IDistanceTrackerService
    {
        private float _multiplier = 3;

        public float Distance { get; private set; }
        private TMP_Text _text;
        private readonly IUIFactory _uiFactory;
        private MyCoroutineRunner _coroutineRunner;
        
        public DistanceTrackerService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void StartTracking()
        {;
            _text = _uiFactory.DistanceTracker.GetComponentInChildren<TMP_Text>();
            MyCoroutineRunner runner = _uiFactory.CoroutineRunner;
            runner.StartCoroutine(MyUpdate());
        }

        public void Reset() => 
            Distance = 0;

        IEnumerator MyUpdate()
        {
            while (Application.isPlaying)
            {
                Distance += _multiplier * Time.deltaTime;
                _text.text = Distance.ToString("0.0" + "m");

                yield return 1;
            }
        }
    }
}