﻿using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Logic
{
    public class ObstaclesBehaviour : MonoBehaviour
    {
        private const string PlayerTag = "Player";

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTag))
            {
                other.GetComponent<HeroHealth>().TakeDamage();
            }
        }
    }
}