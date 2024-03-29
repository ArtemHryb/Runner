using System;
using UnityEngine;

namespace Scripts.Hero
{
    public class HeroHealth : MonoBehaviour
    {
        public static event Action HealthDamaged;

        public void TakeDamage() => 
            HealthDamaged?.Invoke();
    }
}