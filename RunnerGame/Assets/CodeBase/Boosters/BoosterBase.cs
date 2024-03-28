using UnityEngine;

namespace CodeBase.Boosters
{
    public abstract class BoosterBase : MonoBehaviour
    {
        [SerializeField] protected Vector3 _sizePlus;
        [SerializeField] protected float _duration = 10f;
        
        protected abstract void Take();
    }
}