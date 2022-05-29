using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Spawner : MonoBehaviour
    {
        
        [SerializeField] GameObject piggie;
        [SerializeField] GameObject hungryDude;
        [SerializeField] int hungrySpawnlimit = 5;
        private bool enemyHasSpawned = false;
        GameManager gameManager;
        private Vector3 checkSpawnLocation;
        private Vector3 newSpawnLocation;
        private Vector3 oldSpawnLocation;
        private BoxCollider boxCollider;


        private void Awake()
        {
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            boxCollider = GetComponent<BoxCollider>();
        }

        private void Update()
        {
            
            //spawn piggies over time
            if (gameManager.PigSpawnTimer() && !gameManager.PiggieSpawnAtMax())
            {
                Spawn(piggie);
                gameManager.OnPigSpawn();
            }
            
            //spawn Hungry Dude when ready
            if (gameManager.GetTotalFollowers() >= hungrySpawnlimit && !enemyHasSpawned)
            {
                Spawn(hungryDude);
                enemyHasSpawned = true;
            }
        }

        //bool check if space is occupied in newspawnlocation
        public bool SpawnOccupied()
        {
            Collider[] hitColliders = Physics.OverlapSphere(checkSpawnLocation, 1f);
            if (hitColliders.Length > 0)
            {
                return true;
            }
            return false;

        }
        
        //gets random X,Y cordinates
        public float SetCord()
        {
            return Random.Range(5, 45);
        }

        //sets spawn location
        private void GetSpawnLocation()
        {
            float xCord = SetCord();
            float zCord = SetCord();
            newSpawnLocation = new Vector3(xCord, 0, zCord);
            checkSpawnLocation = new Vector3(xCord, 2f, zCord);

        }

        //Spawns assigned GameObject in location if location occupied check is false
        private void Spawn(GameObject gameObject)
        {
            boxCollider.enabled = false;
            GetSpawnLocation();
            if (!SpawnOccupied() && newSpawnLocation != oldSpawnLocation)
            {
                Instantiate(gameObject, newSpawnLocation, Quaternion.Euler(0, Random.Range(0, 259), 0));
                oldSpawnLocation = newSpawnLocation;
                boxCollider.enabled = true;
            }
            
        }

        //public getter for if enemy has spawned
        public bool EnemyHasSpawned(bool value)
        {
            return enemyHasSpawned = value;
        }
    }
}