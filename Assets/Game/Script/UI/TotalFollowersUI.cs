using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using TMPro;
using System;

namespace UI
{
    public class TotalFollowersUI : MonoBehaviour
    {
        [SerializeField] GameManager gameManager;

        private void Awake()
        {
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        }

        private void Update()
        {
            GetComponent<TMP_Text>().text = String.Format("{0:0}/{1:0}",
                gameManager.GetCurrentFollowers(),gameManager.GetTotalFollowers());
        }
    }
}
