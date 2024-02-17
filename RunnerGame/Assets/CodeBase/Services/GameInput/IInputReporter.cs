using System;

namespace CodeBase.Services.GameInput
{
    public interface IInputReporter
    {
        event Action OnSwipeLeft;
        event Action OnSwipeRight;
    }
}