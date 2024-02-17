using UnityEngine;

namespace CodeBase.Services.Input
{
    public class MobileInput : InputService
    {
        private Vector2 _firstTouchPosition;
        private Vector2 _lastTouchPosition; 
        
        private void Update()
        {
          if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began)
              RememberFirstPosition();

          if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Ended)
          {
              RememberLastPosition();

              if (_lastTouchPosition.x < _firstTouchPosition.x) 
                  InvokeLeftSwipe();

              if (_lastTouchPosition.x > _firstTouchPosition.x) 
                  InvokeRightSwipe();
          }
        }

        private void RememberLastPosition() =>
            _lastTouchPosition = UnityEngine.Input.GetTouch(0).position;

        private void RememberFirstPosition() => 
            _firstTouchPosition = UnityEngine.Input.GetTouch(0).position;
    }
}