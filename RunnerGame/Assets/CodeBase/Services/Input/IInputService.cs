using System;

namespace CodeBase.Services.Input
{
    public interface IInputService
    {
        event Action OnSwipeLeft;
        event Action OnSwipeRight;
    }
}