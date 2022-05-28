using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Control
{
    public class CloneFollower : MonoBehaviour
    {
        [SerializeField] int index = 0;
        [SerializeField] float cloneSpeed = 0;
        [SerializeField] float gap = 1;

        [SerializeField] Transform clonePrefab;

        [SerializeField] private List<Transform> Followers = new List<Transform>();

        private GameManager gameManager;
        public GameObject lastClone;

        private void Awake()
        {
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            
            Followers.Add(this.transform);
            lastClone = Followers[0].gameObject;
        }

        void Update()
        {
            CloneMovement();
        }

        private void CloneMovement()
        {
            for (int i = Followers.Count - 1; i > 0; i--)
            {
                Transform clone = Followers[i];
                Transform previousClone = Followers[i - 1];
                float distance = Vector3.Distance(clone.position, previousClone.position);
                if (distance > gap)
                {
                    cloneSpeed = (distance / gap);
                    clone.LookAt(Followers[i - 1]);
                    clone.position = Vector3.MoveTowards(clone.position, previousClone.position, cloneSpeed);
                }
                else if (distance <= gap)
                {
                    cloneSpeed = 0;
                }
            }
        }
        public bool FollowersIncreased()
        {
            return Followers.Count > index;
        }

        //Adds follower to the array
        public void AddFollowers()
        {
            Transform clone = Instantiate(this.clonePrefab);
            clone.position = Followers[Followers.Count - 1].position;
            GetLastClone();
            
            Followers.Add(clone);
            
            gameManager.IncreaseClonesFollowing();
        }

        //assigned the Last object in Followers to GetLastClone
        public GameObject GetLastClone()
        {
            return lastClone = Followers[Followers.Count - 1].gameObject;
        }

        //access to the number of Followers in play
        public int GetFollowerCount()
        {
            return Followers.Count;
        }

        public void DestroyFollowers(GameObject gameObject)
        {
            int positionInFollowers = Followers.IndexOf(gameObject.transform);
            Debug.Log(Followers[positionInFollowers]);
            Followers.RemoveAt(positionInFollowers);
            Destroy(gameObject);
            GetLastClone();
        }
    }
}
