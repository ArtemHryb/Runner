using UnityEngine;

namespace CodeBase.Hero
{
    public class DistanceTracker : MonoBehaviour
    {
        private Vector3 lastPosition;
        private float totalDistance;

        void Start()
        {
            lastPosition = transform.position;
        }

        void Update()
        {
            float distanceMoved = Vector3.Distance(transform.position, lastPosition);
        
            totalDistance += distanceMoved;

            lastPosition = transform.position;

            Debug.Log("Total Distance: " + totalDistance);
        }
    }
}