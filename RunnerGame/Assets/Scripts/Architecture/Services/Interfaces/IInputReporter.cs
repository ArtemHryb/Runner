using System;

namespace Scripts.Architecture.Services.Interfaces
{
    public interface IInputReporter
    {
        event Action OnSwipeLeft;
        event Action OnSwipeRight;
        event Action OnSwipeUp;
    }
}