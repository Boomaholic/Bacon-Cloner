using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [Header("Spawner Settings")]
        [SerializeField] int piggieSpawnedCount = 0;
        [SerializeField] int piggieSpawnMax = 15;
        [SerializeField] float piggieRespawnDelay = 4f;
        [SerializeField] float timeSinceLastSpawn = 4f;

        [Header("Pig Dropoff")]
        [SerializeField] int piggiesEntered = 0;
        [SerializeField] int piggieToCloneRatio = 3;
        
        [Header("Clone Processing Settings")]
        [SerializeField] float processingDuration = 5f;
        float processingTimer = 0f;

        [Header("Clone Pickup Settings")]
        [SerializeField] int clonesBeingMade = 0;
        [SerializeField] int clonesWaitingForPickup= 0;
        float pickupWaitTimer = 0f;
        [SerializeField] float pickupTimeWaited = 2;

        [Header("Player Length Tracking")]
        [SerializeField] int totalClonesFollowing = 0;
        [SerializeField] int currentClonesFollowing = 0;

        [Header("Score Keeping / total Counters")]
        [SerializeField] int totalClonesMade = 0;
        [SerializeField] int totalClonesPickedUp = 0;
        float scoreTimer = 0;

        private void Update()
        {
            scoreTimer += Time.deltaTime;
            StartPiggieSpawnTimer();

            StartProcessingTimer();

            CloneMakingProcessing();
        }

        

        //Spawner timer & counter for piggies
        public bool PigSpawnTimer()
        {
            return timeSinceLastSpawn >= piggieRespawnDelay;
        }
        public bool PiggieSpawnAtMax()
        {
            return piggieSpawnedCount >= piggieSpawnMax;
        }
        public void OnPigSpawn()
        {
            piggieSpawnedCount++;
            timeSinceLastSpawn = 0;
        }
        private void StartPiggieSpawnTimer()
        {
            if (!PiggieSpawnAtMax())
            {
                timeSinceLastSpawn += Time.deltaTime;
            }
        }
        

        //Called by Piggie Dropoff OnTriggerEnter
        public void OnPigDropOffTrigger()
        {
            piggiesEntered++;
            clonesBeingMade = clonesBeingMade + piggieToCloneRatio;
            PiggieDestroyed();
        }

        public void PiggieDestroyed()
        {
            piggieSpawnedCount--;
        }

        //Called by CloneSpawner OnTriggerStay & OnTriggerExit
        //starts and resets timer 
        public void StartWaitTimer()
        {
                pickupWaitTimer += Time.deltaTime;
        }
        public bool PickupTimeWaited()
        {
            return pickupWaitTimer > pickupTimeWaited;
        }
        public void OnClonePickupTrigger()
        {
            totalClonesPickedUp++;
            clonesWaitingForPickup--;
            ResetWaitTimer();
        }
        public float ResetWaitTimer()
        {
            return pickupWaitTimer =  0;
        }
        
        //Player Length Tracking 
        public void IncreaseClonesFollowing()
        {
            currentClonesFollowing++;
            if (currentClonesFollowing > totalClonesFollowing)
            {
                totalClonesFollowing++;
            }
        }
        public void DecreaseClonesFollowing()
        {
            currentClonesFollowing--;
        }

        //processing timer bool
        private bool ProcessingTimeReached()
        {
            return processingTimer >= processingDuration;
        }
        
        //pig to clone processing
        //reset processing timer, increases total clones made
        //& waiting for pickup counter
        private void StartProcessingTimer()
        {
            if (clonesBeingMade > 0)
            {
                processingTimer += Time.deltaTime;
            }
        }
        private void CloneMakingProcessing()
        {
            if (clonesBeingMade > 0 && ProcessingTimeReached())
            {
                //trades clones to make for waiting for pickup
                clonesBeingMade--;
                clonesWaitingForPickup++;

                processingTimer = 0;

                totalClonesMade++;
            }
        }

        //public Getters
        public float GetTotalClonesMade()
        {
            return totalClonesMade;
        }
        public float GetTotalClonesPickedUp()
        {
            return totalClonesPickedUp;
        }
        public float GetClonesWaitingForPickup()
        {
            return clonesWaitingForPickup;
        }
        public float GetClonesBeingMade()
        {
            return clonesBeingMade;
        }
        public float GetCurrentFollowers()
        {
            return currentClonesFollowing;
        }
        public float GetTotalFollowers()
        {
            return totalClonesFollowing;
        }

        public int FinalScore()
        {
            return totalClonesPickedUp + (int)scoreTimer + (piggiesEntered / 2);
        }
    }


}
