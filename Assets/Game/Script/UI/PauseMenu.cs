using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] PauseMenuAccess pauseMenuControls;

        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

        public void MainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }


        public void QuitGame()
        {
            Application.Quit();
        }

    }
}