using System.Collections;
using UnityEngine;

namespace Scripts.Architecture.Services.Interfaces
{
    public interface ICoroutineRunner : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}