using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class Follow : MonoBehaviour
    {
        [SerializeField] float chaseRange = 5f;

        public bool InRangeOfPlayer(GameObject other)
        {
            return DistanceToObject(other) <= chaseRange;
        }

        public void FollowTarget(GameObject other, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
        }

        public float DistanceToObject(GameObject other)
        {
            if (other == null) { return 0; }
            else
            { return Vector3.Distance(transform.position, other.transform.position); }
        }

        public float GetChaseRange()
        {
            return chaseRange;
        }

        //Called by Unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }
    }
}
