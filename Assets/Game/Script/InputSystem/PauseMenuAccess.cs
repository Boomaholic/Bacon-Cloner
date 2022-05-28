using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PauseMenuAccess : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] bool gameIsPaused = false;

    private StarterAssetsInputs input;


    void Start()
    {
        input = GetComponent<StarterAssetsInputs>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGamePress();
    }
    private void PauseGamePress()
    {
        if (input.pause && gameIsPaused)
        {
            Resume();
            input.pause = false;
        }
        else if (input.pause && !gameIsPaused)
        {
            Pause();
            input.pause = false;
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    public bool GetGameIsPaused(){ return gameIsPaused; }
    
}
