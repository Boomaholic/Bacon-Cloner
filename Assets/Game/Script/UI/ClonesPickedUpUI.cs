using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using TMPro;
using System;

namespace UI
{
    public class ClonesPickedUpUI : MonoBehaviour
    {
        [SerializeField] GameManager gameManager;

        private void Awake()
        {
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        }


        private void Update()
        {
            GetComponent<TMP_Text>().text = String.Format("{0:0}",
                gameManager.GetTotalClonesPickedUp());
        }
    }
}