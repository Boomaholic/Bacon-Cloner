using System.Collections;
using UnityEngine;
using Core;
using TMPro;
using System;

namespace UI
{
    public class Score : MonoBehaviour
    {
            [SerializeField] GameManager gameManager;

            private void Awake()
            {
                gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            }

            private void Update()
            {
                GetComponent<TMP_Text>().text = "Score: " + String.Format("{0:0}",
                    gameManager.FinalScore());
            }
        
    }
}