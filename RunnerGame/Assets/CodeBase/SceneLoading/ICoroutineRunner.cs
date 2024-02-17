using System.Collections;
using UnityEngine;

namespace CodeBase.SceneLoading
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}