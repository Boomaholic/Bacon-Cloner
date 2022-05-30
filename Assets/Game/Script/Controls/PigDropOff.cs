using System.Collections;
using System.Collections.Generic;
using Movement;
using Core;
using UnityEngine;

namespace Control
{
    public class PigDropOff : MonoBehaviour
    {
        GameManager gameManager;

        [Header("Editor")]
        [SerializeField] BoxCollider boxCollider;


        private void Awake()
        {
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        }

        private void OnTriggerStay(Collider other)
        {
            
            //do nothing if player enters
            if (other.CompareTag("Player"))
            { return; }

            //check if piggie entered, and piggie is following Player
            if (other.CompareTag("Piggie") &&
                other.GetComponent<Follow>().InRangeOfPlayer(GameObject.FindWithTag("Player")))
            {
                gameManager.OnPigDropOffTrigger();

                //Added Audio trigger
                AudioManager.instance.CloningSFX();

                Destroy(other.gameObject);
            }
        }

        //Called by Unity
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, boxCollider.size);
        }
    }
}