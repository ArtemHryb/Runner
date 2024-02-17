using CodeBase.Infrastructure;
using CodeBase.Services.Input;
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

        private IInputService _inputService;

        private void Awake() => 
            _inputService = Game.InputService;

        private void Start()
        {
            _inputService.OnSwipeRight += MoveRight;
            _inputService.OnSwipeLeft += MoveLeft;
        } 
        private void Update()
        {
            Vector3 movementVector = Vector3.forward;
            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }

        private void OnDestroy()
        {
            _inputService.OnSwipeRight -= MoveRight;
            _inputService.OnSwipeLeft -= MoveLeft;
        } 
        private void MoveLeft()
        {
            if (_currentLine != Line.Left)
                transform.DOMoveX(transform.position.x - 1f, 0.5f)
                    .SetEase(Ease.OutQuad).OnComplete(() => _currentLine --);
        }

        private void MoveRight()
        {
            if(_currentLine != Line.Right)
                transform.DOMoveX(transform.position.x + 1f, 0.5f)
                    .SetEase(Ease.OutQuad).OnComplete(() => _currentLine ++);
        }
    }
}