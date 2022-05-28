using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Movement;
using System;

namespace Control {
    public class HungryAF : MonoBehaviour
    {

        private GameObject baconClone;
        private GameObject baconBeingAte;
        private GameObject player;
        private GameManager gameManager;
        private Follow follow;
        [SerializeField] private float moveSpeed = 1;
        [SerializeField] private float baconAte = 0;
        [SerializeField] private float eatWaitTime = 1;
        [SerializeField] private float eatTimer = 0;



        private bool isEating = false;

        private void Awake()
        {
            Debug.Log("mmmmm Bacon");
            player = GameObject.FindWithTag("Player");
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            follow = GetComponent<Follow>();
        }


        private void Update()
        {

            //if not eating, constantly get Last Clone in Followers.
            //and Follow that Game Object
            if (!isEating)
            {
                baconClone = player.GetComponent<CloneFollower>().GetLastClone();
                FollowPlayer();
            }
            //if eating, stop and eat
            if (isEating)
            {
                StopAndEat();
            }
        }

        //following the Last Clone
        private void FollowPlayer()
        {
            transform.LookAt(baconClone.transform.position);
            follow.FollowTarget(baconClone, moveSpeed);
        }

        //start time taken to eat timer
        //gets faster more bacon ate
        //calls Method to lower Follower Array
        private void StopAndEat()
        {
            //changes baconclone to different variable so it doesnt get Overwritten
            eatTimer += Time.deltaTime;
            baconBeingAte = baconClone;

            //if eat time reached
            if (eatTimer >= eatWaitTime)
            {
                player.GetComponent<CloneFollower>().DestroyFollowers(baconBeingAte);
                baconAte++;
                moveSpeed = moveSpeed * (baconAte / moveSpeed) + Time.deltaTime;
                eatTimer = 0;
                isEating = false;
                gameManager.DecreaseClonesFollowing();
            }

        }

        //collision trigger if run into player!
        private void OnTriggerEnter(Collider other)
        {
            if (other == null) { return; }
            if (other.gameObject == baconClone)
            {
                isEating = true;
            }
        }
    }
}
