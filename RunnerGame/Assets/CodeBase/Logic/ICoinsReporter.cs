using System;

namespace CodeBase.Logic
{
    public interface ICoinsReporter
    {
        event Action OnCoinPick;
    }
}