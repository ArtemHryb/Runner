using System;
using CodeBase.Factories;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Services.GameInput
{
    public class InputReporter : MonoBehaviour, IPointerDownHandler,
        IPointerUpHandler, IInputReporter
    {
        private const int MaxAngle = 180;

        private const float SwipeResist = 0.7f;

        private const int RightSwipeMinAngle = -45;
        private const int RightSwipeMaxAngle = 45;

        private const int UpSwipeMaxAngle = 135;
        private const int LeftSwipeMaxAngle = -135;
        
        public event Action OnSwipeLeft;
        public event Action OnSwipeRight;
        public event Action OnSwipeUp;

        private Vector2 _startTouchPosition;
        private Vector2 _endTouchPosition;

        private float _swipeAngle;

        private Camera _camera;
        private IGameFactory _gameFactory;

        private void Start() => 
            _camera = AllServices.Container.Single<IGameFactory>().Camera;

        public void OnPointerDown(PointerEventData eventData) => 
            _startTouchPosition = _camera.ScreenToWorldPoint(eventData.position);

        public void OnPointerUp(PointerEventData eventData)
        {
            _endTouchPosition = _camera.ScreenToWorldPoint(eventData.position);
            CalculateAngle();
        }

        private void CalculateAngle()
        {
            if (Mathf.Abs(_endTouchPosition.y - _startTouchPosition.y) > SwipeResist ||
                Mathf.Abs(_endTouchPosition.x - _startTouchPosition.x) > SwipeResist)
            {
                _swipeAngle = Mathf.Atan2(_endTouchPosition.y - _startTouchPosition.y,
                    _endTouchPosition.x - _startTouchPosition.x) * MaxAngle / Mathf.PI;
                
                GetSwipeDirection();
            }
        }

        private void GetSwipeDirection()
        {
            if (_swipeAngle > RightSwipeMinAngle && _swipeAngle <= RightSwipeMaxAngle)
            {
                OnSwipeRight?.Invoke();
            }
            else if (_swipeAngle > RightSwipeMaxAngle && _swipeAngle <= UpSwipeMaxAngle)
            {
                OnSwipeUp?.Invoke();
            }
            else if (_swipeAngle > UpSwipeMaxAngle || _swipeAngle <= LeftSwipeMaxAngle)
            {
                OnSwipeLeft?.Invoke();
            }
            else if (_swipeAngle < RightSwipeMinAngle && _swipeAngle >= LeftSwipeMaxAngle)
            {
//Down
            }
        }
    }
}