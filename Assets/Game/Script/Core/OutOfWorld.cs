using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    public class OutOfWorld : MonoBehaviour
    {
        Spawner spawner;

        private void Awake()
        {
            spawner = GetComponent<Spawner>();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == GameObject.FindWithTag("Enemy"))
            {
                spawner.EnemyHasSpawned(false);
            }
            if (other.gameObject)
            {
                Destroy(other.gameObject);
            }
        }
    }
}

