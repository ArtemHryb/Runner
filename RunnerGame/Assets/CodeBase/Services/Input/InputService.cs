using System;

namespace CodeBase.Services.Input
{
    public class InputService : IInputService
    {
        public event Action OnSwipeLeft;
        public event Action OnSwipeRight;
        
        protected void InvokeLeftSwipe() => 
            OnSwipeLeft?.Invoke();

        protected void InvokeRightSwipe() => 
            OnSwipeRight?.Invoke();
    }
}