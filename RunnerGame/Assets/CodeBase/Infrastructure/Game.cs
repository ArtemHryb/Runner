using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game
    { 
        public static IInputService InputService;

        public Game()
        {
            Debug.Log("Game constructor called.");
            RegisterInput();
        }

        private static void RegisterInput()
        { 
            InputService = new MobileInput();
            Debug.Log("InputService registered: " + InputService);
        }
    }
}