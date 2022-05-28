using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Movement;


namespace Control 
{
    public class PiggieController : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 0.1f;

        GameObject player;
        Follow follow;
        GameManager gameManager;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindWithTag("Player");
            follow = GetComponent<Follow>();
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (player == null) { return; }
            if (follow.InRangeOfPlayer(player))
            {
                transform.LookAt(player.transform);
                follow.FollowTarget(player, moveSpeed);
            }
        }

        private void OnDestroy()
        {
            gameManager.PiggieDestroyed();
        }

        //slowly move in facing direction
        private void Wandering()
        {
            //move in forward direction
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            
            //TODO change direction if collide with non player entity
        }
    }  
}
