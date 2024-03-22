using CodeBase.Services.GameInput;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMove : MonoBehaviour
    {
        private const int Spacing = 1;
        private const float Duration = 0.5f;
        
        [SerializeField] private HeroAnimation _heroAnimation;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed = 2f;

        [SerializeField] private LayerMask _layerMask;
        
        private bool _isGrounded = false;
        private float _rayDistance = 0.1f;

        private readonly float _nextPos = 3f;
        private readonly float _jumpPower = 1.5f;
        private readonly int _numJumps = 1;
        private readonly float _duration = 0.7f;

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

            GroundCheck();
        }

        private void OnDestroy() => 
        UnSubscribe();

        private void Jump()
        {
            if (_isGrounded)
            {
                _heroAnimation.PlayJump();
                Vector3 nestPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _nextPos);
                transform.DOJump(nestPosition, _jumpPower, _numJumps, _duration);
            }
        }

        private void MoveLeft()
        {
            if (_currentLine != Line.Left)
            {
                _currentLine--;
                float targetX = transform.localPosition.x - Spacing;
                transform.DOLocalMoveX(Mathf.RoundToInt(targetX), Duration)
                    .SetEase(Ease.OutQuad);
            }
        }

        private void MoveRight()
        {
            if (_currentLine != Line.Right)
            {
                _currentLine++;
                float targetX = transform.localPosition.x + Spacing;
                transform.DOLocalMoveX(Mathf.RoundToInt(targetX), Duration)
                    .SetEase(Ease.OutQuad);
            }
        }

        private void Subscribe()
        {
            _inputReporter.OnSwipeRight += MoveRight;
            _inputReporter.OnSwipeLeft += MoveLeft;
            _inputReporter.OnSwipeUp += Jump;
        }

        private void UnSubscribe()
        {
            _inputReporter.OnSwipeRight -= MoveRight;
            _inputReporter.OnSwipeLeft -= MoveLeft;
            _inputReporter.OnSwipeUp -= Jump;

        }

        private void GroundCheck()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, _rayDistance, _layerMask))
                _isGrounded = true;
            else
                _isGrounded = false;
        }
    }
}