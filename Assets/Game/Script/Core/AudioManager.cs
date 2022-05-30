using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core {
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        [Header("Hungry SFX")]
        [SerializeField] AudioSource Alerts;
        [SerializeField] AudioClip spawnedClip;
        [SerializeField] AudioClip eatingClip;

        [Header("Cloning")]
        [SerializeField] AudioSource cloningSource;
        [SerializeField] AudioClip cookingClip;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else { Destroy(gameObject); }
        }

        public void EatSFX()
        {
            Alerts.PlayOneShot(eatingClip);
        }

        public void ISpawnedSFX()
        {

            Alerts.PlayOneShot(spawnedClip);
        }

        public void CloningSFX()
        {
            cloningSource.PlayOneShot(cookingClip);
        }
    }
}
