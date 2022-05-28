using System.Collections;
using UnityEngine;
using Core;
using TMPro;
using System;

namespace UI
{
    public class ClonesBeingMadeUI : MonoBehaviour
    {
        [SerializeField] GameManager gameManager;

        private void Awake()
        {
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        }


        private void Update()
        {
            GetComponent<TMP_Text>().text = String.Format("{0:0}",
                gameManager.GetClonesBeingMade());
        }
    }
}