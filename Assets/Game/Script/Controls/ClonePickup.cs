using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Control {
    public class ClonePickup : MonoBehaviour
    {
        GameObject player;
        GameManager gameManager;

        [Header("Editor")]
        [SerializeField] BoxCollider boxCollider;
        



        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        }

        private void OnTriggerStay(Collider other)
        {
            //check if player
            if (other.CompareTag("Player"))
            {
                //starts wait timer
                gameManager.StartWaitTimer();

                //if clones waiting > 0 Add CloneFollower for each clone waiting
                if (gameManager.GetClonesWaitingForPickup() > 0 && gameManager.PickupTimeWaited())
                {
                    player.GetComponent<CloneFollower>().AddFollowers();
                    gameManager.OnClonePickupTrigger();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                gameManager.ResetWaitTimer();
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