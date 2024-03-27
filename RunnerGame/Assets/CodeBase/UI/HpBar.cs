using CodeBase.Hero;
using CodeBase.States;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class HpBar: MonoBehaviour
    {
        [SerializeField] 
        private Image[] _hearts;

        private int _currentHp;
        private int _maxHp = 5;
        private IGameStateMachine _stateMachine;

        public void Initialize(IGameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        private void Start()
        {
            Subscribe();
            _currentHp = _maxHp;
        }
        private void OnDestroy() => 
            UnSubscribe();

        private void TakeDamage()
        {
            _currentHp -= 1;
            
            
            if (_currentHp == 0)
                Death();
            
            
            UpdateHearts();
        }

        private void Death() => 
            _stateMachine.Enter<GameOverState>();

        private void UpdateHearts()
        {
            for (int i = 0; i < _hearts.Length; i++)
            {
                if (i < _currentHp)
                    _hearts[i].enabled = true;
                else
                    _hearts[i].enabled = false;
            }
        }

        private void Subscribe() => 
            HeroHealth.HealthDamaged += TakeDamage;

        private void UnSubscribe() => 
            HeroHealth.HealthDamaged -= TakeDamage;
    }
}