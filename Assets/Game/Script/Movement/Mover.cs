using System.Collections;
using UnityEngine;

namespace Movement
{
    public class Mover : MonoBehaviour
    {
        public void FollowPlayer(GameObject other, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
        }
    }
}