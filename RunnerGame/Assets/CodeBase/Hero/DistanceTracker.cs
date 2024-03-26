using System;
using CodeBase.Factories;
using TMPro;
using UnityEngine;

namespace CodeBase.Hero
{
    public class DistanceTracker : MonoBehaviour
    {
        private Vector3 _lastPosition;
        private float _totalDistance;
        [SerializeField] private TMP_Text _distanceText;
        private IUIFactory _uiFactory;


        private void Awake()
        {
            //_distanceText = _uiFactory.
        }

        void Start()
        {
            _lastPosition = transform.position;
            //PrintDistance();
        }

        void Update()
        {
            float distance = CalculateDistance();
            _totalDistance += distance;
            _lastPosition = transform.position;
        }

        // private void PrintDistance() => 
        //     _distanceText.text = _totalDistance.ToString();
        private float CalculateDistance() => 
            Vector3.Distance(transform.position, _lastPosition);
    }
}