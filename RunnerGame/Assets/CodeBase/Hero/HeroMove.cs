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

        private void OnDestroy()
        {
            UnSubscribe();
        } 
        
        private void MoveLeft()
        {
            if (_currentLine != Line.Left)
            {
                _currentLine--;
                
                transform.DOMoveX(transform.position.x - 1f, 0.5f)
                    .SetEase(Ease.OutQuad);
                
                Debug.Log("Move Left");
            }
                
        }

        private void MoveRight()
        {
            if (_currentLine != Line.Right)
            {
                _currentLine++;

                transform.DOMoveX(transform.position.x + 1f, 0.5f)
                    .SetEase(Ease.OutQuad);
                
                Debug.Log("Move Right");
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