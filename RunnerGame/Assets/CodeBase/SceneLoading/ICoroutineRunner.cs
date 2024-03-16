using System.Collections;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.SceneLoading
{
    public interface ICoroutineRunner : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}