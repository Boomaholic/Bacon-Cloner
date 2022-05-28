using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ShowUIcountdown : MonoBehaviour
    {
        //counts to this time then turns off
        private float timer = 0;
        [SerializeField] private float endTimer = 4;
        bool turnedOn = false;

        private void Awake()
        {
            turnedOn = true;
        }

        private void Update()
        {
            if (turnedOn)
            {
                timer += Time.deltaTime;
                if (timer > endTimer)
                {
                    this.enabled = false;
                    this.gameObject.SetActive(false);
                }
            }
        }


    }
}
