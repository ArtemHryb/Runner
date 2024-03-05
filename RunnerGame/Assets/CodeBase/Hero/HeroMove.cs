using CodeBase.Services.GameInput;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed = 2f;

        private const int spacing = 1;
        private const float duration = 0.5f;
        
        private Line _currentLine = Line.Middle;

        private IInputReporter _inputReporter;
        
        

        public void Initialize(IInputReporter inputReporter)
        {
            _inputReporter = inputReporter;

            Subscribe();
        }
        private void Update()
        {
            Vector3 movementVector = Vector3.forward;

            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }

        private void OnDestroy() => 
            UnSubscribe();

        private void MoveLeft()
        {
            if (_currentLine != Line.Left)
            {
                _currentLine--;
                float targetX = transform.localPosition.x - spacing;

                transform.DOLocalMoveX(Mathf.RoundToInt(targetX), duration)
                    .SetEase(Ease.OutQuad);
            }
        }

        private void MoveRight()
        {
            if (_currentLine != Line.Right)
            {
                _currentLine++;
                float targetX = transform.localPosition.x + spacing;
                
                transform.DOLocalMoveX(Mathf.RoundToInt(targetX), duration)
                    .SetEase(Ease.OutQuad);
            }
        }

        private void Subscribe()
        {
            _inputReporter.OnSwipeRight += MoveRight;
            _inputReporter.OnSwipeLeft += MoveLeft;
        }

        private void UnSubscribe()
        {
            _inputReporter.OnSwipeRight -= MoveRight;
            _inputReporter.OnSwipeLeft -= MoveLeft;
        }
    }
}