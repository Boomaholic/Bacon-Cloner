using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MenuManager : MonoBehaviour
    {
        //start new game
        public void NewGame()
        {
            SceneManager.LoadScene(1);
        }
 
        //Quit Game
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}